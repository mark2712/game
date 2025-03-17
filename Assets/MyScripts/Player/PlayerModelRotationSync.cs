using UnityEngine;

public class PlayerModelRotationSync : MonoBehaviour
{
    private Transform syncObj; // объект игрока с которым синхронизируется вращение
    private Transform player; // Ссылка на Transform игрока
    private Transform playerMoveDeriction; // Ссылка на Transform StepOffsetContainer которая синхронизирует вращение с направлением движения
    private Transform model; // Ссылка на модель игрока
    public float rotationSpeed = 10f; // Скорость вращения модели
    private Quaternion oldModelRotation;

    // public PlayerModelRotationSync(Transform stepOffsetContainer, Transform player, Transform model)
    // {
    //     playerMoveDeriction = stepOffsetContainer;
    //     this.player = player;
    //     this.model = model;
    //     oldModelRotation = model.rotation;
    //     syncObj = player;
    // }

    public void Awake()
    {
        player = transform.parent;
        playerMoveDeriction = transform.parent.Find("StepOffsetContainer").transform;
        syncObj = player;
        model = transform;
        oldModelRotation = model.rotation;
    }

    public void Update()
    {
        model.rotation = Quaternion.Slerp(oldModelRotation, syncObj.rotation, rotationSpeed * Time.deltaTime);
        oldModelRotation = model.rotation;
    }

    public void MoveSync(bool on)
    {
        if (on)
        {
            syncObj = playerMoveDeriction;
        }
        else
        {
            syncObj = player;
        }
    }
}



// public PlayerModelRotationSync playerModelRotationSync;
// playerModelRotationSync = new(_stepOffsetContainer, player, playerModel);
