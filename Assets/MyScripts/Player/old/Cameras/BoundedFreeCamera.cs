// using UnityEngine;

// public class BoundedFreeCamera : MonoBehaviour
// {
//     public float speed = 10f;
//     public Vector3 minBounds = new Vector3(-20, 0, -20);
//     public Vector3 maxBounds = new Vector3(20, 10, 20);

//     void Update()
//     {
//         float horizontal = Input.GetAxis("Horizontal");
//         float vertical = Input.GetAxis("Vertical");
//         float upDown = 0;

//         if (Input.GetKey(KeyCode.Space)) upDown = 1;
//         if (Input.GetKey(KeyCode.LeftControl)) upDown = -1;

//         Vector3 direction = new Vector3(horizontal, upDown, vertical);
//         Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

//         // Ограничение движения
//         newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
//         newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);
//         newPosition.z = Mathf.Clamp(newPosition.z, minBounds.z, maxBounds.z);

//         transform.position = newPosition;
//     }
// }