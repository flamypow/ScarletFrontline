using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody2D;
    [SerializeField] private bool forceAdded;
    [SerializeField] private float moveforce;
    private bool waitingToTakeTurn;

    private void Awake()
    {
        waitingToTakeTurn = false;
    }
    void Start()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        

    }
    public void TakeTurn()
    {
        if (enemyRigidBody2D.linearVelocityX > 0.0001f || enemyRigidBody2D.linearVelocityY > 0.0001f || (!(enemyRigidBody2D.linearVelocity.magnitude < 0.001f)))
        {
            waitingToTakeTurn = true;
        }
        else
        {
            waitingToTakeTurn = false;
            Debug.Log("Enemy Turn<=enemydemo15");
            enemyRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
            enemyRigidBody2D.AddForce(new Vector3(Random.Range(-1f*moveforce,1f * moveforce), Random.Range(-1f * moveforce, 1f * moveforce), 0));
            forceAdded = true;
        }


    }

    public void OpponentTurn()
    {
        enemyRigidBody2D.bodyType = RigidbodyType2D.Dynamic;

    }

    protected void FixedUpdate()
    {
        if (forceAdded == true && enemyRigidBody2D.linearVelocityX < 0.0001f && enemyRigidBody2D.linearVelocityY < 0.0001f)
        {
            enemyRigidBody2D.bodyType = RigidbodyType2D.Static;
            forceAdded = false;
            enemyRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
            GameManager.Instance.PlayerTurn();
        }
        if (waitingToTakeTurn == true && enemyRigidBody2D.linearVelocityX < 0.0001f && enemyRigidBody2D.linearVelocityY < 0.0001f)
        {
            TakeTurn();
        }
        
    }
}
