using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;





public class ItemSlot : BaseSlot, IInteractable
{
    //public GameObject[] SlopMenu;
    public float ClickStartTime;

    public bool IsOverLaped = false;
    public bool IsClicked;

    public ItemSlotMenu[] ItemSlotMenus;

    //Inventory or ItemBox
    public GameObject baseBox;




    public override void Init(BoxType _box, SlotType type)
    {
        base.Init(_box, type);
        ItemSlotMenus = new ItemSlotMenu[(int)SlotMenu.SlotMenuMax];
        for (SlotMenu i = SlotMenu.Get; i< SlotMenu.SlotMenuMax;i++)
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

    
    public void Down()
    {
        Debug.Log($"ItemSlot ����");
        //���콺�� ����ä�� �������� �ű�� ���콺�� ������ ��尡 ����ٴϵ��� ���ش�.
        if(SettedItem!=null)
        {
            GameManager.Instance.ClickedItem = GetItem();
        }
    }

    //Ŭ���ǰ� ���� ���Կ� ����ִ� �������� ������ �ش� �����ۿ� ���� ���� �޴��� �����ش�.
    public void Up()
    {
        //���� �ش� ���Կ��� ������ ���Ÿ� ������ �޴��� �����ְ�
        if(IsClicked)
        {
            //������ Ŭ���� �Ǿ��� �������� �����Ǿ� ������
            //���� �޴��� �����ش�.
            if (SettedItem != null)
                ShowItemMenu();
        }
        //�ٸ� �������� ������ �����Ÿ� �ش� ���Կ� �̹� ���õǾ� �ִ� �������� �ִ�����, ���� ����ٴϰ� �ִ� �������� �ִ����� ���� ���ο� ���Կ� �������� �����ϴ���
        //�ٽ� �ִ� �������� ������������ �ൿ�� �Ѵ�.
        else
        {
            //Ŭ������ �������� �ְ� �� ������ ��������� 
            if (GameManager.Instance.ClickedItem != null && SettedItem == null)
            {
                SetItem(GameManager.Instance.ClickedItem);
            }

            //�ƴϸ� ���� �ִ� �������� ���ư���.
            GameManager.Instance.ClickedItem.CurSettedSlot.SetItem(GameManager.Instance.ClickedItem);
            GameManager.Instance.ClickedItem.CurSettedSlot = null;
        }
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



    protected void OnHandHoverBegin(Hand hand)
    {
        IsOverLaped = true;
    }

    protected void OnHandHoverEnd(Hand hand)
    {
        IsOverLaped = false;
        IsClicked = false;
    }

    protected void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            IsClicked = true;
            Down();
        }

        if (hand.GetGrabEnding() != GrabTypes.None)
        {
            Up();


            //IInteractable obj = GetClickedObj(hand.transform.position);
            //if (obj != null && obj == CurClickedObj)
            //    obj.Up();
            //if (IsClicked)
            //    Up();

            IsClicked = false;
        }
    }






















    //protected void OnHandHoverBegin(Hand hand)
    //{
    //    //Debug.Log("ItemSlot�鷯��");

    //}

    ////���� �ش� �׸��������� ������ ���� ����ó�� ����
    //protected void OnHandHoverEnd(Hand hand)
    //{
    //    Debug.Log("ItemSlot����");
    //}

    ////�׸����� �ȿ��� ���콺�� �����϶�
    //protected void HandHoverUpdate(Hand hand)
    //{
    //    //Debug.Log("ItemSlot�����̴���");
    //    //�׸����� �ȿ��� �׷� ��ư�� ������ 
    //    if (hand.GetGrabStarting() != GrabTypes.None)
    //    {
    //        //Debug.Log("ItemSlot����");
    //    }





    //    //�׷��� ������
    //    if (hand.GetGrabEnding() != GrabTypes.None)
    //    {
    //        //Debug.Log("ItemSlot���ȴ� ��");
    //    }
    //}

}
