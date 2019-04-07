using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{

    private GameObject fpsController;
    private bool openTheDoors = false;
    private float angle = 0;
    void Start()
    {
        fpsController = GameObject.Find("FPSController");
    }

    private void OnMouseDown()
    {
        float distance = Vector3.Distance(transform.position, fpsController.transform.position);
        if (distance < 3)
            openTheDoors = true;
    }

    void Update()
    {
        if (openTheDoors)
        {
            var baseAngle = transform.parent.localEulerAngles.y;
            if (angle < 90f)
            {
                transform.parent.Rotate(0, 1, 0);
                angle += transform.parent.localEulerAngles.y - baseAngle;
            }
        }
    }
}
