using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public static SkinController Instance;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public SkinSO Skin;

    public enum eSkin
    {
        Normal,
        Fish
    }

    public eSkin currentSkin; // 0 - Normal, 1 - Fish

    public Sprite GetSkin(int index)
    {
        return Skin.fishSkin[index];
    }
    
    
}
