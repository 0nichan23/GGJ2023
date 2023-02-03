using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    public float maxProgress = 1;
    public Transform progressBarContent;

    private Vector2 initialScale;

    private void Start()
    {
        initialScale = progressBarContent.transform.localScale;
    }

    public void SetProgress(float progress)
    {
        var relativeProgress = progress / maxProgress;
        progressBarContent.transform.localScale = initialScale * new Vector2(relativeProgress, 1);
    }
}
