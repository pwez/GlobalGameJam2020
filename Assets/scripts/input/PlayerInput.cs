using interfaces;
using UnityEngine;

namespace input {
	[RequireComponent(typeof(PlayerMotion))]
	public class PlayerInput : MonoBehaviour {

		public KeyCode up, down, left, right;
		public KeyCode commandButton;
		private PlayerMotion playerMotion;
		private Vector2 directionalInput;

		private Controllable controllable;
		
		void Awake () {
			playerMotion = GetComponent<PlayerMotion> ();
			controllable = GetComponent<Controllable> ();
		}
	
		void Update () {
			directionalInput = new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			playerMotion.setDirection (directionalInput);

			if (Input.GetKey (up)) {
				playerMotion.setDirection (Vector2.up);
			}
			else if (Input.GetKey (down)) {
				playerMotion.setDirection (Vector2.down);
			}
			else if (Input.GetKey (left)) {
				playerMotion.setDirection (Vector2.left);
			}
			else if (Input.GetKey (right)) {
				playerMotion.setDirection (Vector2.right);
			}
			else {
				playerMotion.setDirection (Vector2.zero);
			}

			if (Input.GetKeyDown (commandButton)) {
				controllable.OnPressed ();
			}
			if (Input.GetKey (commandButton)) {
				controllable.OnHeld ();
			}
			else if (Input.GetKeyUp (commandButton)) {
				controllable.OnReleased ();
			}
		}
	}
}
