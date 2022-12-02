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
            //�������� �����ؼ� ����ٴϴ��� �̸� 
            //���� ���콺 ��ġ���� ���̸����� IInteractable ��ü�� �־������ �ش� ��ġ�� �̵� �����ϵ��� ���ش�.
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
