using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] float _pulseSize = 1.5f;
    [SerializeField] float _returnSpeed = 5f;
    private Vector3 _startSize;

    private void Start(){
        _startSize = transform.localScale;
    }

    void Update(){ // for smooth pulse movement of the object (선형 보간)
        transform.localScale = Vector3.Lerp(transform.localScale, _startSize, Time.deltaTime * _returnSpeed);
    }

    public void PulseinSize(){  //changing size of the object
        transform.localScale = _startSize * _pulseSize;
    }
}
