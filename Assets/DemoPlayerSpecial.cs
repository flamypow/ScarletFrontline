using UnityEngine;

public class DemoPlayerSpecial : MonoBehaviour
{
    [SerializeField] Collider2D attackCollider;
    private Vector3 origionalLocalPosition;
    private Vector3 targetLocalPosition;
    private Rigidbody2D special_rb;
    bool doingSpecial;

    [SerializeField] private float punchSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        doingSpecial = false;
        special_rb = GetComponent<Rigidbody2D>();
        origionalLocalPosition = transform.localPosition;
    }

    public void DoSpecial()
    {
        PlayerController.Instance.SetAsStatic();
        
        targetLocalPosition = new Vector3(origionalLocalPosition.x, origionalLocalPosition.y + 3.75f, origionalLocalPosition.z); //this is hard coded for demo, use animation instead
        attackCollider.enabled = true;
        doingSpecial = true;
        //special_rb.MovePosition
        //PlayerController.Instance.SetAsDynamic();
    }

    protected void FixedUpdate()
    {
        if (doingSpecial == true)
        {
            //special_rb.MovePosition
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetLocalPosition, Time.deltaTime * punchSpeed);
            if (Vector3.Distance(transform.localPosition, targetLocalPosition) < 0.01f)
            {
                Debug.Log("finished doing special");
                doingSpecial = false;
                PlayerController.Instance.SetAsDynamic();
                attackCollider.enabled = false;

                transform.localPosition = origionalLocalPosition;

                GameManager.Instance.EnemyTurn();
            }
        }
    }

}