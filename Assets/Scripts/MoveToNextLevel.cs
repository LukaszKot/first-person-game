using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("SecondScene", LoadSceneMode.Single);
    }
}
