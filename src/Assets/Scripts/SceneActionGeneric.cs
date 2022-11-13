using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class SceneActionGeneric<T> : MonoBehaviour
{
    public UnityEvent<T> onInvoke;

    public void Invoke(T value)
    {
        if (gameObject.activeSelf)
            onInvoke.Invoke(value);
    }
}