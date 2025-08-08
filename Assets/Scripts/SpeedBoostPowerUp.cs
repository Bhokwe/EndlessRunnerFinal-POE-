using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("SpeedBoost");

            Destroy(gameObject);
        }
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.IncreaseSpeed(2f, 5f);
        }
    }
}
