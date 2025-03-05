using UnityEngine;

public class PlayerModelRotationSync : MonoBehaviour
{
    private Transform player; // Ссылка на Transform игрока
    private Transform model; // Ссылка на модель игрока
    public float rotationSpeed = 10f; // Скорость вращения модели
    private Quaternion oldModelRotation;

    public void Awake()
    {
        player = transform.parent;
        model = transform;
        oldModelRotation = model.rotation;
    }

    void Update()
    {
        Quaternion playerRotation = player.rotation;
        model.rotation = Quaternion.Slerp(oldModelRotation, playerRotation, rotationSpeed * Time.deltaTime);
        oldModelRotation = model.rotation;
    }
}