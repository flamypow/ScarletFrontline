using Unity.VisualScripting;
using UnityEngine;
using Code.Scripts.Managers;
using UnityEngine.UI;
public class PlayerController : Code.Scripts.Managers.Singleton<PlayerController>
{
    [SerializeField] private Rigidbody2D puckRigidbody2D;
    [SerializeField] private float rotationSpeed;
    private float chargedAmount;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float chargeSpeed;
    bool playerCanMove;
    bool playerCanSpecial;
    private float rotateVector;
    bool isCharging;
    bool forceAdded;

    [SerializeField] private Slider chargeSlider;
    private int stoppingCount;

    [SerializeField] private DemoPlayerSpecial demoSpecial;

    void Start()
    {
        playerCanMove = false;
        forceAdded = false;
        stoppingCount = 0;
    }
    public void Aim(float inputValue)
    {
        rotateVector = inputValue;
    }

    public void ChargePower()
    {   
        if (playerCanSpecial)
        {
            //do special
            puckRigidbody2D.bodyType = RigidbodyType2D.Static;
            Debug.Log("player do special");
            demoSpecial.DoSpecial();
            playerCanSpecial = false;
        }
        if (playerCanMove)
        {
            isCharging = true;
        }

        
    }

    public void ChargePowerReleased()
    {
        if (isCharging)
        { 
            isCharging = false;
            
            puckRigidbody2D.AddForce(transform.up * chargedAmount * movementSpeed);
            forceAdded = true;
            playerCanMove = false;
            playerCanSpecial = true;
            
        }
        
        chargedAmount = 0f;
        
    }

    protected void FixedUpdate()
    {
        if (playerCanMove)
        {
            transform.Rotate(0, 0, rotateVector * rotationSpeed * -1f);
            if (isCharging)
            {
                chargedAmount += chargeSpeed;
                chargedAmount = Mathf.Clamp(chargedAmount, 0f, 1f);
                chargeSlider.value = chargedAmount;
            }
        }
        if (forceAdded && puckRigidbody2D.linearVelocityX < 0.0001f && puckRigidbody2D.linearVelocityY < 0.0001f)
        {
            stoppingCount++;
        }
        else
        {
            if (stoppingCount < 3)
            {
                stoppingCount = 0;
            }
        }
        if (stoppingCount > 3) //end the turn here
        {
            stoppingCount = 0;
            puckRigidbody2D.bodyType = RigidbodyType2D.Static;
            forceAdded = false;
            puckRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            GameManager.Instance.EnemyTurn();
        }
    }

    public void PlayerTurnStart()
    {
        playerCanMove = true;
        playerCanSpecial = false;

    }
    public void PlayerFinishedMove()
    {
        playerCanMove = false;
        playerCanSpecial = false;
        GameManager.Instance.EnemyTurn();
    }

    public void SetAsStatic()
    {
        puckRigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public void SetAsDynamic()
    {
        puckRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
