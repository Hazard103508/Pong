using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class SceneAction : MonoBehaviour
{
    public UnityEvent onInvoke;

    public void Invoke()
    {
        if (gameObject.activeSelf)
            onInvoke.Invoke();
    }
}
