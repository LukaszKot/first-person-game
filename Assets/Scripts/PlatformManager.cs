using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    public float beginning=18;
    public float ending=26;
    private float rotation = 0.05f;

    private GameObject movedObject;
    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(rotation, 0, 0);
        if (movedObject != null)
        {
            movedObject.transform.Translate(rotation, 0, 0, Space.World);
        }
        if (transform.position.x < ending)
        {
            rotation *= -1;
        }
        if (transform.position.x > beginning)
        {
            rotation *= -1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name=="FPSController")
        {
            movedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            movedObject = null;
        }
    }
}
