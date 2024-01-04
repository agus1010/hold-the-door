using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


namespace JolDeFort.Core
{
	public class PlayerInputs : MonoBehaviour
	{
		public Vector2 CursorPosition => Mouse.current.position.ReadValue();

		public bool AttackValue { get; private set; }
		public bool SpecialValue { get; private set; }
		public Vector2 ZoomValue { get; private set; }

		public UnityEvent<bool> AttackPressed;
		public UnityEvent AttackReleased;
		public UnityEvent<bool> SpecialPressed;
		public UnityEvent SpecialReleased;
		public UnityEvent<Vector2> ZoomPerformed;



		public void HandleAttack(InputAction.CallbackContext context)
		{
			bool newValue = context.ReadValueAsButton();
			if (newValue != AttackValue)
			{
				AttackValue = newValue;
				if(AttackValue)
					AttackPressed?.Invoke(AttackValue);
				if(context.performed)
					AttackReleased?.Invoke();
			}
		}

		public void HandleSpecial(InputAction.CallbackContext context)
		{
			bool newValue = context.ReadValueAsButton();
			if (newValue != SpecialValue)
			{
				SpecialValue = newValue;
				SpecialPressed?.Invoke(SpecialValue);
			}
		}

		public void HandleZoom(InputAction.CallbackContext context)
		{
			Vector2 newValue = context.ReadValue<Vector2>();
			if (newValue != ZoomValue)
			{
				ZoomValue = newValue;
				ZoomPerformed?.Invoke(ZoomValue);
			}
		}
	}
}