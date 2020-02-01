using interfaces;
using UnityEngine;

namespace input {
	[RequireComponent(typeof(PlayerMotion))]
	public class PlayerInput : MonoBehaviour {

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
			
			if (Input.GetKeyDown (KeyCode.R)) {
				controllable.OnPressed ();
			}
			if (Input.GetKey (KeyCode.R)) {
				controllable.OnHeld ();
			}
			else if (Input.GetKeyUp (KeyCode.R)) {
				controllable.OnReleased ();
			}
		}
	}
}
