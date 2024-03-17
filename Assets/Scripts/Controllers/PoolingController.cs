using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PoolingController : MonoBehaviour
{
    public static PoolingController Instance { get; private set; }
    public int poolSize;


    private List<List<GameObject>> _normalItems;
    private List<List<GameObject>> _bonusItems;
    private List<GameObject> _prefabBg;

    [SerializeField] private Transform _root; // Root for all pooled objects

    private void Awake()
    {
        Instance = this;
        OnInitialize();
    }

    private void OnInitialize()
    {
        _normalItems = new List<List<GameObject>>();
        _bonusItems = new List<List<GameObject>>();
        _prefabBg = new List<GameObject>();
        OnInstantiate();
    }


    #region Instantiate

    private void OnInstantiate()
    {
        var gameSetting = Resources.Load<GameSettings>(Constants.GAME_SETTINGS_PATH);

        // Init BG Prefabs
        var prefabBG = Resources.Load<GameObject>(Constants.PREFAB_CELL_BACKGROUND);
        for (int i = 0; i < gameSetting.BoardSizeX * gameSetting.BoardSizeY + 2; i++)
        {
            var bg = Instantiate(prefabBG, _root);
            _prefabBg.Add(bg);
        }

        // Init Normal Items
        foreach (var variable in NormalItem.eNormalType.GetValues(typeof(NormalItem.eNormalType)))
            InstantiateNormalItems((NormalItem.eNormalType)variable);

        // Init Bonus Items
        foreach (var variable in BonusItem.eBonusType.GetValues(typeof(BonusItem.eBonusType)))
            InstantiateBonusItems((BonusItem.eBonusType)variable);
    }

    private GameObject InstantiateItem(GameObject prefab)
    {
        var item = Instantiate(prefab, _root);

        return item; // Return the item
    }

    private void InstantiateNormalItems(NormalItem.eNormalType type)
    {
        var ic = (int)type;
        _normalItems.Add(new List<GameObject>());
        var prefab = Resources.Load<GameObject>(Constants.GetPrefabNameByType(type));
        for (int i = 0; i < poolSize; i++) _normalItems[ic].Add(InstantiateItem(prefab));
    }

    private void InstantiateBonusItems(BonusItem.eBonusType type)
    {
        var ic = (int)type;
        _bonusItems.Add(new List<GameObject>());
        var prefab = Resources.Load<GameObject>(Constants.GetPrefabNameByType(type));
        if (prefab == null) return;
        for (int i = 0; i < poolSize; i++) _bonusItems[ic].Add(InstantiateItem(prefab));
    }

    #endregion


    #region CellBG

    public GameObject GetCellBackground()
    {
        GameObject bg = _prefabBg.Find(i => !i.activeInHierarchy);

        if (bg == null)
        {
            bg = Instantiate(_prefabBg[0], transform);
            _prefabBg.Add(bg);
        }

        return bg;
    }

    public void Release(GameObject bg)
    {
        bg.transform.SetParent(_root);
        bg.transform.localScale = Vector3.one;
    }

    #endregion


    #region Item

    public GameObject GetItemByType(NormalItem.eNormalType type)
    {
        var id = (int)type;
        GameObject item = _normalItems[id].Find(i => !i.activeInHierarchy);

        if (item == null)
        {
            item = Instantiate(Resources.Load<GameObject>(Constants.GetPrefabNameByType(type)), _root);
            _normalItems[id].Add(item);
        }

        return item;
    }

    public GameObject GetItemByType(BonusItem.eBonusType type)
    {
        var id = (int)type;
        GameObject item = _bonusItems[id].Find(i => !i.activeInHierarchy);

        if (item == null)
        {
            item = Instantiate(Resources.Load<GameObject>(Constants.GetPrefabNameByType(type)), _root);
            _bonusItems[id].Add(item);
        }

        return item;
    }

    #endregion*/
}