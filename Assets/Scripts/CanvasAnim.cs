using UnityEngine;

public class CanvasAnim : MonoBehaviour
{
    public Animator buttonimator;

    void OnEnable()
    {
        buttonimator.SetTrigger("CanvasOpen"); 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
