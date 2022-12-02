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
        //Debug.Log("ItemBox들러옴");

    }

    //손이 해당 그림영역에서 나가면 손을 뗀것처럼 동작
    protected void OnHandHoverEnd(Hand hand)
    {
        //Debug.Log("ItemBox나감");
    }

    //그림영역 안에서 마우스가 움직일때
    protected void HandHoverUpdate(Hand hand)
    {
        ////Debug.Log("ItemBox움직이는중");
        ////그림영역 안에서 그랩 버튼이 눌리면 
        //if (hand.GetGrabStarting() != GrabTypes.None)
        //{
        //    CurClickedObj = GetClickedObj(hand.transform.position);
        //    if (CurClickedObj != null)
        //        CurClickedObj.Down();
        //}

        ////그랩을 뗐을떄는 현재 운반하고 있는 아이템이 있는지 확인하고 
        ////있으면 해당 위치에 슬롯이 있는지 없는지에 따라 움직여준다.
        ////현재 운반하고 있는 아이템이 있지만 같은 슬롯 위에서면 아이템을 장착시키거나 사용해준다.

        //if (hand.GetGrabEnding() != GrabTypes.None)
        //{
        //    IInteractable obj = GetClickedObj(hand.transform.position);
        //    if (obj != null && obj == CurClickedObj)
        //        obj.Up();
        //}
    }

    //해당 방향으로 레이를 쏴서 클릭된 UI 요소들을 찾아내도록 해준다.
    

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

    //클릭된 공간에 슬롯이 있으면 슬롯을 선택한걸로 해준다.
    //클릭된 공간에 슬롯메뉴가 있으면 슬롯메뉴를 우선으로 선택해서 넘겨준다.
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
                    //Debug.Log("ItemSlot눌림 감지");
                    interactables.Add(obj);
                }

                else if (obj.GetType() == typeof(ItemSlotMenu))
                {
                    Debug.Log("ItemSlotMenu 눌림 감지");
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

//    //라인의 두께
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

//    //라인의 색깔
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

//    //현재 grab버튼이 눌렸는지
//    #region Grabbing
//    public bool grabbing = false;

//    //그랩이 들어오면 처음 들어온 위치를 LineRenderer
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
//                //그랩버튼이 눌리면 라인을 하나 생성해준다.
//                temp = GameObject.Instantiate<LineRenderer>(Resources.Load<LineRenderer>("Prefabs/Line"));
//                //형재 설정되어있는 두께와 색깔을 지정해준다.
//                temp.startColor = CurColor;
//                temp.endColor = CurColor;
//                temp.startWidth = Thickness;
//                temp.endWidth = Thickness;
//            }
//            else
//            {
//                //그랩버튼으 끝나면 linelist에 만들어진 라인을 넣어준다.
//                linelist.Add(temp);
//                temp = null;
//            }
//            grabbing = value;
//        }

//    }
//    #endregion

//    //현재 그려진 라인들
//    public List<LineRenderer> linelist = new List<LineRenderer>();


//    //손이 해당 그림영역에서 나가면 손을 뗀것처럼 동작
//    protected void OnHandHoverEnd(Hand hand)
//    {
//        Debug.Log("그랩나감");

//        if (Grabbing)
//            Grabbing = false;
//    }

//    //라인의 정점을 기록할 간격 0.1초
//    public float RecordInterval;
//    private float LastRecord;

//    //정점의 정보 list
//    public List<Vector3> mouseList = new List<Vector3>();

//    //그림영역 안에서 마우스가 움직일때
//    protected void HandHoverUpdate(Hand hand)
//    {
//        //그림영역 안에서 그랩 버튼이 눌리면 
//        if (hand.GetGrabStarting() != GrabTypes.None)
//        {
//            //임시 정점정보 list를 초기화 해주고 
//            mouseList.Clear();
//            //grabbing을 true로 바꿔서 새로운 라인을 만들어 준다.
//            Grabbing = true;
//            //시작 정점정보를 라인렌더러에 넣어준다.
//            mouseList.Add(hand.gameObject.transform.position);
//            temp.positionCount = mouseList.Count;
//            temp?.SetPositions(mouseList.ToArray());

//            //temp.GetPositions()
//        }


//        if (Grabbing/*hand.GetBestGrabbingType() != GrabTypes.None*/)
//        {
//            //일정 시간마다 해당 마우스의 위치를 라인 렌더러의 정점정보에 추가 해준다.
//            if (Time.time - LastRecord >= RecordInterval)
//            {
//                LastRecord = Time.time;

//                mouseList.Add(hand.gameObject.transform.position);
//                temp.positionCount = mouseList.Count;
//                temp?.SetPositions(mouseList.ToArray());

//            }

//        }


//        //그랩을 뗐을때
//        if (hand.GetGrabEnding() != GrabTypes.None)
//        {
//            //정점정보를 넣어주고
//            mouseList.Add(hand.gameObject.transform.position);
//            temp.positionCount = mouseList.Count;
//            temp?.SetPositions(mouseList.ToArray());
//            //linelist에 현재 라인정보를 넣어준다.
//            Grabbing = false;

//            //lineRenderer.SetPosition(1, hand.gameObject.transform.position);
//        }
//    }

//    //라인정보 저장 
//    public void LineInfoSave()
//    {
//        DataSaveLoader.Save(linelist);
//    }
//    //
//    public List<string> testdata;

//    //라인정보 불러오기
//    public void LineInfoLoad()
//    {
//        List<Dictionary<int, string>> data = DataSaveLoader.Read();

//        foreach (var a in data)
//        {
//            LineRenderer temp = GameObject.Instantiate<LineRenderer>(Resources.Load<LineRenderer>("Prefabs/Line"));

//            //두께정보
//            temp.startWidth = float.Parse(a[0]);
//            temp.endWidth = float.Parse(a[0]);
//            testdata.Add(a[0]);

//            //색상정보
//            string[] varr = a[1].Split(",");
//            Color color = new Color(float.Parse(varr[0]), float.Parse(varr[1]), float.Parse(varr[2]));
//            temp.startColor = color;
//            temp.endColor = color;

//            temp.positionCount = a.Count - 2;
//            testdata.Add(a[1]);

//            //정점정보
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
//        Debug.Log("버튼클릭");
//    }

//}
