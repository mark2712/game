using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Camera collided with {collision.gameObject.name}");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Camera triggered with {other.gameObject.name}");
    }
}