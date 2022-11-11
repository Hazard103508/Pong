using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BallHandler : MonoBehaviour
{
    private Vector3 _prevPosition;
    private Vector2 direction;

    public float speed;
    public float maxAngle;
    public UnityEvent<Vector2> onBallPositionChanged;

    private void Awake()
    {
        ResetBall();
    }
    private void Update()
    {
        if (_prevPosition != transform.position)
            onBallPositionChanged.Invoke(transform.position);

        _prevPosition = transform.position;

        var movement = speed * direction * Time.deltaTime;
        this.transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space))
            ResetBall(); // borrar
    }
    public void OnBorderReached(ScreenBorders border)
    {
        if (border == ScreenBorders.Top || border == ScreenBorders.Bottom)
            InvertYDirection();
        else
            InvertXDirection();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            direction = (transform.position - collision.transform.position).normalized;

            Vector2 sign = new Vector2(Mathf.Sign(direction.x), Mathf.Sign(direction.y));
            float currentAngle = Vector3.Angle(Vector3.right * sign, direction);
            if (currentAngle > maxAngle)
                direction = MathHelpers.DegreeToVector2(maxAngle) * sign;
        }
    }

    public void InvertXDirection() => direction.x *= -1;
    public void InvertYDirection() => direction.y *= -1;
    public void ResetBall()
    {
        transform.position = Vector3.zero;

        var quarter = new Vector2(Random.value > 0.5f ? 1 : -1, Random.value > 0.5f ? 1 : -1);
        direction = MathHelpers.DegreeToVector2(Random.Range(5, 30)) * quarter;

        print(direction);
    }
}