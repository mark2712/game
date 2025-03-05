using UnityEngine;
using UnityEngine.InputSystem;


public class InventoryState : GameStateFSM
{
    public override void Enter() { Debug.Log("Инвентарь открыт"); }
    public override void Exit() { Debug.Log("Инвентарь закрыт"); }

    public override void ConsolePerformed()
    {
        gameStateManager.GoToState(new StandState());
    }

    public override void KeyT_performed() { Debug.Log("Инвентарь уже открыт"); }
}


// public class InventoryState : GameStateFSM
// {
//     private GameStateManager _stateManager;

//     public InventoryState(GameStateManager stateManager)
//     {
//         _stateManager = stateManager;
//     }

//     public override void Enter() { Debug.Log("Инвентарь открыт"); }
//     public override void Exit() { Debug.Log("Инвентарь закрыт"); }

//     public override void KeyConsole_performed()
//     {
//         _stateManager.GoToState(new StandState(_stateManager));
//     }

//     public override void KeyT_performed() { Debug.Log("Инвентарь уже открыт"); }
// }


// public class MenuState : GameStateFSM
// {
//     private GameStateManager _stateManager;

//     public MenuState(GameStateManager stateManager)
//     {
//         _stateManager = stateManager;
//     }

//     public override void Enter() { Debug.Log("Меню открыто"); }
//     public override void Exit() { Debug.Log("Меню закрыто"); }


//     public override void KeyConsole_performed()
//     {
//         _stateManager.GoToState(new StandState(_stateManager));
//     }

//     public override void KeyT_performed() { Debug.Log("Нельзя открыть инвентарь из меню"); }
// }