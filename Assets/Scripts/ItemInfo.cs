using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/ItemInfo", order = int.MaxValue)]
public class ItemInfo : ScriptableObject
{
    public ItemType itemType;
    public Texture2D itemSprite;
    public float itemPrice;
    public EquipType equipType;
    
}
