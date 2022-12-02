using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public interface IInteractable
{
    //static IInteractable CurClickedObj = null;


    public void Down()
    {

    }

    public void Up()
    {

    }

    public void OverLap()
    {

    }

    public void ClickUpdate()
    {

    }

    protected void OnHandHoverBegin(Hand hand)
    {
    }

    protected void OnHandHoverEnd(Hand hand)
    {
       
    }

    protected void HandHoverUpdate(Hand hand)
    {
        
    }


    //protected void OnHandHoverBegin(Hand hand)
    //{
    //    Debug.Log($"{GetType().Name}들러옴");
    //}

    //protected void OnHandHoverEnd(Hand hand)
    //{
    //    Debug.Log($"{GetType().Name}나감");
    //}

    //protected void HandHoverUpdate(Hand hand)
    //{
    //    Debug.Log($"{GetType().Name}업데이트");

    //    if (hand.GetGrabStarting() != GrabTypes.None)
    //    {
    //        CurClickedObj = this;
    //        if (CurClickedObj != null)
    //            CurClickedObj.Down();
    //    }



    //    if (hand.GetGrabEnding() != GrabTypes.None)
    //    {
    //        //IInteractable obj = GetClickedObj(hand.transform.position);
    //        //if (obj != null && obj == CurClickedObj)
    //        //    obj.Up();

    //        if (this == CurClickedObj)
    //            Up();

    //    }
    //}

}
