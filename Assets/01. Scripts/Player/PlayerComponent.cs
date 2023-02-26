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

    private PlayerRotator rotator = null;
    public PlayerRotator Rotator {
        get {
            if(rotator == null)
                rotator = GetComponent<PlayerRotator>();
            
            return rotator;
        }
    }
}
