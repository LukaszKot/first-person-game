using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour {

    private SoundManager soundManager;
    private ScoreManager scoreManager;

    private void Start()
    {
        soundManager = GameObject.Find("Sounds").GetComponent<SoundManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        scoreManager.AddScore();
        soundManager.PlayRandomSound();
        Destroy(gameObject);
    }
}
