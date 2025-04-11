using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : BaseStateMachine
{

    private EnemyMoveState _enemyMoveState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _enemyMoveState = new EnemyMoveState(this);
    }

    private void Start()
    {
        SetState(_enemyMoveState);
    }

    public void JumpToEnemyState()
    {
        SetState(_enemyMoveState);
    }

}
