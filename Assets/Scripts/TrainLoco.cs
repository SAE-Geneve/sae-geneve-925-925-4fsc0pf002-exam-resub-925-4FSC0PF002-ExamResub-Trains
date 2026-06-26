using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class TrainLoco : MonoBehaviour
{
    private SplineAnimate _locoSpline;
    private SplineContainer _nextTrack;

    [SerializeField] private List<TrainCart> _carts;
    [SerializeField] private float _cart_length;

    //private void OnValidate() => SetCars();

    void OnEnable()
    {
        _locoSpline = GetComponent<SplineAnimate>();
        _locoSpline.Completed += OnCompletedTrack;
    }

    private void OnDisable()
    {
        _locoSpline.Completed -= OnCompletedTrack;
    }

    private void Update()
    {
        foreach (TrainCart cart in _carts)
        {
            UpdateCart(cart);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Junction passage))
        {
            if (passage.NextTrack)
            {
                _nextTrack = passage.NextTrack;
            }
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
        _locoSpline.Pause();
    }

    private void Brake()
    {
        _locoSpline.Play();
    }

    private void OnCompletedTrack()
    {
        // Set the track for every carts
        foreach (TrainCart cart in _carts)
        {
            if (cart.isActiveAndEnabled) cart.SetNextTrack(_nextTrack);
        }

        Debug.Log($"Loco Completed Track : {_locoSpline.gameObject.name} , Next Track : {_locoSpline.Container}");
        if (_nextTrack) _locoSpline.Container = _nextTrack;
        _locoSpline.StartOffset = 0;
        _locoSpline.NormalizedTime = 0f;
        _locoSpline.Play();
    }

    private void UpdateCart(TrainCart cart)
    {
        if (!cart.isActiveAndEnabled) return;
        if (_locoSpline.Container == cart.Container)
        {
            cart.NormalizedTime = Mathf.Clamp01(_locoSpline.NormalizedTime - cart.MaxSpeed * (_cart_length / cart.Container.CalculateLength()));
        }
    }
}