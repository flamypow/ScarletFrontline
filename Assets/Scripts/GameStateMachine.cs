using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : BaseStateMachine
{

    private EnemyMoveState _enemyMoveState;
    private PlayerMoveState _playerMoveState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private EnemyDemo _enemyDemo;

    public EnemyDemo enemyDemo => _enemyDemo;

    

    private void Awake()
    {
        _enemyMoveState = new EnemyMoveState(this);
        _playerMoveState = new PlayerMoveState(this);

    }

    private void Start()
    {
        SetState(_enemyMoveState);
    }

    public void JumpToEnemyState()
    {
        SetState(_enemyMoveState);
    }

    public void JumpToPlayerState()
    {
        SetState(_playerMoveState);
    }

    public void JumpToPlayerSpecialState()
    { 
        
    }

}
