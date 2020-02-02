using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public Transform bar;


    public void SetProgressBar(int i, int length)
    {
        bar.localScale = new Vector3(((float)i / (float)length), 1f, 0.0f);
    }
}
