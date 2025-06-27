using UnityEngine;
using Entities;

public class TestMagic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, есть ли у объекта компонент BaseEntity
        BaseEntity entity = other.GetComponent<BaseEntity>();

        if (entity != null) // Если это сущность
        {
            Debug.Log($"Заклинание активировано на сущности: {entity.name}");
            entity.ReceiveDamage(10f);
        }
    }
}