using UnityEngine;

public class Signal : MonoBehaviour
{
    
    [SerializeField] private Animator _animator;
    public bool IsOn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("IsOn", IsOn);
    }
}
