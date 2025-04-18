using UnityEngine;
using Code.Scripts.Managers;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStateMachine gameStateMachine;

    public bool IsEnemyTurn;

    public void EnemyTurn()
    {
        if (IsEnemyTurn)
        {
            Debug.Log("enemy may already taken the turn");
        }
        else {
            IsEnemyTurn = true;
            gameStateMachine.JumpToEnemyState();
        }
    }

    public void PlayerTurn()
    {
        if (IsEnemyTurn)
        {
            IsEnemyTurn = false;
            gameStateMachine.JumpToPlayerState();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Demo");
    }

}
