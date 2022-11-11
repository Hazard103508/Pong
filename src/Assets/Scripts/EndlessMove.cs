using UnityEngine;

public class EndlessMove : MonoBehaviour
{
    public float speed;
    public Vector2 direction;


    void Update()
    {
        var movement = speed * direction * Time.deltaTime;
        this.transform.Translate(movement);
    }
}
