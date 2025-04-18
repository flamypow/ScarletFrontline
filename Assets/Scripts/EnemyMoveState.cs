using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveState : BaseState
{
    private GameStateMachine _stateMachine;

    public EnemyMoveState(GameStateMachine stateMachine)
    { 
        _stateMachine = stateMachine;
    }
    public override void EnterState()
    {
        _stateMachine.enemyDemo.TakeTurn();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        
    }

}
