using UnityEngine;

namespace Xesin.GameplayFramework
{
    [CreateAssetMenu(menuName = "Gameplay/Input/Gamepad Images Collection", fileName = "GamepadImagesCollection.asset")]
    public class GamepadImageCollection : InputImageCollection
    {
        [SerializeField] private Sprite buttonSouth;
        [SerializeField] private Sprite buttonNorth;
        [SerializeField] private Sprite buttonEast;
        [SerializeField] private Sprite buttonWest;
        [SerializeField] private Sprite startButton;
        [SerializeField] private Sprite selectButton;
        [SerializeField] private Sprite leftTrigger;
        [SerializeField] private Sprite rightTrigger;
        [SerializeField] private Sprite leftShoulder;
        [SerializeField] private Sprite rightShoulder;
        [SerializeField] private Sprite dpad;
        [SerializeField] private Sprite dpadUp;
        [SerializeField] private Sprite dpadDown;
        [SerializeField] private Sprite dpadLeft;
        [SerializeField] private Sprite dpadRight;
        [SerializeField] private Sprite leftStick;
        [SerializeField] private Sprite rightStick;
        [SerializeField] private Sprite rightStickUp;
        [SerializeField] private Sprite rightStickDown;
        [SerializeField] private Sprite rightStickLeft;
        [SerializeField] private Sprite rightStickRight;
        [SerializeField] private Sprite rightStickX;
        [SerializeField] private Sprite rightStickY;
        [SerializeField] private Sprite leftStickUp;
        [SerializeField] private Sprite leftStickDown;
        [SerializeField] private Sprite leftStickLeft;
        [SerializeField] private Sprite leftStickRight;
        [SerializeField] private Sprite leftStickX;
        [SerializeField] private Sprite leftStickY;
        [SerializeField] private Sprite leftStickPress;
        [SerializeField] private Sprite rightStickPress;
        [SerializeField] private Sprite unrecognized;

        public override Sprite GetInputImage(string inputPath)
        {
            switch (inputPath)
            {
                case "buttonSouth": return buttonSouth;
                case "buttonNorth": return buttonNorth;
                case "buttonEast": return buttonEast;
                case "buttonWest": return buttonWest;
                case "start": return startButton;
                case "select": return selectButton;
                case "leftTrigger": return leftTrigger;
                case "rightTrigger": return rightTrigger;
                case "leftShoulder": return leftShoulder;
                case "rightShoulder": return rightShoulder;
                case "dpad": return dpad;
                case "dpad/up": return dpadUp;
                case "dpad/down": return dpadDown;
                case "dpad/left": return dpadLeft;
                case "dpad/right": return dpadRight;
                case "leftStick": return leftStick;
                case "rightStick": return rightStick;
                case "leftStickPress": return leftStickPress;
                case "rightStickPress": return rightStickPress;
                case "leftStick/up": return leftStickUp;
                case "leftStick/down": return leftStickDown;
                case "leftStick/left": return leftStickLeft;
                case "leftStick/right": return leftStickRight;
                case "rightStick/up": return rightStickUp;
                case "rightStick/down": return rightStickDown;
                case "rightStick/left": return rightStickLeft;
                case "rightStick/right": return rightStickRight;
                case "leftStick/x": return leftStickX;
                case "leftStick/y": return leftStickY;
                case "rightStick/x": return rightStickX;
                case "rightStick/y": return rightStickY;
            }
            return unrecognized;
        }
    }
}
