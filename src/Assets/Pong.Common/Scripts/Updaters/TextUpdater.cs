using UnityEngine;
using UnityEngine.UI;

namespace Pong.Common.Updaters
{
    public class TextUpdater : MonoBehaviour
    {
        public Text label;


        public void UpdateText(string value) => label.text = value;
        public void UpdateText(int value) => label.text = value.ToString();
    }
}