using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class Junction : MonoBehaviour
{
    [Header("Tracks")]
    [Tooltip("Tracks and signals must be order-aligned to work together")]
    [SerializeField] private List<SplineContainer> _tracks;
    [SerializeField] private List<Signal> _signals;
    [SerializeField] private Transform _mainFlag;
    
    public SplineContainer NextTrack => _tracks[_nextTrackIdx];
    
    private Camera _camera;
    private SplineContainer _nextTrack;
    private int _nextTrackIdx = 0;
    
    void Start()
    {
        _camera = Camera.main;
        Signalize(_nextTrackIdx, true);
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            CheckRaycastClick();
    }

    private void CheckRaycastClick()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = _camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject == gameObject)
            {
                OnClicked();    
            }
        }
    }

    private void OnClicked()
    {
        Signalize(_nextTrackIdx, false);
        _nextTrackIdx++;

        if (_nextTrackIdx >= _tracks.Count) _nextTrackIdx = 0;
        Signalize(_nextTrackIdx, true);

        Debug.Log($"{gameObject.name} clicked — Next Track ? {_tracks[_nextTrackIdx]}");
    }

    private void Signalize(int signalIdx, bool isOn)
    {
        if(_signals.Count == 0) return;
        if(signalIdx >= _signals.Count) return;
        
        _signals[signalIdx].IsOn = isOn;
        if(isOn)
        {
            _mainFlag.LookAt(_signals[_nextTrackIdx].transform.position);
        }
    }
}
