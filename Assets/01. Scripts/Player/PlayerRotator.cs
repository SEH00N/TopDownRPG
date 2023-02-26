using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 10f;

    public void DoRotate(Vector2 lookAt)
    {
        if(lookAt.sqrMagnitude <= 0)
            return;
        
        Vector2 normalVector = lookAt.normalized;
        float angle = Mathf.Atan2(normalVector.x, normalVector.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.up), Time.deltaTime * rotateSpeed);
    }
}
