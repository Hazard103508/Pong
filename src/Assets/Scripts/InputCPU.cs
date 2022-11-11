using UnityEngine;

public class InputCPU : MonoBehaviour
{
    public float speed;


    public void OnBallPositionChanged(Vector2 position)
    {
        var posTarget = new Vector3(transform.position.x, position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, posTarget, Time.deltaTime * speed);
    }
}
