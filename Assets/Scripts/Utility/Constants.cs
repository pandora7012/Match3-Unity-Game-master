using System;
using UnityEngine;

public class Constants 
{
    public const string GAME_SETTINGS_PATH = "gamesettings";

    public const string PREFAB_CELL_BACKGROUND = "prefabs/cellBackground";

    public const string PREFAB_NORMAL_TYPE_ONE = "prefabs/itemNormal01";

    public const string PREFAB_NORMAL_TYPE_TWO = "prefabs/itemNormal02";

    public const string PREFAB_NORMAL_TYPE_THREE = "prefabs/itemNormal03";

    public const string PREFAB_NORMAL_TYPE_FOUR = "prefabs/itemNormal04";

    public const string PREFAB_NORMAL_TYPE_FIVE = "prefabs/itemNormal05";

    public const string PREFAB_NORMAL_TYPE_SIX = "prefabs/itemNormal06";

    public const string PREFAB_NORMAL_TYPE_SEVEN = "prefabs/itemNormal07";

    public const string PREFAB_BONUS_HORIZONTAL = "prefabs/itemBonusHorizontal";

    public const string PREFAB_BONUS_VERTICAL = "prefabs/itemBonusVertical";

    public const string PREFAB_BONUS_BOMB = "prefabs/itemBonusBomb";
    
    public static string GetPrefabNameByType(NormalItem.eNormalType type)
    {
        string prefabname = type switch
        {
            NormalItem.eNormalType.TYPE_ONE => PREFAB_NORMAL_TYPE_ONE,
            NormalItem.eNormalType.TYPE_TWO => PREFAB_NORMAL_TYPE_TWO,
            NormalItem.eNormalType.TYPE_THREE => PREFAB_NORMAL_TYPE_THREE,
            NormalItem.eNormalType.TYPE_FOUR => PREFAB_NORMAL_TYPE_FOUR,
            NormalItem.eNormalType.TYPE_FIVE => PREFAB_NORMAL_TYPE_FIVE,
            NormalItem.eNormalType.TYPE_SIX => PREFAB_NORMAL_TYPE_SIX,
            NormalItem.eNormalType.TYPE_SEVEN => PREFAB_NORMAL_TYPE_SEVEN,
            _ => string.Empty
        };

        return prefabname;
    }
    
    public static string GetPrefabNameByType(BonusItem.eBonusType type)
    {
      //  Debug.LogError(type);
        string prefabname = string.Empty;
        switch (type)
        {
            case BonusItem.eBonusType.NONE:
                break;
            case BonusItem.eBonusType.HORIZONTAL:
                prefabname = PREFAB_BONUS_HORIZONTAL;
                break;
            case BonusItem.eBonusType.VERTICAL:
                prefabname = PREFAB_BONUS_VERTICAL;
                break;
            case BonusItem.eBonusType.ALL:
                prefabname = PREFAB_BONUS_BOMB;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        return prefabname;
    }

   
    
    
}