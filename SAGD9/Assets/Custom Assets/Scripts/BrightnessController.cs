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
        GetComponent<Light>().intensity = 0f;
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
                        GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, highIntensity, fadeSpeed*Time.deltaTime);

                        if (Mathf.Abs(GetComponent<Light>().intensity) >= (highIntensity - changeMargin))
                        {
                            windingDown = true;
                        }
                    }
                    else
                    {
                        GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, lowIntensity, fadeSpeed*1.8f*Time.deltaTime);
                        if (GetComponent<Light>().intensity <= 0.008f)
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
                        GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, highIntensity, fadeSpeed*Time.deltaTime);

                        if (Mathf.Abs(GetComponent<Light>().intensity) >= (highIntensity - changeMargin))
                        {
                            windingDown = true;
                        }
                    }
                    else
                    {
                        GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, lowIntensity, fadeSpeed*1.8f*Time.deltaTime);
                        if (GetComponent<Light>().intensity <= 0.008f)
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
