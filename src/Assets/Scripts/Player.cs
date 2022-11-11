using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerType playerType;
    public PlayerSettings settings;
    [HideInInspector] public float speedFactor;

    void Awake()
    {
        SetInitialPosition();
    }

    void Update()
    {
        Move();
    }

    private void SetInitialPosition()
    {
        float margin = 0.95f;
        var x = Screen.width * (playerType == PlayerType.One ? margin : 1 - margin);

        var initPos = Camera.main.ScreenToWorldPoint(new Vector2(x, 0));
        this.transform.position = new Vector3(initPos.x, 0, 0);
    }
    private void Move()
    {
        var y = settings.speed * speedFactor * Time.deltaTime;
        this.transform.Translate(Vector3.up * y);
    }
}
