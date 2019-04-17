using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour {

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("Sounds").GetComponent<SoundManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        soundManager.PlayRandomSound();
        Destroy(gameObject);
    }
}
