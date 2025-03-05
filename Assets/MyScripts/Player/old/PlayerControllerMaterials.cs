using UnityEngine;

//удалить класс
public class PhysicsMaterialPlayer : MonoBehaviour
{
    private Collider playerCollider;     // Коллайдер персонажа
    private PhysicsMaterial defaultMaterial; // Стандартный физический материал
    private PhysicsMaterial _currentSurfaceMaterial;

    private void Start()
    {
        playerCollider = GetComponent<Collider>(); // Получаем коллайдер персонажа
        defaultMaterial = playerCollider.material; // Сохраняем стандартный физический материал
    }

    private void OnTriggerEnter(Collider other)
    {
        PhysicsMaterial currentSurfaceMaterial = other.sharedMaterial;
        if (currentSurfaceMaterial)
        {
            Debug.Log(currentSurfaceMaterial.name);
            _currentSurfaceMaterial = currentSurfaceMaterial;
            playerCollider.material = _currentSurfaceMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // // Когда персонаж выходит с поверхности, возвращаем стандартный физический материал
        // if (collision.gameObject.CompareTag("Ice") || collision.gameObject.CompareTag("Stone"))
        // {
        //     ResetMaterial();
        // }
    }
}