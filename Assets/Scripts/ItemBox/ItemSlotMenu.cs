using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ItemSlotMenu : MonoBehaviour, IInteractable
{
    public BaseSlot parentSlot;
    public SlotMenu menu;

    public TextMesh text;

    //�޴� ��ġ�� ������
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

    ////�ش� 
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
        //        Debug.Log($"{menu} �޴� ����");
        //        break;

        //    case SlotMenu.Equip:
        //        Debug.Log($"{menu} �޴� ����");
        //        break;

        //    case SlotMenu.Move:
        //        Debug.Log($"{menu} �޴� ����");
        //        break;

        //    case SlotMenu.Use:
        //        Debug.Log($"{menu} �޴� ����");
        //        break;
        //}
    }

    public void ItemGet()
    {
        switch(parentSlot.boxType)
        {
            //���� �ش� ������ ������ �ڽ��� �ִ� �����̸� ĳ������ �κ��丮�� �ִ´�.
            case BoxType.ITEMBOX:
                //parentSlot
                break;
        }
        
    }

    public void ItemDrop()
    {
        //��� �ִ��� �Ȱ��� �ش� �������� �����ش�.
        
    }

    public void ItemEquip()
    {
        //��� �ִ��� �Ȱ��� �ش� �������� ���� ������ �������̸� ���������ش�.
        
    }

    public void ItemMove()
    {
        //��� �ִ��� �Ȱ��� �ش� �������� ���� ������ �������̸� ���������ش�.
        
    }

    public void ItemUse()
    {
        //��� �ִ��� �Ȱ��� �ش� �������� ������ش�.
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
                //�ش� �������� ������Ų��.
                //���Կ� �ִ� Get�� ���� ��Ų��.
                case SlotMenu.Get:
                    Debug.Log($"{menu} �޴� ����");
                    ItemGet();


                    break;

                //�ش� �������� ������Ų��.
                case SlotMenu.Drop:
                    Debug.Log($"{menu} �޴� ����");
                    ItemDrop();
                    break;

                //�ش� �������� ������Ų��.
                case SlotMenu.Equip:
                    Debug.Log($"{menu} �޴� ����");
                    ItemEquip();
                    break;

                //�ش� �������� �ű��.
                case SlotMenu.Move:
                    Debug.Log($"{menu} �޴� ����");
                    ItemMove();
                    break;

                //�ش� �������� ����Ѵ�.
                case SlotMenu.Use:
                    Debug.Log($"{menu} �޴� ����");
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
                //�ش� �������� ������Ų��.
                case SlotMenu.Get:
                    Debug.Log($"{menu} �޴� ����");
                    break;

                //�ش� �������� ������Ų��.
                case SlotMenu.Drop:
                    Debug.Log($"{menu} �޴� ����");
                    break;

                //�ش� �������� ������Ų��.
                case SlotMenu.Equip:
                    Debug.Log($"{menu} �޴� ����");
                    break;

                //�ش� �������� �ű��.
                case SlotMenu.Move:
                    Debug.Log($"{menu} �޴� ����");
                    break;

                //�ش� �������� ����Ѵ�.
                case SlotMenu.Use:
                    Debug.Log($"{menu} �޴� ����");
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
                //�ش� �������� ������Ų��.
                case SlotMenu.Get:
                    Debug.Log($"{menu} �޴� ����");
                    break;

                //�ش� �������� ������Ų��.
                case SlotMenu.Drop:
                    Debug.Log($"{menu} �޴� ����");
                    break;

                //�ش� �������� ������Ų��.
                case SlotMenu.Equip:
                    Debug.Log($"{menu} �޴� ����");
                    break;

                //�ش� �������� �ű��.
                case SlotMenu.Move:
                    Debug.Log($"{menu} �޴� ����");
                    break;

                //�ش� �������� ����Ѵ�.
                case SlotMenu.Use:
                    Debug.Log($"{menu} �޴� ����");
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
