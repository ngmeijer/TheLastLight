using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLighting : MonoBehaviour
{
    private bool redToBlue = true;
    private bool blueToYellow = false;
    private bool yellowToRed = false;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(RenderSettings.fogColor);
        if (redToBlue)
        {
            RenderSettings.fogColor = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time * 0.2f, 1));
            if(RenderSettings.fogColor == Color.blue)
            {
                redToBlue = false;
                blueToYellow = true;
            }
        }
        if (blueToYellow)
        {
            RenderSettings.fogColor = Color.Lerp(Color.blue, Color.yellow, Mathf.PingPong(Time.time * 0.2f, 1));
            if (RenderSettings.fogColor == Color.yellow)
            {
                blueToYellow = false;
                yellowToRed = true;
            }
        }
        if (yellowToRed)
        {
            RenderSettings.fogColor = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong(Time.time * 0.2f, 1));
            if (RenderSettings.fogColor == Color.red)
            {
                yellowToRed = false;
                redToBlue = true;
            }
        }
    }
}
