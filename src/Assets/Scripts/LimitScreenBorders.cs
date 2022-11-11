using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static LimitScreenBorders;

[RequireComponent(typeof(SpriteRenderer))]
public class LimitScreenBorders : MonoBehaviour
{
    private Borders<float> borders;

    public SpriteRenderer spriteRenderer;
    public Borders<bool> bordersToLimit;
    public UnityEvent<ScreenBorders> onBorderReached;

    void Awake()
    {
        SetScreenBoundPosition();
    }

    void LateUpdate()
    {
        CheckBound();
    }

    private void CheckBound()
    {
        var pos = transform.position;
        if (bordersToLimit.left && pos.x < borders.left)
        {
            transform.position = new Vector3(borders.left, transform.position.y);
            onBorderReached.Invoke(ScreenBorders.Left);
        }
        else if (bordersToLimit.right && pos.x > borders.right)
        {
            transform.position = new Vector3(borders.right, transform.position.y);
            onBorderReached.Invoke(ScreenBorders.Right);
        }
        else if (bordersToLimit.bottom && pos.y < borders.bottom)
        {
            transform.position = new Vector3(transform.position.x, borders.bottom);
            onBorderReached.Invoke(ScreenBorders.Bottom);
        }
        else if (bordersToLimit.top && pos.y > borders.top)
        {
            transform.position = new Vector3(transform.position.x, borders.top);
            onBorderReached.Invoke(ScreenBorders.Top);
        }
    }
    private void SetScreenBoundPosition()
    {
        var cam = Camera.main;
        var downLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        var scale = transform.localScale;
        borders = new Borders<float>()
        {
            left = downLeft.x + (spriteRenderer.sprite.bounds.size.x * scale.x) / 2.0f,
            right = topRight.x - (spriteRenderer.sprite.bounds.size.x * scale.x) / 2.0f,
            bottom = downLeft.y + (spriteRenderer.sprite.bounds.size.y * scale.y) / 2.0f,
            top = topRight.y - (spriteRenderer.sprite.bounds.size.y * scale.y) / 2.0f
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
