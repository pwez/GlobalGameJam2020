using interfaces;
using UnityEngine;
using util;

public class RoomObject : MonoBehaviour, Repairable {

    public Meter displayMeter;
    
    public Sprite repairedSprite;
    public AudioClip repairSFX;
    public int tapsToRepair;
    private float tapsToRepairCounter;

    public Sprite brokenSprite;
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
        displayMeter.enabled = false;
    }

    public void Repair () {
        if (isBroken) {
            tapsToRepairCounter--;
            if (tapsToRepairCounter == 0) {
                tapsToRepairCounter = tapsToRepair;
                isBroken = false;
                AudioManager.instance.PlaySound (repairSFX);
                RoomObjectManager.instance.AdjustRepairedCount (1);
                spriteRenderer.sprite = repairedSprite;
            }
        }
    }

    public void Break () {
		if (!isBroken) {
            tapsToBreakCounter--;
            if (tapsToBreakCounter == 0) {
                tapsToBreakCounter = tapsToBreak;
                isBroken = true;
                AudioManager.instance.PlaySound (breakSFX);
                RoomObjectManager.instance.AdjustRepairedCount (-1);
                spriteRenderer.sprite = brokenSprite;
            }
		}
    }
}