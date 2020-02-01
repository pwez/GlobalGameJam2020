using interfaces;
using UnityEngine;
using util;

public class RoomObject : MonoBehaviour, Repairable {

    public Meter displayMeter;
    
    public Color repairColor;
    public AudioClip repairSFX;
    public int tapsToRepair;
    private float tapsToRepairCounter;

    public Color breakColor;
    public AudioClip breakSFX;
    public int tapsToBreak;
    private float tapsToBreakCounter;

    public bool isBroken;
    private SpriteRenderer spriteRenderer;

    private void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    private void Start () {
        tapsToRepairCounter = tapsToRepair;
        tapsToBreakCounter = tapsToBreak;
        isBroken = false;

        displayMeter.enabled = false;
        spriteRenderer.color = repairColor;
    }

    public void Repair () {
        if (isBroken) {
            tapsToRepairCounter--;
            if (tapsToRepairCounter == 0) {
                tapsToRepairCounter = tapsToRepair;
                isBroken = false;
                spriteRenderer.color = repairColor;
                AudioManager.instance.PlaySound (repairSFX);
                RoomObjectManager.instance.AdjustRepairedCount (1);
            }
        }
    }

    public void Break () {
		if (!isBroken) {
            tapsToBreakCounter--;
            if (tapsToBreakCounter == 0) {
                tapsToBreakCounter = tapsToBreak;
                isBroken = true;
                spriteRenderer.color = breakColor;
                AudioManager.instance.PlaySound (breakSFX);
                RoomObjectManager.instance.AdjustRepairedCount (-1);
            }
		}
    }
}