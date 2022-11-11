using UnityEngine;

[RequireComponent(typeof(Player))]
public class InputKeyboard : MonoBehaviour
{
    public Player player;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            player.speedFactor = 1;
        else
            if (Input.GetKey(KeyCode.DownArrow))
            player.speedFactor = -1;
        else
            player.speedFactor = 0;
    }
}
