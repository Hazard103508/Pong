using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour
{
    private Canvas canvas;
    public CanvasGroup canvasGroup;
    public UnityEvent onOpened;
    public UnityEvent onClosed;

    void Awake()
    {
        canvas = transform.GetComponentInParent<Canvas>();
        Close();
    }

    public void Open()
    {
        canvasGroup.alpha = 1;
        onOpened.Invoke();
        gameObject.SetActive(true);
    }
    public void Close()
    {
        canvasGroup.alpha = 0;
        onClosed.Invoke();
        gameObject.SetActive(true);
    }

    public void SetViewportPosition_X(float x)
    {
        transform.localPosition = Camera.main.ViewportToScreenPoint(new Vector3(x, 0, 0)) / canvas.scaleFactor;
    }
}
