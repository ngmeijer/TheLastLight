using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLighting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogColor = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time * 0.2f, 1));
    }
}
