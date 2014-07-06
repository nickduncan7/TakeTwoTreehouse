using UnityEngine;
using System.Collections;

public class BrightnessController : MonoBehaviour {

	public float fadeSpeed = 2f;            // How fast the light fades between intensities.
    public float changeMargin = 0.2f;       // The margin within which the target intensity is changed.
    public bool alarmOn;                    // Whether or not the alarm is on.


    private bool windingDown;
    private float targetIntensity;          // The intensity that the light is aiming for currently.
    
    void Awake ()
    {
        // When the level starts we want the light to be "off".
        light.intensity = 0f;
        
        // When the alarm starts for the first time, the light should aim to have the maximum intensity.
        windingDown = false;
        targetIntensity = 1;
    }
    
    
    void Update ()
    {
        
        Debug.Log(light.intensity);
        // If the light is on...
        if (alarmOn && !windingDown)
        {
            // ... Lerp the light's intensity towards the current target.
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, fadeSpeed * Time.deltaTime);

            // Check whether the target intensity needs changing and change it if so.
            CheckTargetIntensity();
        }
        else
        {
            // Otherwise fade the light's intensity to zero.
            light.intensity = Mathf.Lerp(light.intensity, 0f, fadeSpeed * 3f * Time.deltaTime);
            if (light.intensity < 0.002f)
                Application.LoadLevel("Main");
        }
    }
    
    
    void CheckTargetIntensity ()
    {
        // If the difference between the target and current intensities is less than the change margin...
        if(Mathf.Abs(targetIntensity - light.intensity) <= changeMargin)
        {
            // ... if the target intensity is high...
            if (targetIntensity == 1)
                // ... then set the target to low.
                windingDown = true;
                targetIntensity = 0;
        }
    }
}
