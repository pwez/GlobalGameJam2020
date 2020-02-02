using UnityEngine;

namespace util {
    public class RoomObjectManager : MonoBehaviour {

        public RoomObject[] roomObjects;
        public static RoomObjectManager instance;
        
        [SerializeField] private int repairedCount;

        private RoomObjectManager () {}
        
        private void Awake () {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy (gameObject);
            roomObjects = GetComponentsInChildren<RoomObject> ();
        }

        public void AdjustRepairedCount (int adjustAmount) {
            repairedCount += adjustAmount;
        }

        public float GetPercentageRepaired () {
            return Mathf.Clamp01((float)repairedCount / (float)roomObjects.Length);
        }

    }
}