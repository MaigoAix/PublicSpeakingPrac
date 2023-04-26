using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromMicrophone : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Start recording audio from the microphone
        source.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
        source.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;



        // lerp value from minscale to maxscale
        // transform.localScale = (Vector3.Lerp(minScale, maxScale, loudness) * Time.deltaTime * speed);
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}