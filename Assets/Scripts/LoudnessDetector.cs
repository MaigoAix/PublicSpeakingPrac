using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LoudnessDetector : MonoBehaviour
{
    public AudioLoudnessDetection detector;
    public float loudnessSensibility = 100;
    public float threshold = 10f;

        // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        Debug.Log(detector.GetLoudnessFromMicrophone() * loudnessSensibility);
        if (loudness >= threshold)
            Debug.Log("Too Loud");// display on ui 'too loud'

        else
            Debug.Log("Too Quiet");    // display on ui 'too Quiet'
    }
}
