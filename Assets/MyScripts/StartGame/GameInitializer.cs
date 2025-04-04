using Player;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    PlayerController playerController;
    private States.SM mainSM;
    private States.HandsSM handsSM;
    private InputController _inputController;
    private PlayerInputActions _inputActions;

    private void Awake()
    {
        playerController = GameContext.PlayerController;
        _inputActions = GameContext.InputActions;
        mainSM = GameContext.MainSM;
        handsSM = GameContext.HandsSM;
        _inputController = GameContext.InputController;

        // Начальное состояние
        handsSM.GoToStateEnter(new States.NoneWeapon());
        mainSM.GoToStateEnter(States.MainSM.GetGameState());

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
        mainSM.FixedUpdate();
    }
    void Update()
    {
        if (GameContext.IsPause)
        {

        }
        else
        {
            playerController.Update();
        }

        mainSM.UpdateState();
        mainSM.Update();
    }
    void LateUpdate()
    {
        if (GameContext.IsPause)
        {

        }
        else
        {
            playerController.LateUpdate();
            GameContext.EmotionController.LateUpdate();
        }
        mainSM.LateUpdate();
    }
}




public static class GameContext
{
    public static bool IsPause = false;
    public static PlayerController PlayerController { get; }
    public static PlayerModelRotationSync PlayerModelRotationSync { get; }
    public static CamerasController CamerasController { get; }
    public static CameraPlayerController CameraPlayerController { get; }
    public static PlayerAnimationController PlayerAnimationController { get; }
    public static UIManager UIManager { get; }
    public static InputController InputController { get; }
    public static PlayerInputActions InputActions { get; }
    public static EmotionController EmotionController { get; }

    public static States.SM MainSM { get; }
    public static States.HandsSM HandsSM { get; }
    public static States.RightHandSM RightHandSM { get; }
    public static States.LeftHandSM LeftHandSM { get; }
    public static States.ModalSM ModalSM { get; }

    static GameContext()
    {
        GameObject player = GameObject.Find("Player");
        Transform playerModel = player.transform.Find("PlayerModel");
        PlayerModelVRM playerModelVRM = new(playerModel);
        GameObject playerCamera = GameObject.Find("PlayerCamera");
        GameObject uiManagerGameObject = GameObject.Find("UIManager");

        PlayerController = new GroundPlayerController(player);
        PlayerController.OnGroundChanged += isGround => { States.Flags.Ground = isGround; };
        PlayerController.OnMoveChanged += isMove => { States.Flags.Move = isMove; };

        PlayerModelRotationSync = playerModel.GetComponent<PlayerModelRotationSync>();

        CamerasController = new();
        CameraPlayerController = new(playerCamera, CamerasController);

        PlayerAnimationController = new(playerModelVRM.model);
        EmotionController = new(playerModelVRM.model);

        UIManager = uiManagerGameObject.GetComponent<UIManager>();

        InputActions = new PlayerInputActions();

        MainSM = new();
        InputController = new(MainSM);
        new States.FlagsEvents(MainSM);
        ModalSM = new(MainSM);
        HandsSM = new(MainSM);
        RightHandSM = new(HandsSM);
        LeftHandSM = new(HandsSM);
    }
}


