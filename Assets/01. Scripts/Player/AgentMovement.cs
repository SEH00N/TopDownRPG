using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] MovementSO movementSO = null;
    
    private Rigidbody rb = null;

    private float currentVelocity = 0f;
    private Vector3 currentDir = Vector3.zero;
    private Vector2 PlainVector => new Vector2(currentDir.x, currentDir.z);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = currentDir * currentVelocity;
    }

    public void DoMove(Vector2 input) 
    {
        Vector2 normalVector = input.normalized;

        CalculateSpeed(normalVector);

        if(normalVector.sqrMagnitude > 0) 
        {
            currentDir.x = normalVector.x;
            currentDir.z = normalVector.y;
        }
    }

    private void CalculateSpeed(Vector2 dir) 
    {
        if(Vector2.Dot(PlainVector, dir) < 0)
            currentVelocity = 0f;

        if(dir.sqrMagnitude > 0)
            currentVelocity += movementSO.IncreaseAccel * Time.deltaTime;
        else
            currentVelocity -= movementSO.DecreaseAccel * Time.deltaTime;

        currentVelocity = Mathf.Clamp(currentVelocity, 0f, movementSO.MaxSpeed);
    }
}
