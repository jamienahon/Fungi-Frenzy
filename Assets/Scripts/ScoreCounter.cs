using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    float startTime;
    public TextMeshProUGUI text;
    public float pointsPerSecond;
    void Start()
    {
        startTime = Time.time;
        text.text = 0.ToString();
    }

    void Update()
    {
        text.text = ((Time.time - startTime) * pointsPerSecond).ToString("n0");

        if (text.text.Length == 1)
            text.rectTransform.localPosition = new Vector3(135, 410, 0);
        if (text.text.Length == 2)
            text.rectTransform.localPosition = new Vector3(125, 410, 0);
        if (text.text.Length == 3)
            text.rectTransform.localPosition = new Vector3(110, 410, 0);
        if (text.text.Length == 4)
            text.rectTransform.localPosition = new Vector3(90, 410, 0);
        if (text.text.Length == 5)
            text.rectTransform.localPosition = new Vector3(85, 410, 0);
        if (text.text.Length == 6)
            text.rectTransform.localPosition = new Vector3(75, 410, 0);
    }
}
