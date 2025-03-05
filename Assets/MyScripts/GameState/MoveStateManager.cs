public enum MoveMode { Sneak, Move, Sprint, Run }


public class MoveStateManager
{
    public MoveMode nowMoveMode = MoveMode.Move;
    // public BaseMoveStandState nowMoveState;

    public bool isRunning = false;
    public bool isSneaking = false;

    public void UpdateState()
    {
        MoveMode newMoveMode = MoveMode.Move; // Скорость 3 (Move)
        GameContext.playerController.nowMoveSpeed = 4;

        if (isRunning && isSneaking) // Скорость 2 (Sneak+Run)
        {
            newMoveMode = MoveMode.Sprint;
            GameContext.playerController.nowMoveSpeed = 9;
        }
        else if (isSneaking) // Скорость 1 (Sneak)
        {
            newMoveMode = MoveMode.Sneak;
            GameContext.playerController.nowMoveSpeed = 1;
        }
        else if (isRunning) // Скорость 4 (Run)
        {
            newMoveMode = MoveMode.Run;
            GameContext.playerController.nowMoveSpeed = 15;
        }

        if (newMoveMode != nowMoveMode)
        {
            nowMoveMode = newMoveMode;
            // nowMoveState = GetState();
        }
    }

    // public BaseMoveStandState GetState()
    // {
    //     switch (nowMoveMode)
    //     {
    //         case MoveMode.Sneak:
    //             return new SneakState();
    //         case MoveMode.Sprint:
    //             return new SprintState();
    //         case MoveMode.Run:
    //             return new RunState();
    //         default:
    //             return new MoveState();
    //     }
    // }

    // Обработчики ввода
    public void ShiftPerformed()
    {
        isRunning = true;
        UpdateState();
    }

    public void ShiftCanceled()
    {
        isRunning = false;
        UpdateState();
    }

    public void CtrlPerformed()
    {
        isSneaking = true;
        UpdateState();
    }

    public void CtrlCanceled()
    {
        isSneaking = false;
        UpdateState();
    }

    public void KeyX_performed()
    {
        isSneaking = !isSneaking;
        UpdateState();
    }

    public void KeyC_performed()
    {
        isRunning = !isRunning;
        UpdateState();
    }
}

