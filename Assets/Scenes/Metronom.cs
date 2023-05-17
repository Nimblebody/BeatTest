using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Metronom : MonoBehaviour
{
    // 기본 이론
    // 60sec / 120 bpm = 0.5 sec per beat
    // frequency x 0.5 = new beat
    // current sample time / new beat = elapsed beats at 120 bpm

    [SerializeField]  float _bpm;
    [SerializeField] AudioSource _audio;
    [SerializeField] Interval[] _beat;

    private void Update(){
        foreach(Interval interval in _beat){
            //비트간 시간 변화 감지를 위한 변수
            float sampledtime = (_audio.timeSamples) / (_audio.clip.frequency * interval.GetBeatLength(_bpm));
            //시간변화 확인 / new beat 감지
            interval.CheckForNewInterval(sampledtime);
        }
    }
}

[System.Serializable]
public class Interval{
    [SerializeField] float _beatPerTime;
    [SerializeField] UnityEvent _trigger;
    int _lastBeat;

    public float GetBeatLength(float bpm){ // 노래 박자값 계산
        return 60f / (bpm * _beatPerTime);
    }

    public void CheckForNewInterval (float beat){
        if(Mathf.FloorToInt(beat) != _lastBeat){ //비트 변화 확인. True라면 변화 저장
            _lastBeat = Mathf.FloorToInt(beat);
            _trigger.Invoke();
        }
    }
}
