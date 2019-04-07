using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private GameObject lightOffObject;
    private GameObject player;
    private Light light;

    void Start()
    {
        lightOffObject = transform.Find("LampElement")
            .Find("group1").Find("pCylinderOFF").gameObject;
        player = GameObject.Find("FPSController");
        light = transform
            .Find("Point Light").GetComponent<Light>();
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < 10)
        {
            light.enabled = true;
            lightOffObject.SetActive(false);
        }
        else
        {
            light.enabled = false;
            lightOffObject.SetActive(true);
        }
    }
}
