using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    PlayerController playerController;
    // CamerasController camerasController;
    // CameraPlayerController cameraPlayerController;

    private GameStateManager gameStateManager;
    private MoveStateManager _moveStateManager;
    private InputController _inputController;
    private PlayerInputActions _inputActions;

    private void Awake()
    {

        playerController = GameContext.playerController;
        // camerasController = GameContext.camerasController;
        // cameraPlayerController = GameContext.cameraPlayerController;
        // uiManager = GameContext.uiManager;

        _inputActions = GameContext.inputActions;
        gameStateManager = GameContext.gameStateManager;
        _moveStateManager = GameContext.moveStateManager;
        _inputController = GameContext.inputController;

        // Начальное состояние
        gameStateManager.GoToStateEnter(new StandState());

        // Инициализация ввода
        _inputController.InitializeInput(_inputActions);
        _inputActions.Enable();

        playerController.Awake();
    }

    public void Start() { Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false; }

    void Update()
    {
        playerController.Update();
        gameStateManager.Update();
    }
    // void LateUpdate()
    // {
    //     playerController.LateUpdate();
    // }
    void FixedUpdate()
    {
        playerController.FixedUpdate();
        gameStateManager.FixedUpdate();
    }
}




public static class GameContext
{
    public static PlayerController playerController { get; }
    public static CamerasController camerasController { get; }
    public static CameraPlayerController cameraPlayerController { get; }
    public static UIManager uiManager { get; }
    public static GameStateManager gameStateManager { get; }
    public static MoveStateManager moveStateManager { get; }
    public static InputController inputController { get; }
    public static PlayerInputActions inputActions { get; }

    static GameContext()
    {
        GameObject player = GameObject.Find("Player");
        GameObject playerCamera = GameObject.Find("PlayerCamera");
        GameObject uiManagerGameObject = GameObject.Find("UIManager");

        playerController = new(player);
        camerasController = new();
        cameraPlayerController = new(playerCamera, camerasController);

        uiManager = uiManagerGameObject.GetComponent<UIManager>();

        inputActions = new PlayerInputActions();
        gameStateManager = new();
        moveStateManager = new();
        inputController = new InputController(gameStateManager);
    }
}





// public static class ServiceLocator
// {
//     private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

//     // Регистрация сервиса по типу
//     public static T Register<T>(T service)
//     {
//         _services[typeof(T)] = service;
//         return service;
//     }

//     // Получение сервиса по типу
//     public static T Get<T>()
//     {
//         if (_services.TryGetValue(typeof(T), out var service))
//         {
//             return (T)service;
//         }
//         throw new InvalidOperationException($"Service of type {typeof(T)} is not registered.");
//     }

//     // Проверка, зарегистрирован ли сервис
//     public static bool IsRegistered<T>()
//     {
//         return _services.ContainsKey(typeof(T));
//     }
// }




// public class GameContext
// {
//     public static GameContext self;
//     public PlayerController playerController { get; }
//     public CamerasController camerasController { get; }
//     public CameraPlayerController cameraPlayerController { get; }
//     public GameObject UIManagerGameObject { get; }
//     public UIManager UIManager { get; }
//     public MoveStateManager moveStateManager { get; }

//     public GameContext(PlayerController playerController, CamerasController camerasController, CameraPlayerController cameraPlayerController, GameObject UIManager)
//     {
//         self = this;
//         this.playerController = playerController;
//         this.camerasController = camerasController;
//         this.cameraPlayerController = cameraPlayerController;
//         UIManagerGameObject = UIManager;
//         this.UIManager = UIManager.GetComponent<UIManager>();
//     }
// }






// public class DIContainer
// {
//     private readonly Dictionary<Type, object> _registrations = new Dictionary<Type, object>();
//     private readonly Dictionary<Type, Func<object>> _factories = new Dictionary<Type, Func<object>>();

//     // Регистрация экземпляра
//     public void Register<T>(T instance)
//     {
//         _registrations[typeof(T)] = instance;
//     }

//     // Регистрация фабрики для создания экземпляра
//     public void Register<T>(Func<T> factory)
//     {
//         _factories[typeof(T)] = () => factory();
//     }

//     // Получение экземпляра
//     public T Resolve<T>()
//     {
//         if (_registrations.TryGetValue(typeof(T), out var instance))
//         {
//             return (T)instance;
//         }

//         if (_factories.TryGetValue(typeof(T), out var factory))
//         {
//             return (T)factory();
//         }

//         throw new InvalidOperationException($"No registration or factory found for type {typeof(T)}");
//     }
// }


