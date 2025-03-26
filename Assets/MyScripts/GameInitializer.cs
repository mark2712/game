using Player;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    PlayerController playerController;
    private States.MainStateManager mainStateManager;
    private InputController _inputController;
    private PlayerInputActions _inputActions;

    private void Awake()
    {

        playerController = GameContext.playerController;
        _inputActions = GameContext.inputActions;
        mainStateManager = GameContext.mainStateManager;
        _inputController = GameContext.inputController;

        // Начальное состояние
        mainStateManager.GoToStateEnter(States.MainStateManager.GetGameState());

        // Инициализация ввода
        _inputController.InitializeInput(_inputActions);
        _inputActions.Enable();

        playerController.Awake();
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
    }
    void FixedUpdate()
    {
        playerController.FixedUpdate();
        mainStateManager.FixedUpdate();
    }
    void Update()
    {
        playerController.Update();
        mainStateManager.UpdateState();
        mainStateManager.Update();
    }
    void LateUpdate()
    {
        playerController.LateUpdate();
        mainStateManager.LateUpdate();
        GameContext.emotionController.LateUpdate();
    }
}




public static class GameContext
{
    public static PlayerController playerController { get; }
    public static PlayerModelRotationSync playerModelRotationSync { get; }
    public static CamerasController camerasController { get; }
    public static CameraPlayerController cameraPlayerController { get; }
    public static PlayerAnimationController playerAnimationController { get; }
    public static UIManager uiManager { get; }
    public static States.MainStateManager mainStateManager { get; }
    public static InputController inputController { get; }
    public static PlayerInputActions inputActions { get; }
    public static EmotionController emotionController { get; }

    static GameContext()
    {
        GameObject player = GameObject.Find("Player");
        Transform playerModel = player.transform.Find("PlayerModel");
        GameObject playerCamera = GameObject.Find("PlayerCamera");
        GameObject uiManagerGameObject = GameObject.Find("UIManager");

        playerController = new GroundPlayerController(player);
        playerController.OnGroundChanged += isGround => { States.Flags.Ground = isGround; };
        playerController.OnMoveChanged += isMove => { States.Flags.Move = isMove; };

        playerModelRotationSync = playerModel.GetComponent<PlayerModelRotationSync>();

        camerasController = new();
        cameraPlayerController = new(playerCamera, camerasController);

        playerAnimationController = new(playerModel.GetChild(0));
        emotionController = new(playerModel.GetChild(0));

        uiManager = uiManagerGameObject.GetComponent<UIManager>();

        inputActions = new PlayerInputActions();
        mainStateManager = new();
        inputController = new InputController(mainStateManager);
        States.FlagsEvents flagsEvents = new(mainStateManager);
    }
}


