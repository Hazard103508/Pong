using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InputCPU : MonoBehaviour
{
    public float speed;
    public Transform target;

    private void Update()
    {
        var posTarget = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, posTarget, Time.deltaTime * speed);
    }
}
