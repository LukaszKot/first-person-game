using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLamp : MonoBehaviour {

    private GameObject lamp;

	void Start () {
        lamp = GameObject.Find("TheLight");
        lamp.SetActive(false);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="FPSController")
        {
            lamp.SetActive(true);
        }
    }
}
