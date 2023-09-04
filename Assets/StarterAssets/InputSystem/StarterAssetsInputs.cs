using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[field: SerializeField] public bool InputEnable { get; private set; } = true;
		
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputAction.CallbackContext value)
		{
			MoveInput(value.ReadValue<Vector2>());
		}

		public void OnLook(InputAction.CallbackContext value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.ReadValue<Vector2>());
			}
		}

		public void OnJump(InputAction.CallbackContext value)
		{
			JumpInput(value.performed);
		}

		public void OnSprint(InputAction.CallbackContext value)
		{
			SprintInput(value.performed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = InputEnable ? Vector3.ClampMagnitude(newMoveDirection, 1f) : Vector3.zero;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = InputEnable ? newLookDirection : Vector3.zero;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = InputEnable && newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = InputEnable && newSprintState;
		}
		
		public void SetInputEnable(bool state)
		{
			InputEnable = state;
			MoveInput(Vector2.zero);
			LookInput(Vector2.zero);
			JumpInput(false);
			SprintInput(false);
		}
	}
	
	
	
}