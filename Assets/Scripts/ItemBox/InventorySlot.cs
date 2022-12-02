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

    //Ŭ���ǰ� ���� ���Կ� ����ִ� �������� ������ �ش� �����ۿ� ���� ���� �޴��� �����ش�.
    public void Down()
    {
        Debug.Log($"ItemSlot ����");

    }
    public void Up()
    {
        //������ Ŭ���� �Ǿ��� �������� �����Ǿ� ������
        //���� �޴��� �����ش�.
        if (SettedItem != null)
            ShowItemMenu();
    }

    public void OverLap()
    {

    }
    public void ClickUpdate()
    {

    }


    //������ �ڽ������� Get �κ��丮������ Drop���� ����Ѵ�.
    public void ShowItemMenu()
    {
        for (int i = 0; i < (int)SlotMenu.SlotMenuMax; i++)
        {
            ItemSlotMenus[i].gameObject.SetActive(true);
        }
    }
}
