using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsRotation : MonoBehaviour {

    private GameObject fpsController;
    private bool openDoors = false;
    private float currentlyDegreeOpened = 0;

    private void Start()
    {
        fpsController = GameObject.Find("FPSController");
    }
    private void OnMouseDown()
    {
        float distance = Vector3.Distance(fpsController.transform.position, gameObject.transform.position);
        if (distance < 5)
            openDoors = true;
    }

    private void Update()
    {
        if (openDoors)
        {
            if (currentlyDegreeOpened < 90)
            {
                currentlyDegreeOpened += 1;
                transform.Rotate(0, 1f, 0);
            }
                
        }
    }
}
