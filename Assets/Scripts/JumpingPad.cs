using UnityEngine;

public class JumpingPad : MonoBehaviour
{
    public float jumpHeight = 15;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = GetComponent<PlayerController>();
        if (player != null)
        {
            player.Jump(jumpHeight);

        }






        }
    }
