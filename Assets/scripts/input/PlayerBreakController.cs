using System.Runtime.CompilerServices;
using interfaces;
using UnityEngine;

namespace input {
    public class PlayerBreakController : MonoBehaviour, Controllable {

        [SerializeField]
        private Repairable repairable;
        
        public void OnPressed () {
            if (repairable != null) {
                repairable.Break ();
            }
        }

        public void OnHeld () {}

        public void OnReleased () {}

        private void OnTriggerEnter2D (Collider2D other) {
            Repairable repairable = other.GetComponent<Repairable> ();
            if (repairable != null) {
                this.repairable = repairable;
            }
        }
        
        private void OnTriggerExit2D (Collider2D other) {
            if (repairable != null) {
                repairable = null;
            }
        }

    }
}