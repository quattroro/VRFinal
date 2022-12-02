using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    public Camera mainCam;

    public Camera GetCamera()
    {
        return mainCam;
    }

    public BaseItem ClickedItem = null;

    private void Update()
    {
        if(ClickedItem!=null)
        {
            //아이템을 선택해서 끌고다니는중 이면 
            //현재 마우스 위치에서 레이를쏴서 IInteractable 객체가 있어야지만 해당 위치로 이동 가능하도록 해준다.
            Ray ray = GetCamera().ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit = Physics.RaycastAll(ray);


            for(int i=0;i<hit.Length;i++)
            {
                IInteractable iinteract;
                iinteract = hit[i].transform.GetComponent<IInteractable>();
                if(iinteract!=null)
                {
                    ClickedItem.transform.position = hit[i].transform.position + new Vector3(0.1f,0 , 0);
                }
            }

            
        }
    }


}
