using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;

public class RenderTool : MonoBehaviour
{
    private RecorderWindow GetRecorderWindow()
    {
        return (RecorderWindow)EditorWindow.GetWindow(typeof(RecorderWindow));
    }
    RecorderWindow recorderWindow;
    RecorderControllerSettings recorderSettings;
    
    [SerializeField] private float time = 0;
    [SerializeField] private int numRendered= 0;

    public string NftName;
    public CharacterToggle _characterToggle;
    public EndAnimationTrigger _endAnim;


    // Start is called before the first frame update
    void Start()
    {
        recorderWindow = GetRecorderWindow();
    }
    void Update() {
        time += Time.time;
    }

    public void StartRecord()
    {   
         if(AutoRenderVideo.NumIndex >= 2000) {
            EditorApplication.ExitPlaymode();
            return;
         };
        recorderSettings =  recorderWindow.GetRecorderControllerSettings4ndrv();
        //recorderSettings.GetRecorderSettings4ndrv()[0].FileNameGenerator.FileName = name;
          recorderSettings.GetRecorderSettings4ndrv()[0].FileNameGenerator.FileName = NftName;
         // recorderSettings.GetRecorderSettings4ndrv()[i].FileNameGenerator.FileName = nftsName[i];
        
        Debug.Log("Starender");
        _characterToggle.PlayAnimationListener();
        _endAnim.IsRecording = true;
        recorderWindow.StartRecording();
      
    }
    public void StopRecord() {
        AutoRenderVideo.NumIndex +=1;
        numRendered+=1;
        Debug.Log("StopRender");
         _endAnim.IsRecording = false;
        recorderWindow.StopRecording();
    }
    
    
//     public RecorderControllerSettings GetRecorderControllerSettings4ndrv() {
//             return m_ControllerSettings;
//         }

//  public List<RecorderSettings> GetRecorderSettings4ndrv() {
//             return m_RecorderSettings;
//         }

    
}
