using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Splines;

public class TrainCart : MonoBehaviour
{
    private SplineAnimate _splineAnim;
    public SplineContainer _nextTrack;

    public float NormalizedTime
    {
        get
        {
            if (_splineAnim)
                return _splineAnim.NormalizedTime;
            return 0f;
        }
        set
        {
            if (_splineAnim)
                _splineAnim.NormalizedTime = value;
        }
    }
    public float MaxSpeed => _splineAnim ? _splineAnim.MaxSpeed : 0f;
    public SplineContainer Container => _splineAnim ?  _splineAnim.Container : null;
    public void Play() => _splineAnim.Play();


    void OnEnable()
    {
        _splineAnim = GetComponent<SplineAnimate>();
        _splineAnim.Play();
        _splineAnim.Completed += OnCompletedTrack;
    }

    private void OnDisable()
    {
        _splineAnim.Completed -= OnCompletedTrack;
    }

    // Update is called once per frame

    public void SetNextTrack(SplineContainer nextTrack)
    {
        _nextTrack = nextTrack;
    }

    private void OnCompletedTrack()
    {
        if (_nextTrack)
        {
            _splineAnim.Container = _nextTrack;
        }

        _splineAnim.NormalizedTime = 0f;
        _splineAnim.Play();
    }
}