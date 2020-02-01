using UnityEngine;

namespace util {
	public class Meter : MonoBehaviour {

		public Color increaseColor;
		public Color decreaseColor;
		public Transform meter;
		private SpriteRenderer spriteRenderer;
		
		void Awake () {
			spriteRenderer = GetComponent<SpriteRenderer> ();
		}

		// Use this for initialization
		void Start () {
			meter.localScale = new Vector3(0.5f, 1f, 0f);
		}

		public void AdjustProgress (float amount) {
			spriteRenderer.color = amount > 0 ? increaseColor : decreaseColor;
			meter.localScale = new Vector3(amount, 1f, 0f);
		}
	}
}
