using UnityEngine;

namespace util {
    public class RoomObjectManager : MonoBehaviour {

        public RoomObject[] roomObjects;
        public static RoomObjectManager instance;

        public int initialRepairCount;
        [SerializeField]private int repairedCount;
        public ProgressBar progressbar;

        private RoomObjectManager () {}
        
        private void Awake () {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy (gameObject);
            roomObjects = GetComponentsInChildren<RoomObject> ();
        }

        void Start()
        {
//            foreach (RoomObject roomObject in roomObjects)
//            {
//                if (!roomObject.isBroken)
//                {
//                    repairedCount++;
//                }
//            }
//            progressbar.SetProgressBar(repairedCount, roomObjects.Length);
            repairedCount = initialRepairCount;
        }

        public void AdjustRepairedCount (int adjustAmount) {
            repairedCount += adjustAmount;
//            progressbar.SetProgressBar(repairedCount, roomObjects.Length);
        }

        public float GetPercentageRepaired () {
            return Mathf.Clamp01((float)repairedCount / (float)roomObjects.Length);
        }

        public int GetAmountRepaired () {
            return repairedCount;
        }
        
    }
}