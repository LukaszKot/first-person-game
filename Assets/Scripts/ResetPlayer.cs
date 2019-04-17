using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetPlayer : MonoBehaviour {

    private bool alreadyStarted = false;
    private GameOver gameOver;

    private void Start()
    {
        gameOver = GameObject.Find("GameOver").GetComponent<GameOver>();
    }

    void Update () {
		if(transform.position.y<50)
        {
            if(!alreadyStarted)
            {
                alreadyStarted = true;
                StartCoroutine(MakeTimeout());
            }
            
        }
	}

    public IEnumerator MakeTimeout()
    {
        gameOver.Display();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

}
