using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    private AgentMovement movement = null;
    public AgentMovement Movement {
        get {
            if(movement == null)
                movement = GetComponent<AgentMovement>();
            
            return movement;
        }
    }
}
