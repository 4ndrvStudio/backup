using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class EndAnimationTrigger : MonoBehaviour
{
    public RenderTool renderTool;
    public static Action EndAnimationEvent;
     public GameObject[] Vfx;
    public Volume _volume;

    public bool IsRecording;

    public bool IsChanged;



    private void Update() {
        
        if(IsRecording) {
            if(IsChanged) {
            _volume.weight = Mathf.Lerp( _volume.weight, 1f,10f * Time.deltaTime);
       } else _volume.weight = Mathf.Lerp( _volume.weight, 0f,5f * Time.deltaTime);
        }
    }
    

    public void OnEndAnimationTrigger() {
        
        EndAnimationEvent.Invoke();
        renderTool.StopRecord();
        StartCoroutine(StartRecord());
        
    }
    public void OnPlayVFX(int index) {
        if(IsRecording)  {
              Vfx[index].SetActive(true);
        }
       
    }
   
    public void OnStopVFX(int index) {
        if(IsRecording) 
        Vfx[index].SetActive(false);
    }
    
    public void OnChangeEnvi (int state) {
        if(IsRecording) 
        IsChanged = state == 1? true : false;
    }

    

    IEnumerator StartRecord() {
        yield return new WaitForSeconds(0.5f);
        renderTool.StartRecord();
    }
  

}
