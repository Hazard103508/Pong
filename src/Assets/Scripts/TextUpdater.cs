using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    public Text label;


    public void UpdateText(string value) => label.text = value;
    public void UpdateText(int value) => label.text = value.ToString();
}
