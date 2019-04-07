using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuManager : MonoBehaviour
{
    private bool isVisible;
    private Component[] buttons;
    private GameObject fpsController;
    private string currentSceneName;

    void Start()
    {
        isVisible = true;
        buttons = GetComponentsInChildren(typeof(Button));
        fpsController = GameObject.Find("FPSController");
        currentSceneName = SceneManager.GetActiveScene().name;
        (buttons[0] as Button).onClick.AddListener(() =>
        {
            if (currentSceneName == "FirstScene") return;
            SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
        });
        (buttons[1] as Button).onClick.AddListener(() =>
        {
            if (currentSceneName == "SecondScene") return;
            SceneManager.LoadScene("SecondScene", LoadSceneMode.Single);
        });
        (buttons[2] as Button).onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isVisible = !isVisible;
            gameObject.GetComponent<Canvas>().enabled = isVisible;
            fpsController.GetComponent<FirstPersonController>().enabled = !isVisible;
        }

    }
}
