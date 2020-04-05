using UnityEngine;

public class PickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Picked up");
            Destroy(gameObject);
        }
    }
}
