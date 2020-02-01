using UnityEngine;
using UnityEngine.UI;

namespace util {
	public class TimeKeeper : MonoBehaviour {
		
		public float countdownTime;
		public Text countdownText;

		[SerializeField]
		private float counter;

		public LevelManager levelManager;
		
		void Start () {
			counter = countdownTime;
		}
	
		void Update () {
			if (counter > 0) {
				counter -= Time.deltaTime;
				countdownText.text = counter.ToString ("0");
				if (counter <= 0) {
					levelManager.EndLevel ();
					counter = 0;
				}
			}
		}

	}
}
