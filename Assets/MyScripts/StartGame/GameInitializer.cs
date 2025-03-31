using Player;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    PlayerController playerController;
    private States.StateManager mainStateManager;
    private States.HandsStateManager handsStateManager;
    private InputController _inputController;
    private PlayerInputActions _inputActions;

    private void Awake()
    {
        playerController = GameContext.playerController;
        _inputActions = GameContext.inputActions;
        mainStateManager = GameContext.mainStateManager;
        handsStateManager = GameContext.handsStateManager;
        _inputController = GameContext.inputController;

        // Начальное состояние
        handsStateManager.GoToStateEnter(new States.HandsStateTest1());
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
    public static InputController inputController { get; }
    public static PlayerInputActions inputActions { get; }
    public static EmotionController emotionController { get; }

    public static States.StateManager mainStateManager { get; }
    public static States.HandsStateManager handsStateManager { get; }
    public static States.RightHandStateManager rightHandStateManager { get; }
    public static States.LeftHandStateManager leftHandStateManager { get; }
    public static States.ModalStateManager modalStateManager { get; }

    static GameContext()
    {
        GameObject player = GameObject.Find("Player");
        Transform playerModel = player.transform.Find("PlayerModel");
        PlayerModelVRM playerModelVRM = new(playerModel);
        GameObject playerCamera = GameObject.Find("PlayerCamera");
        GameObject uiManagerGameObject = GameObject.Find("UIManager");

        playerController = new GroundPlayerController(player);
        playerController.OnGroundChanged += isGround => { States.Flags.Ground = isGround; };
        playerController.OnMoveChanged += isMove => { States.Flags.Move = isMove; };

        playerModelRotationSync = playerModel.GetComponent<PlayerModelRotationSync>();

        camerasController = new();
        cameraPlayerController = new(playerCamera, camerasController);

        playerAnimationController = new(playerModelVRM.model);
        emotionController = new(playerModelVRM.model);

        uiManager = uiManagerGameObject.GetComponent<UIManager>();

        inputActions = new PlayerInputActions();
        mainStateManager = new();
        inputController = new InputController(mainStateManager);
        States.FlagsEvents flagsEvents = new(mainStateManager);
        handsStateManager = new(mainStateManager);
        rightHandStateManager = new(mainStateManager);
        leftHandStateManager = new(mainStateManager);
        modalStateManager = new(mainStateManager);
    }
}


