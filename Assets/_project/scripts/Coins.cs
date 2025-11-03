using UnityEngine;

public class coion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.CollectCoin(); // Increment the coin count and update UI
            }
            Destroy(gameObject);
        }
    }
}
