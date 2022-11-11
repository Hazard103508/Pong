using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Trigger2DEnter : MonoBehaviour
{
    public UnityEvent<Collider2D> onTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTrigger.Invoke(collision);
    }
}
