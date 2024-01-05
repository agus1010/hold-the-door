using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


namespace JolDeFort.Core
{
	public class PlayerInputs : MonoBehaviour
	{
		public Vector2 CursorPosition => Mouse.current.position.ReadValue();

		public InputAction.CallbackContext AttackInputCallbackContext { get; private set; }
		public InputAction.CallbackContext SpecialInputCallbackContext { get; private set; }
		public InputAction.CallbackContext ZoomInputCallbackContext { get; private set; }

		public UnityEvent<PlayerInputs> AttackStarted;
		public UnityEvent<PlayerInputs> AttackPerformed;
		public UnityEvent<PlayerInputs> AttackCancelled;

		public UnityEvent<PlayerInputs> SpecialStarted;
		public UnityEvent<PlayerInputs> SpecialPerformed;
		public UnityEvent<PlayerInputs> SpecialCancelled;

		public UnityEvent<PlayerInputs> ZoomStarted;
		public UnityEvent<PlayerInputs> ZoomPerformed;
		public UnityEvent<PlayerInputs> ZoomCancelled;


		public void HandleAttackInput(InputAction.CallbackContext callbackContext)
		{
			AttackInputCallbackContext = callbackContext;
			handleInput(callbackContext, AttackStarted, AttackPerformed, AttackCancelled);
		}

		public void HandleSpecialInput(InputAction.CallbackContext callbackContext)
		{
			SpecialInputCallbackContext = callbackContext;
			handleInput(callbackContext, SpecialStarted, SpecialPerformed, SpecialCancelled);
		}

		public void HandleZoomInput(InputAction.CallbackContext callbackContext)
		{
			ZoomInputCallbackContext = callbackContext;
			handleInput(callbackContext, ZoomStarted, ZoomPerformed, ZoomCancelled);
		}


		private void handleInput(
			InputAction.CallbackContext callbackContext,
			UnityEvent<PlayerInputs> startedCallback,
			UnityEvent<PlayerInputs> performedCallback,
			UnityEvent<PlayerInputs> cancelledCallback)
		{
			if (callbackContext.started)
				startedCallback?.Invoke(this);
			if (callbackContext.performed)
				performedCallback?.Invoke(this);
			if (callbackContext.canceled)
				cancelledCallback?.Invoke(this);
		}
	}
}