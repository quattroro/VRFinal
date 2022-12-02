using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    EQUIP,
    USEABLE,
    ItemTypeMax,
}

public class BaseItem : MonoBehaviour
{
    //픽이된상태면 마우스를 따라다니도록
    public bool IsPicked;

    //
    public Sprite sprite;

    public ItemType itemType;

    public int stack;

    public BaseSlot CurSettedSlot;
    public BaseSlot LastSettedSlot;

    public ItemInfo itemInfo;

    [SerializeField]
    private Material mat;

    public void SetSettedSlot(BaseSlot slot)
    {
        LastSettedSlot = CurSettedSlot;
        CurSettedSlot = slot;
    }



    public int Stack
    {
        get
        {
            return stack;
        }
        set
        {
            stack = value;
        }
    }

    public void StackUp(int val)
    {
        if(Stack + val>=99)
        {
            Stack = 99;
        }
    }


    public void StackDown(int val)
    {
        if (Stack - val <= 0)
        {
            Stack = 0;
        }
    }

    public BaseItem ItemPick()
    {
        LastSettedSlot = CurSettedSlot;
        CurSettedSlot = null;
        return this;
    }

    public void UseItem()
    {
        Debug.Log($"{name} 아이템 사용");
    }

    public void ItemPickReturn()
    {

    }


    public virtual void Init(ItemInfo info, ItemType type)
    {
        itemInfo = info;
        itemType = type;
        mat = GetComponent<MeshRenderer>().material;
        mat.SetTexture("_MainTex", info.itemSprite);
    }
}
