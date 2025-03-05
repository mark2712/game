using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float movementSpeed = 5f;       // Скорость перемещения
    public float boostMultiplier = 2f;    // Ускорение при Shift
    public float rotationSpeed = 100f;    // Скорость поворота (мышь)
    public float verticalSpeed = 3f;      // Скорость вертикального движения (Ctrl/Space)
    private float verticalRotation = 0f;


    private Vector3 _inputDirection;      // Направление движения
    private float _boost;                 // Множитель ускорения

    // void Update()
    // {
    //     HandleMovementInput();
    //     HandleMouseLook();
    // }

    // Обрабатываем движение камеры
    private void HandleMovementInput()
    {
        // WASD или стрелки для горизонтального движения
        float horizontal = Input.GetAxis("Horizontal"); // A/D или ←/→
        float vertical = Input.GetAxis("Vertical");     // W/S или ↑/↓

        // Вверх/вниз (Space / Ctrl)
        float upDown = 0f;
        if (Input.GetKey(KeyCode.Space))
            upDown += 1f;
        if (Input.GetKey(KeyCode.LeftControl))
            upDown -= 1f;

        // Считываем ввод
        _inputDirection = new Vector3(horizontal, upDown * verticalSpeed, vertical);

        // Ускорение при удерживании Shift
        _boost = Input.GetKey(KeyCode.LeftShift) ? boostMultiplier : 1f;

        // Перемещаем камеру
        transform.Translate(_inputDirection * movementSpeed * _boost * Time.deltaTime, Space.Self);
    }

    // Обрабатываем вращение камеры
    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Ограничиваем вертикальное вращение
        verticalRotation = Mathf.Clamp(verticalRotation - mouseY, -90f, 90f);

        // Вращение по горизонтали
        transform.Rotate(Vector3.up, mouseX, Space.World);

        // Вращение по вертикали
        transform.localEulerAngles = new Vector3(verticalRotation, transform.localEulerAngles.y, 0f);
    }
}