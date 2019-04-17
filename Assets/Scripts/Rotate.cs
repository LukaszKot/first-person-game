using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float x=0f;
    public float y=1f;
    public float z=0f;

	void Start () {
		
	}
	
	void Update () {

        transform.Rotate(new Vector3(x, y, z));
	}
}
