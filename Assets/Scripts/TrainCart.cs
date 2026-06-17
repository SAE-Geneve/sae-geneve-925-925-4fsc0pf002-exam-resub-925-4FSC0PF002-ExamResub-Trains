using UnityEngine;
using UnityEngine.Splines;

public class TrainCart : MonoBehaviour
{
    
    private SplineAnimate _splineAnim;
    private SplineContainer _nextTrack;
    
    public SplineContainer NextTrack => _nextTrack;
    public SplineAnimate SplineAnim => _splineAnim;

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
            if(passage.NextTrack)
            {
                _nextTrack = passage.NextTrack;
            }
        }
    }

    private void OnCompletedTrack()
    {
        if(_nextTrack) _splineAnim.Container = _nextTrack;
        
        Debug.Log($"Loco Completed Track : {_splineAnim.gameObject.name} , Next Track : {_splineAnim.Container}");
        _splineAnim.NormalizedTime = 0f;
        _splineAnim.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
