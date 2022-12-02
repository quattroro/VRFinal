using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : BaseSlot, IInteractable
{
    public float ClickStartTime;
    public bool IsClicked;

    public ItemSlotMenu[] ItemSlotMenus;

    public override void Init(BoxType _box, SlotType type)
    {
        base.Init(_box, type);
        ItemSlotMenus = new ItemSlotMenu[(int)SlotMenu.SlotMenuMax];
        for (SlotMenu i = SlotMenu.Get; i < SlotMenu.SlotMenuMax; i++)
        {
            ItemSlotMenus[(int)i] = transform.Find($"SlotMenu({i.ToString()})").GetComponent<ItemSlotMenu>();
            ItemSlotMenus[(int)i].Init(this);




            ItemSlotMenus[(int)i].gameObject.SetActive(false);
        }

    }

    private void Start()
    {
        Init(BoxType.ITEMBOX, SlotType.NORMAL);
    }

    //클릭되고 현재 슬롯에 들어있는 아이템이 있으면 해당 아이템에 대한 슬롯 메뉴를 보여준다.
    public void Down()
    {
        Debug.Log($"ItemSlot 눌림");

    }
    public void Up()
    {
        //슬롯이 클릭이 되었고 아이템이 설정되어 있으면
        //슬롯 메뉴를 보여준다.
        if (SettedItem != null)
            ShowItemMenu();
    }

    public void OverLap()
    {

    }
    public void ClickUpdate()
    {

    }


    //아이템 박스에서는 Get 인벤토리에서는 Drop으로 기능한다.
    public void ShowItemMenu()
    {
        for (int i = 0; i < (int)SlotMenu.SlotMenuMax; i++)
        {
            ItemSlotMenus[i].gameObject.SetActive(true);
        }
    }
}
