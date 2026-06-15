using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class RedLight : MonoBehaviour
{
    private Camera _camera;
    private bool _isGreen = true;

    public bool IsGreen => _isGreen;
    public UnityEvent IsGreenEvent;
    public UnityEvent IsRedEvent;

    void Start()
    {
        _camera = Camera.main;
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
            if (hit.collider.gameObject == this.gameObject)
            {
                OnClicked();
            }
        }
    }

    private void OnClicked()
    {
        _isGreen = !_isGreen;
        Debug.Log($"{gameObject.name} clicked — IsGreen ? {_isGreen}");
        if (_isGreen)
        {
            IsGreenEvent.Invoke();
        }
        else
        {
            IsRedEvent.Invoke();
        }
    }
}