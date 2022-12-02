using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ItemSlotMenu : MonoBehaviour, IInteractable
{
    public BaseSlot parentSlot;
    public SlotMenu menu;

    public TextMesh text;

    //메뉴 위치의 오프셋
    public Vector3[] offset = new Vector3[(int)SlotMenu.SlotMenuMax];

    public delegate void ClickInvoke();
    public ClickInvoke invoke;

    public bool IsOverLaped = false;
    public bool IsClicked = false;

    [SerializeField]
    private bool isActivate = false;

    public bool IsActivate
    {
        get
        {
            return isActivate;
        }
        set
        {
            isActivate = value;
            if (value)
            {
                text.color = Color.white;
            }
            else
            {
                text.color = Color.red;
            }
        }
    }


    public void Init(BaseSlot _parent)
    {
        parentSlot = _parent;
        text = GetComponentInChildren<TextMesh>();
        IsActivate = true;
    }

    ////해당 
    //public void Init(ItemSlot _parent, SlotMenu _menu)
    //{
    //    parentSlot = _parent;
    //    menu = _menu;
    //    //transform.position = parentSlot.transform.position + offset[(int)_menu];
    //}

    public void Down()
    {
        //switch (menu)
        //{
        //    case SlotMenu.Drop:
        //        Debug.Log($"{menu} 메뉴 눌림");
        //        break;

        //    case SlotMenu.Equip:
        //        Debug.Log($"{menu} 메뉴 눌림");
        //        break;

        //    case SlotMenu.Move:
        //        Debug.Log($"{menu} 메뉴 눌림");
        //        break;

        //    case SlotMenu.Use:
        //        Debug.Log($"{menu} 메뉴 눌림");
        //        break;
        //}
    }

    public void ItemGet()
    {
        switch(parentSlot.boxType)
        {
            //만약 해당 슬롯이 아이템 박스에 있던 슬롯이면 캐릭터의 인벤토리에 넣는다.
            case BoxType.ITEMBOX:
                //parentSlot
                break;
        }
        
    }

    public void ItemDrop()
    {
        //어디에 있던지 똑같이 해당 아이템을 없애준다.
        
    }

    public void ItemEquip()
    {
        //어디에 있던지 똑같이 해당 아이템이 장착 가능한 아이템이면 장착시켜준다.
        
    }

    public void ItemMove()
    {
        //어디에 있던지 똑같이 해당 아이템이 장착 가능한 아이템이면 장착시켜준다.
        
    }

    public void ItemUse()
    {
        //어디에 있던지 똑같이 해당 아이템을 사용해준다.
        switch (parentSlot.boxType)
        {
            case BoxType.INVENTORY:

                break;

            case BoxType.ITEMBOX:

                break;
        }
    }

    public void Up()
    {
        if(IsActivate)
        {
            switch (menu)
            {
                //해당 아이템을 삭제시킨다.
                //슬롯에 있는 Get을 실행 시킨다.
                case SlotMenu.Get:
                    Debug.Log($"{menu} 메뉴 눌림");
                    ItemGet();


                    break;

                //해당 아이템을 삭제시킨다.
                case SlotMenu.Drop:
                    Debug.Log($"{menu} 메뉴 눌림");
                    ItemDrop();
                    break;

                //해당 아이템을 장착시킨다.
                case SlotMenu.Equip:
                    Debug.Log($"{menu} 메뉴 눌림");
                    ItemEquip();
                    break;

                //해당 아이템을 옮긴다.
                case SlotMenu.Move:
                    Debug.Log($"{menu} 메뉴 눌림");
                    ItemMove();
                    break;

                //해당 아이템을 사용한다.
                case SlotMenu.Use:
                    Debug.Log($"{menu} 메뉴 눌림");
                    ItemUse();
                    break;
            }
        }
        
    }

    public void OverLap()
    {
        if (IsActivate)
        {
            switch (menu)
            {
                //해당 아이템을 삭제시킨다.
                case SlotMenu.Get:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;

                //해당 아이템을 삭제시킨다.
                case SlotMenu.Drop:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;

                //해당 아이템을 장착시킨다.
                case SlotMenu.Equip:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;

                //해당 아이템을 옮긴다.
                case SlotMenu.Move:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;

                //해당 아이템을 사용한다.
                case SlotMenu.Use:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;
            }
        }
    }

    public void ClickUpdate()
    {
        if (IsActivate)
        {
            switch (menu)
            {
                //해당 아이템을 삭제시킨다.
                case SlotMenu.Get:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;

                //해당 아이템을 삭제시킨다.
                case SlotMenu.Drop:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;

                //해당 아이템을 장착시킨다.
                case SlotMenu.Equip:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;

                //해당 아이템을 옮긴다.
                case SlotMenu.Move:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;

                //해당 아이템을 사용한다.
                case SlotMenu.Use:
                    Debug.Log($"{menu} 메뉴 눌림");
                    break;
            }
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
            //IInteractable obj = GetClickedObj(hand.transform.position);
            //if (obj != null && obj == CurClickedObj)
            //    obj.Up();
            if(IsClicked)
                Up();
            IsClicked = false;
        }
    }

}
