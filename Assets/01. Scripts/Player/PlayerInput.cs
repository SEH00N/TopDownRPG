using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerComponent playerComponent = null;

    private void Awake()
    {
        playerComponent = GetComponent<PlayerComponent>();
    }

    private void Update()
    {
        MovementInput();
    }   

    private void MovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(x, z);

        playerComponent.Movement.DoMove(input);
    }
}
