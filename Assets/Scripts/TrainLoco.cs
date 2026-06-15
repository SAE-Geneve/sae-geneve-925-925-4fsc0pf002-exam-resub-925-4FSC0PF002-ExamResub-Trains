using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

[ExecuteInEditMode]
public class TrainLoco : MonoBehaviour
{

    private SplineAnimate _splineAnim;
    private SplineContainer _nextTrack;
    
    public SplineContainer NextTrack => _nextTrack;
    public SplineAnimate SplineAnim => _splineAnim;

    //private void OnValidate() => SetCars();

    void OnEnable()
    {
        _splineAnim = GetComponent<SplineAnimate>();
        _splineAnim.Completed += OnCompletedTrack; 
    }
    private void OnDisable()
    {
        _splineAnim.Completed -= OnCompletedTrack;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Junction passage))
        {
            _nextTrack = passage.NextTrack;
        }

        if (other.CompareTag("TrainStopper"))
        {
            if (other.transform.parent.TryGetComponent(out RedLight redLight))
            {
                if (redLight.IsGreen) Brake();
                else Ride();
            }
        }
    }

    private void Ride()
    {
        _splineAnim.Pause();
    }

    private void Brake()
    {
        _splineAnim.Play();
    }

    private void OnCompletedTrack()
    {
        if(_nextTrack) _splineAnim.Container = _nextTrack;
        
        Debug.Log($"Loco Completed Track : {_splineAnim.gameObject.name} , Next Track : {_splineAnim.Container}");
        _splineAnim.NormalizedTime = 0f;
        _splineAnim.Play();
    }


}
