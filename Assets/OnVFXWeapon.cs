using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnVFXWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _vfx;
    [SerializeField] private GameObject _combineVFX;
    [SerializeField] private float _startTime =4f;
    [SerializeField] private float _time = 4f;
    [SerializeField] private float _enableTime1 = 0.8f;
    [SerializeField] private float _enableTime2 = 2f;

    void OnEnable() {
        _time = _startTime;
    }
    // Start is called before the first frame update
    void Update() {
        _time-= Time.deltaTime;
        if(_time <=0f) _time= _startTime;
        bool check1 = _time <= _enableTime1 ? true: false;
        bool check2 = _time <= _enableTime2 ? true: false;

        _vfx.SetActive(check1);
        _combineVFX.SetActive(check2);
    }
}
