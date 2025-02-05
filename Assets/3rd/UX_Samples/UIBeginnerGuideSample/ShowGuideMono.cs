using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ShowGuideMono : MonoBehaviour 
{
    void Start(){
        //StartCoroutine("ok");
        var obj = transform.GetComponentInChildren<UIBeginnerGuideDataList>();
        UIBeginnerGuideManager.Instance.AddGuideList(obj);
        UIBeginnerGuideManager.Instance.ShowGuideList();
    }
    
    IEnumerator ok(){
        yield return new WaitForSeconds(0.5f);
        //UIBeginnerGuideManager.Instance.SetGuideID("MiddleGuide");
        UIBeginnerGuideManager.Instance.ShowGuideList();
    }
}