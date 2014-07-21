using UnityEngine;
using System.Collections;

public class BrightnessController : MonoBehaviour {

	public float fadeSpeed = 2.4f;            // How fast the light fades between intensities.
    public float changeMargin = 0.02f;       // The margin within which the target intensity is changed.
    public bool alarmOn;                    // Whether or not the alarm is on.

    public Transform backgroundPlane;
    public Transform knifeSharkLogo;
    public Transform sagdc9Logo;

    private int count = 0;
    public float highIntensity = 1f;        // The maximum intensity of the light whilst the alarm is on.
    public float lowIntensity = 0.0002f;       // The minimum intensity of the light whilst the alarm is on.
    private bool windingDown = false;

    private float timer;
    void Awake ()
    {
        // When the level starts we want the light to be "off".
        light.intensity = 0f;
    }
    
    
    void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            if (count == 0)
            {
                if (alarmOn)
                {
                    if (!windingDown)
                    {
                        // ... Lerp the light's intensity towards the current target.
                        light.intensity = Mathf.Lerp(light.intensity, highIntensity, fadeSpeed*Time.deltaTime);

                        if (Mathf.Abs(light.intensity) >= (highIntensity - changeMargin))
                        {
                            windingDown = true;
                        }
                    }
                    else
                    {
                        light.intensity = Mathf.Lerp(light.intensity, lowIntensity, fadeSpeed*1.8f*Time.deltaTime);
                        if (light.intensity <= 0.008f)
                        {
                            windingDown = false;
                            count++;
                        }
                    }
                }
            }
            else if (count == 1)
            {
                knifeSharkLogo.position = new Vector3(0, 0, -2);
                sagdc9Logo.position = new Vector3(0, 0, 2);
                // .f the light is on...
                if (alarmOn)
                {
                    if (!windingDown)
                    {
                        // ... Lerp the light's intensity towards the current target.
                        light.intensity = Mathf.Lerp(light.intensity, highIntensity, fadeSpeed*Time.deltaTime);

                        if (Mathf.Abs(light.intensity) >= (highIntensity - changeMargin))
                        {
                            windingDown = true;
                        }
                    }
                    else
                    {
                        light.intensity = Mathf.Lerp(light.intensity, lowIntensity, fadeSpeed*1.8f*Time.deltaTime);
                        if (light.intensity <= 0.008f)
                        {
                            windingDown = false;
                            count++;
                        }
                    }
                }
            }
            else if (count == 2)
            {
                Application.LoadLevel("Main");
            }
        }
    }
}
