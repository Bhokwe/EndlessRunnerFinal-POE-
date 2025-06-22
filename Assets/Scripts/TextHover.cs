using UnityEngine;
using TMPro;
//using TextMeshPro;

public class TextHover : MonoBehaviour
{
    [SerializeField]
    public float hoverHeight = 0.5f; //how high? - up and down
    [SerializeField]
    public float hoverSpeed = 1.0f; // how fast?
    private Vector3 startPosition; //Where the object is starting, position-wise.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Y position calculation using sine wave
        //time.time for continuous movement
         float newY = startPosition.y + Mathf.Sin((Time.time)*hoverSpeed)*hoverHeight;

        //update object position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
