using UnityEngine;

namespace input {
	public class PlayerMotion : MonoBehaviour {
		
		public float speed;
		public AnimationClip idleDown, idleLeft, idleRight, idleUp;
		public AnimationClip walkDown, walkLeft, walkRight, walkUp;
		private Animator animator;
		
		private Vector2 direction;

		void Awake () {
			animator = GetComponent<Animator> ();
		}
		
		void Update () {
			Vector2 velocity = speed * direction;
			transform.Translate (velocity * Time.deltaTime);

//			animator.SetFloat ("SpeedX", velocity.x);
//			animator.SetFloat ("SpeedY", velocity.y);			
//			animator.SetFloat ("DirectionX", direction.x);
//			animator.SetFloat ("DirectionY", direction.y);
//			
//			if (velocity != Vector2.zero) {
//				AnimateWalking ();
//			}
		}

		public void AnimateIdle () {
			
		}
		
		public void AnimateWalking () {
			// Moving up
			if (direction.y > 0 && Mathf.Abs(direction.y) > Mathf.Abs(direction.x)) {
				animator.Play (walkUp.name);
			} 
			// Moving down
			else if (direction.y < 0 && Mathf.Abs (direction.y) > Mathf.Abs (direction.x)) {
				animator.Play (walkDown.name);
			}
			// Moving Left
			else if (direction.x < 0 && Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) {
				animator.Play (walkLeft.name);
			}
			// Moving Left
			else if (direction.x > 0 && Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) {
				animator.Play (walkRight.name);
			}
		}

		public void setDirection (Vector2 directionalInput) {
			direction = directionalInput;
		}

	}
}
