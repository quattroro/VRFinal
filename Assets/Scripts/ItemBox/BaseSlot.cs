using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템 세팅
//아이템 세팅 해제
//아이템 타입 리턴
//현재 아이템이 있는지
//현재 아이템의 개수

public enum SlotType
{
    EQUIP,
    NORMAL,
}

public enum SlotMenu
{
    Get,
    Drop,
    Equip,
    Use,
    Move,
    SlotMenuMax
}

public enum BoxType
{
    INVENTORY,
    ITEMBOX,
    BoxTypeMax
}

public class BaseSlot : MonoBehaviour
{
    public SlotType slotType;
    public BoxType boxType;

    [SerializeField]
    protected BaseItem SettedItem;


    public virtual void Init(BoxType _box, SlotType type)
    {
        slotType = type;
    }


    public void MenuClick()
    {

    }

    public void SetItem(BaseItem item)
    {
        //비어있을때는 슬롯에 아이템 세팅
        if(SettedItem==null)
        {
            SettedItem = item;
            item.CurSettedSlot = this;
            item.transform.position = this.transform.position + new Vector3(0.01f, 0, 0);

            return;
        }
        //스택증가
        if (SettedItem == item)
        {
            SettedItem.StackUp(item.Stack);
            return;
        }
        
            
    }


    public BaseItem GetItem()
    {
        BaseItem item = null;

        if (SettedItem != null)
        {
            item = SettedItem;
            SettedItem = null;
        }

        return item;
    }

    public void UseItem()
    {
        
        SettedItem.StackDown(1);


    }

    public void EquipItem()
    {

    }

}
