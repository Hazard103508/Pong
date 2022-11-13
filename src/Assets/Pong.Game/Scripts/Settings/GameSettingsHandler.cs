using UnityEngine;

namespace Pong.Game.Settings
{
    public class GameSettingsHandler : MonoBehaviour
    {
        public void SetDifficulty_Easy() => GameSettings.Difficulty = DifficultyTypes.Easy;
        public void SetDifficulty_Medium() => GameSettings.Difficulty = DifficultyTypes.Medium;
        public void SetDifficulty_Hard() => GameSettings.Difficulty = DifficultyTypes.Hard;

        public void SetInput_Keyboard() => GameSettings.Input = InputTypes.Keyboard;
        public void SetInput_Mouse() => GameSettings.Input = InputTypes.Mouse;
    }
}