using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRenderVideo : MonoBehaviour
{
    [SerializeField] private ReadCSV _readCSV;
    [SerializeField] private RenderTool _renderTool;
    public static string[] Data;
    public static bool CanRender = false;
    public static int NumIndex = 0;
    
    void Start() {
        StartCoroutine(GetData());
    }

    IEnumerator GetData() {
        yield return new WaitUntil( () => _readCSV.Data.Length != 0);
        Data = _readCSV.Data;
        CanRender = true;
    }

}
