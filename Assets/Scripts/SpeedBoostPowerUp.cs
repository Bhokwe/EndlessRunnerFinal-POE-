using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Destroy(gameObject);
        }
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.IncreaseSpeed(2f, 5f);
        }
    }
}
