using UnityEngine;

namespace Pong.Common.Behaviours
{
    public class PauseHandler : MonoBehaviour
    {
        public void PauseGame()
        {
            Time.timeScale = 0;
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }
    }
}