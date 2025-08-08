using Unity.VisualScripting;
using UnityEngine;

public class JumpingPad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("jumpPad");

            
        }
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SuperJump( 10f, 3f);
        }

        Destroy(gameObject);





    }
}
