using GameplayFramework.Input;
using UnityEngine;

namespace GameplayFramework
{

    public class Pawn : GameplayObject
    {
        public float BaseEyeHeight = 1.5f;

        public bool useControllerYaw;
        public bool useControllerPitch;
        public bool useControllerRoll;

        public Controller Controller => currentController;

        private Controller currentController = null;
        private GameplayCamera pawnCamera = null;

        private Vector3 controlInputVector;
        private Vector3 lastControlInputVector;

        protected virtual void Awake()
        {
            var gameplayComponents = GetComponentsInChildren<GameplayObject>(true);

            for (int i = 0; i < gameplayComponents.Length; i++)
            {
                if (gameplayComponents[i] != this)
                {
                    gameplayComponents[i].SetOwner(this);
                }
            }
            controlInputVector = Vector2.zero;

            GameplayCamera camera = GetComponentInChildren<GameplayCamera>();
            if (camera)
            {
                pawnCamera = camera;
            }

            Restart();
        }

        protected virtual void OnDestroy()
        {
            Unpossesed();
        }

        public virtual void PossessedBy(Controller controller)
        {
            if (currentController == controller) return;

            currentController = controller;
            if (controller is PlayerController playerController)
            {
                SetupPlayerInput(playerController.GetInputComponent());   
            }
            if(pawnCamera)
            {
                pawnCamera.enabled = true;
            }
        }

        public virtual void Restart()
        {
            RecalculateBaseEyeHeight();
            Internal_ConsumeInputVector();
            if(pawnCamera && !Controller)
            {
                pawnCamera.enabled = false;
            }
        }

        public virtual void Unpossesed()
        {
            if (!currentController) return;

            if (pawnCamera)
            {
                pawnCamera.enabled = false;
            }
            if (currentController is PlayerController playerController)
            {
                ClearPlayerInput(playerController.GetInputComponent());
            }
            currentController = null;
            Restart();
        }

        public virtual void SetupPlayerInput(InputComponent inputComponent)
        {

        }

        public virtual void ClearPlayerInput(InputComponent inputComponent)
        {
            inputComponent.ClearBinds(this);
        }

        public void AddControllerPitchInput(float Val)
        {
            if (Val != 0 && Controller)
            {
                PlayerController PC = (PlayerController)Controller;
                PC.AddPitchInput(Val);
            }
        }

        public void AddControllerYawInput(float Val)
        {
            if (Val != 0 && Controller)
            {
                PlayerController PC = (PlayerController)Controller;
                PC.AddYawInput(Val);
            }
        }

        public void AddControllerRollInput(float Val)
        {
            if (Val != 0 && Controller)
            {
                PlayerController PC = (PlayerController)Controller;
                PC.AddRollInput(Val);
            }
        }

        public void FaceRotation(Vector3 rotation, float deltaTime)
        {
            if (pawnCamera)
            {
                pawnCamera.ApplyControlRotation(Quaternion.Euler(rotation));
            }

            if (useControllerPitch || useControllerRoll || useControllerYaw)
            {
                Vector3 currentRotation = transform.rotation.eulerAngles;
                if (!useControllerPitch)
                {
                    rotation.x = currentRotation.x;
                }

                if (!useControllerYaw)
                {
                    rotation.y = currentRotation.y;
                }

                if (!useControllerRoll)
                {
                    rotation.z = currentRotation.z;
                }

                transform.rotation = Quaternion.Euler(rotation);
            }
        }

        public Vector3 GetControlRotation()
        {
            return Controller?.GetControlRotation() ?? Vector3.zero;
        }

        public virtual void RecalculateBaseEyeHeight()
        {
            BaseEyeHeight = 1.5f;
        }


        public void GetEyesViewPoint(out Vector3 location, out Quaternion rotation)
        {
            location = GetPawnViewLocation();
            rotation = GetViewDirection();
        }

        public virtual Vector3 GetPawnViewLocation()
        {
            return transform.position + new Vector3(0f, BaseEyeHeight, 0f);
        }

        public virtual Quaternion GetViewDirection()
        {
            if (Controller)
            {
                Quaternion quaternion = Quaternion.Euler(Controller.GetControlRotation());
                return quaternion;
            }

            return transform.rotation;
        }

        internal Vector3 Internal_ConsumeInputVector()
        {
            lastControlInputVector = controlInputVector;
            controlInputVector = Vector3.zero;
            return lastControlInputVector;
        }

        public void AddMoveInput(Vector3 worldSpaceInput, float scale = 1)
        {
            controlInputVector += worldSpaceInput * scale;
            Debug.Log(controlInputVector);
        }
    }
}