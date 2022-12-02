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
        Debug.Log($"ItemSlot 눌림");
        //마우스를 누른채로 아이템을 옮기면 마우스에 아이템 노드가 따라다니도록 해준다.
        if(SettedItem!=null)
        {
            GameManager.Instance.ClickedItem = GetItem();
        }
    }

    //클릭되고 현재 슬롯에 들어있는 아이템이 있으면 해당 아이템에 대한 슬롯 메뉴를 보여준다.
    public void Up()
    {
        //만약 해당 슬롯에서 눌렀다 뗀거면 아이템 메뉴를 보여주고
        if(IsClicked)
        {
            //슬롯이 클릭이 되었고 아이템이 설정되어 있으면
            //슬롯 메뉴를 보여준다.
            if (SettedItem != null)
                ShowItemMenu();
        }
        //다른 슬롯으로 끌러다 놓은거면 해당 슬롯에 이미 세팅되어 있는 아이템이 있는지와, 현재 끌고다니고 있는 아이템이 있는지에 따라 새로운 슬롯에 아이템을 세팅하던지
        //다시 있던 슬롯으로 돌려놓는지의 행동을 한다.
        else
        {
            //클릭중인 아이템이 있고 이 슬롯이 비어이으면 
            if (GameManager.Instance.ClickedItem != null && SettedItem == null)
            {
                SetItem(GameManager.Instance.ClickedItem);
            }

            //아니면 원래 있던 슬롯으로 돌아간다.
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


    //아이템 박스에서는 Get 인벤토리에서는 Drop으로 기능한다.
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
    //    //Debug.Log("ItemSlot들러옴");

    //}

    ////손이 해당 그림영역에서 나가면 손을 뗀것처럼 동작
    //protected void OnHandHoverEnd(Hand hand)
    //{
    //    Debug.Log("ItemSlot나감");
    //}

    ////그림영역 안에서 마우스가 움직일때
    //protected void HandHoverUpdate(Hand hand)
    //{
    //    //Debug.Log("ItemSlot움직이는중");
    //    //그림영역 안에서 그랩 버튼이 눌리면 
    //    if (hand.GetGrabStarting() != GrabTypes.None)
    //    {
    //        //Debug.Log("ItemSlot눌림");
    //    }





    //    //그랩을 뗐을때
    //    if (hand.GetGrabEnding() != GrabTypes.None)
    //    {
    //        //Debug.Log("ItemSlot눌렸다 뗌");
    //    }
    //}

}
