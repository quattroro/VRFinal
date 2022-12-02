using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ItemBox : MonoBehaviour
{
    public BaseSlot SlotObj;

    public BaseSlot[] itemSlots;

    public IInteractable curClickedObj = null;

    public IInteractable CurClickedObj
    {
        get
        {
            return curClickedObj;
        }
        set
        {
            if (curClickedObj != null && curClickedObj != value)
                curClickedObj.Up();

            curClickedObj = value;
        }

    }

    public bool IsMouseEnter;

    public int MaxX;
    public int MaxY;
    public float PaddingX;
    public float PaddingY;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        itemSlots = new BaseSlot[MaxX * MaxY];

        for (int x = 0; x < MaxX; x++)
        {
            for (int y = 0; y < MaxY; y++)
            {
                if (x == 0 && y == 0)
                    itemSlots[x + y] = SlotObj;
                else
                {
                    BaseSlot obj = Instantiate<BaseSlot>(SlotObj);
                    obj.transform.parent = SlotObj.transform.parent;
                    obj.transform.rotation = SlotObj.transform.rotation;
                    obj.transform.localScale = SlotObj.transform.localScale;

                    obj.gameObject.transform.localPosition = new Vector3(SlotObj.transform.localPosition.x - (PaddingY * y), SlotObj.transform.localPosition.y, SlotObj.transform.localPosition.z + (PaddingX * x));
                    itemSlots[x + (y * MaxX)] = obj;
                }
            }
        }

        for(int i=0;i< itemSlots.Length;i++)
        {
            itemSlots[i].SetItem(ItemManager.Instance.GetItemInfo(ItemType.EQUIP));
        }

    }


    protected void OnHandHoverBegin(Hand hand)
    {
        //Debug.Log("ItemBox�鷯��");

    }

    //���� �ش� �׸��������� ������ ���� ����ó�� ����
    protected void OnHandHoverEnd(Hand hand)
    {
        //Debug.Log("ItemBox����");
    }

    //�׸����� �ȿ��� ���콺�� �����϶�
    protected void HandHoverUpdate(Hand hand)
    {
        ////Debug.Log("ItemBox�����̴���");
        ////�׸����� �ȿ��� �׷� ��ư�� ������ 
        //if (hand.GetGrabStarting() != GrabTypes.None)
        //{
        //    CurClickedObj = GetClickedObj(hand.transform.position);
        //    if (CurClickedObj != null)
        //        CurClickedObj.Down();
        //}

        ////�׷��� �������� ���� ����ϰ� �ִ� �������� �ִ��� Ȯ���ϰ� 
        ////������ �ش� ��ġ�� ������ �ִ��� �������� ���� �������ش�.
        ////���� ����ϰ� �ִ� �������� ������ ���� ���� �������� �������� ������Ű�ų� ������ش�.

        //if (hand.GetGrabEnding() != GrabTypes.None)
        //{
        //    IInteractable obj = GetClickedObj(hand.transform.position);
        //    if (obj != null && obj == CurClickedObj)
        //        obj.Up();
        //}
    }

    //�ش� �������� ���̸� ���� Ŭ���� UI ��ҵ��� ã�Ƴ����� ���ش�.
    

    public List<IInteractable> GetClickedObjs(Vector3 pos)
    {
        Vector3 dir = pos - GameManager.Instance.GetCamera().transform.position;
        dir.Normalize();
        RaycastHit[] hit;
        IInteractable obj = null;
        hit = Physics.RaycastAll(pos, dir, 100);

        List<IInteractable> interactables = new List<IInteractable>();

        for (int i=0;i<hit.Length;i++)
        {
            obj = hit[i].transform.gameObject.GetComponent<IInteractable>();

            if(obj != null)
            {
                interactables.Add(obj);
            }
        }

        return interactables;
    }

    public int count = 0;

    //Ŭ���� ������ ������ ������ ������ �����Ѱɷ� ���ش�.
    //Ŭ���� ������ ���Ը޴��� ������ ���Ը޴��� �켱���� �����ؼ� �Ѱ��ش�.
    public IInteractable GetClickedObj(Vector3 pos)
    {
        count++;
        Vector3 dir = pos - GameManager.Instance.GetCamera().transform.position;
        dir.Normalize();
        RaycastHit[] hit;
        IInteractable obj = null;
        hit = Physics.RaycastAll(pos, dir, 100);

        List<IInteractable> interactables = new List<IInteractable>();

        for (int i = 0; i < hit.Length; i++)
        {
            obj = hit[i].transform.gameObject.GetComponent<IInteractable>();

            if (obj != null)
            {
                if (obj.GetType() == typeof(ItemSlot))
                {
                    //Debug.Log("ItemSlot���� ����");
                    interactables.Add(obj);
                }

                else if (obj.GetType() == typeof(ItemSlotMenu))
                {
                    Debug.Log("ItemSlotMenu ���� ����");
                    return obj;
                }
            }

        }


        if(interactables.Count<=0)
        {
            return null;
        }

        return interactables[0];
    }

}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR;
//using Valve.VR.InteractionSystem;

//public class WhiteBoard : Singleton<WhiteBoard>
//{
//    public LineRenderer lineOBJ;
//    LineRenderer temp = null;
//    public SteamVR_Action_Boolean GrapClick = SteamVR_Input.GetBooleanAction("Grab");

//    //������ �β�
//    #region Thickness
//    public float thickness;
//    public float Thickness
//    {
//        get
//        {
//            return thickness;
//        }
//        set
//        {
//            thickness = value;
//        }
//    }
//    #endregion

//    //������ ����
//    #region Color
//    public Color curColor;
//    public Color CurColor
//    {
//        get
//        {
//            return curColor;
//        }
//        set
//        {
//            curColor = value;
//        }
//    }

//    #endregion

//    //���� grab��ư�� ���ȴ���
//    #region Grabbing
//    public bool grabbing = false;

//    //�׷��� ������ ó�� ���� ��ġ�� LineRenderer
//    public bool Grabbing
//    {
//        get
//        {
//            return grabbing;
//        }
//        set
//        {
//            if (value)
//            {
//                //�׷���ư�� ������ ������ �ϳ� �������ش�.
//                temp = GameObject.Instantiate<LineRenderer>(Resources.Load<LineRenderer>("Prefabs/Line"));
//                //���� �����Ǿ��ִ� �β��� ������ �������ش�.
//                temp.startColor = CurColor;
//                temp.endColor = CurColor;
//                temp.startWidth = Thickness;
//                temp.endWidth = Thickness;
//            }
//            else
//            {
//                //�׷���ư�� ������ linelist�� ������� ������ �־��ش�.
//                linelist.Add(temp);
//                temp = null;
//            }
//            grabbing = value;
//        }

//    }
//    #endregion

//    //���� �׷��� ���ε�
//    public List<LineRenderer> linelist = new List<LineRenderer>();


//    //���� �ش� �׸��������� ������ ���� ����ó�� ����
//    protected void OnHandHoverEnd(Hand hand)
//    {
//        Debug.Log("�׷�����");

//        if (Grabbing)
//            Grabbing = false;
//    }

//    //������ ������ ����� ���� 0.1��
//    public float RecordInterval;
//    private float LastRecord;

//    //������ ���� list
//    public List<Vector3> mouseList = new List<Vector3>();

//    //�׸����� �ȿ��� ���콺�� �����϶�
//    protected void HandHoverUpdate(Hand hand)
//    {
//        //�׸����� �ȿ��� �׷� ��ư�� ������ 
//        if (hand.GetGrabStarting() != GrabTypes.None)
//        {
//            //�ӽ� �������� list�� �ʱ�ȭ ���ְ� 
//            mouseList.Clear();
//            //grabbing�� true�� �ٲ㼭 ���ο� ������ ����� �ش�.
//            Grabbing = true;
//            //���� ���������� ���η������� �־��ش�.
//            mouseList.Add(hand.gameObject.transform.position);
//            temp.positionCount = mouseList.Count;
//            temp?.SetPositions(mouseList.ToArray());

//            //temp.GetPositions()
//        }


//        if (Grabbing/*hand.GetBestGrabbingType() != GrabTypes.None*/)
//        {
//            //���� �ð����� �ش� ���콺�� ��ġ�� ���� �������� ���������� �߰� ���ش�.
//            if (Time.time - LastRecord >= RecordInterval)
//            {
//                LastRecord = Time.time;

//                mouseList.Add(hand.gameObject.transform.position);
//                temp.positionCount = mouseList.Count;
//                temp?.SetPositions(mouseList.ToArray());

//            }

//        }


//        //�׷��� ������
//        if (hand.GetGrabEnding() != GrabTypes.None)
//        {
//            //���������� �־��ְ�
//            mouseList.Add(hand.gameObject.transform.position);
//            temp.positionCount = mouseList.Count;
//            temp?.SetPositions(mouseList.ToArray());
//            //linelist�� ���� ���������� �־��ش�.
//            Grabbing = false;

//            //lineRenderer.SetPosition(1, hand.gameObject.transform.position);
//        }
//    }

//    //�������� ���� 
//    public void LineInfoSave()
//    {
//        DataSaveLoader.Save(linelist);
//    }
//    //
//    public List<string> testdata;

//    //�������� �ҷ�����
//    public void LineInfoLoad()
//    {
//        List<Dictionary<int, string>> data = DataSaveLoader.Read();

//        foreach (var a in data)
//        {
//            LineRenderer temp = GameObject.Instantiate<LineRenderer>(Resources.Load<LineRenderer>("Prefabs/Line"));

//            //�β�����
//            temp.startWidth = float.Parse(a[0]);
//            temp.endWidth = float.Parse(a[0]);
//            testdata.Add(a[0]);

//            //��������
//            string[] varr = a[1].Split(",");
//            Color color = new Color(float.Parse(varr[0]), float.Parse(varr[1]), float.Parse(varr[2]));
//            temp.startColor = color;
//            temp.endColor = color;

//            temp.positionCount = a.Count - 2;
//            testdata.Add(a[1]);

//            //��������
//            for (int i = 2; i < a.Count; i++)
//            {
//                varr = a[i].Split(",");
//                Vector3 vector = new Vector3(float.Parse(varr[0]), float.Parse(varr[1]), float.Parse(varr[2]));
//                temp.SetPosition(i - 2, vector);
//                testdata.Add(a[i]);
//            }
//            linelist.Add(temp);
//        }

//    }

//    public void Clear()
//    {
//        foreach (var a in linelist)
//        {
//            GameObject.Destroy(a.gameObject);
//        }
//        linelist.Clear();
//    }

//    public void Btn_Click()
//    {
//        Debug.Log("��ưŬ��");
//    }

//}
