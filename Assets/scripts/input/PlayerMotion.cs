using UnityEngine;

namespace input {
	public class PlayerMotion : MonoBehaviour {

		public float speed;
		
		private Vector2 direction;
		
		void Update () {
			Vector2 velocity = speed * direction;
			transform.Translate (velocity * Time.deltaTime);
		}

		public void setDirection (Vector2 directionalInput) {
			direction = directionalInput;
		}

	}
}
