using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class LimitScreenBorders : MonoBehaviour
{
    private Borders<float> bordersIn;
    private Borders<float> bordersOut;

    public SpriteRenderer spriteRenderer;
    public Borders<bool> bordersToLimit;
    public UnityEvent<ScreenBorders> onBorderInReached;
    public UnityEvent<ScreenBorders> onBorderOutReached;

    void Awake()
    {
        SetScreenBoundPosition();
    }

    void LateUpdate()
    {
        CheckBoundIn();
        CheckBoundOut();
    }

    private void CheckBoundIn()
    {
        var pos = transform.position;
        if (bordersToLimit.left && pos.x < bordersIn.left)
        {
            transform.position = new Vector3(bordersIn.left, transform.position.y);
            onBorderInReached.Invoke(ScreenBorders.Left);
        }
        else if (bordersToLimit.right && pos.x > bordersIn.right)
        {
            transform.position = new Vector3(bordersIn.right, transform.position.y);
            onBorderInReached.Invoke(ScreenBorders.Right);
        }
        else if (bordersToLimit.bottom && pos.y < bordersIn.bottom)
        {
            transform.position = new Vector3(transform.position.x, bordersIn.bottom);
            onBorderInReached.Invoke(ScreenBorders.Bottom);
        }
        else if (bordersToLimit.top && pos.y > bordersIn.top)
        {
            transform.position = new Vector3(transform.position.x, bordersIn.top);
            onBorderInReached.Invoke(ScreenBorders.Top);
        }
    }
    private void CheckBoundOut()
    {
        var pos = transform.position;
        if (!bordersToLimit.left && pos.x < bordersOut.left) onBorderOutReached.Invoke(ScreenBorders.Left);
        else if (!bordersToLimit.right && pos.x > bordersOut.right)
        {
            onBorderOutReached.Invoke(ScreenBorders.Right);
        }
        else if (!bordersToLimit.bottom && pos.y < bordersOut.bottom) onBorderOutReached.Invoke(ScreenBorders.Bottom);
        else if (!bordersToLimit.top && pos.y > bordersOut.top) onBorderOutReached.Invoke(ScreenBorders.Top);
    }

    private void SetScreenBoundPosition()
    {
        var cam = Camera.main;
        var downLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        var scale = transform.localScale;
        bordersIn = new Borders<float>()
        {
            left = downLeft.x + (spriteRenderer.sprite.bounds.size.x * scale.x) / 2.0f,
            right = topRight.x - (spriteRenderer.sprite.bounds.size.x * scale.x) / 2.0f,
            bottom = downLeft.y + (spriteRenderer.sprite.bounds.size.y * scale.y) / 2.0f,
            top = topRight.y - (spriteRenderer.sprite.bounds.size.y * scale.y) / 2.0f
        };

        bordersOut = new Borders<float>()
        {
            left = downLeft.x - (spriteRenderer.sprite.bounds.size.x * scale.x) / 2.0f,
            right = topRight.x + (spriteRenderer.sprite.bounds.size.x * scale.x) / 2.0f,
            bottom = downLeft.y - (spriteRenderer.sprite.bounds.size.y * scale.y) / 2.0f,
            top = topRight.y + (spriteRenderer.sprite.bounds.size.y * scale.y) / 2.0f
        };
    }

    [Serializable]
    public class Borders<T>
    {
        public T left;
        public T right;
        public T top;
        public T bottom;
    }
}
