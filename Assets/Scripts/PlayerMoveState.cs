using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveState : BaseState
{
    private GameStateMachine _stateMachine;

    public PlayerMoveState(GameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public override void EnterState()
    {
        Debug.Log("Player's turn");
        PlayerController.Instance.PlayerTurnStart();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }
}
