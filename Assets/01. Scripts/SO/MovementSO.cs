using UnityEngine;

[CreateAssetMenu(menuName = "SO/Movement")]
public class MovementSO : ScriptableObject
{
    [SerializeField] float increaseAccel = 10f;
    public float IncreaseAccel => increaseAccel;
    
    [SerializeField] float decreaseAccel = 10f;
    public float DecreaseAccel => decreaseAccel;

    [SerializeField] float maxSpeed = 10f;
    public float MaxSpeed => maxSpeed;
}
