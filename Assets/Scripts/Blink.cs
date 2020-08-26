using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    
    MeshRenderer[] eyes;
    // Start is called before the first frame update
    void Start()
    {
        eyes = GetComponentsInChildren<MeshRenderer>();
        Invoke("BlinkNow", 2);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void BlinkNow()
    {
        foreach (MeshRenderer eye in eyes)
        {
            eye.enabled = false;
        }

        Invoke("StopBlink", 0.2f);

    }

    void StopBlink()
    {
        foreach (MeshRenderer eye in eyes)
        {
            eye.enabled = true;
        }
        Invoke("BlinkNow", 2);

    }
}
