using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject lightObject;
    Light light; 

    // Start is called before the first frame update
    void Start()
    {
        light = lightObject.GetComponent<Light>();
        StartCoroutine(lightSwitch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator lightSwitch()
    {
        while (true)
        {
            while (light.intensity > 0)
            {
                light.intensity -= (Time.deltaTime * 6);
                yield return null;
            }
            while (light.intensity < 30)
            {
                light.intensity += (Time.deltaTime * 6);
                yield return null;
            }
        }
    }
}
