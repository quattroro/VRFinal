using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    HELMET,
    ARMOR,
    BOOTS,
    GLOVES,
    WEAPON,
    EquipTypeMax
}

public class EquipItem : BaseItem
{
    EquipType equipType;
    public override void Init(ItemInfo info, ItemType type)
    {
        base.Init(info, type);
        equipType = info.equipType;

    }
}
