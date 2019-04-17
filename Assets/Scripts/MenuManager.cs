using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuManager : MonoBehaviour {

    private Component[] buttons;
    private Canvas canvas;
    private FirstPersonController firstPersonController;
    private SpriteState onState;
    private Sprite soundOn;
    private SpriteState offState;
    private Sprite soundOff;
    private bool isAudioOn;
    private Image audioImage;
    private Button audioButton;

    void Start () {
        buttons = GetComponentsInChildren(typeof(Button));
        canvas = gameObject.GetComponent<Canvas>();
        var player = GameObject.Find("FPSController");
        if(player!=null)
        {
            firstPersonController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        }

        soundOn = Resources.Load<Sprite>("Sprites/sound-on");
        Sprite soundOnHover = Resources.Load<Sprite>("Sprites/sound-on-hover");
        Sprite soundOnClick = Resources.Load<Sprite>("Sprites/sound-on-click");
        soundOff = Resources.Load<Sprite>("Sprites/sound-off");
        Sprite soundOffHover = Resources.Load<Sprite>("Sprites/sound-off-hover");
        Sprite soundOffClick = Resources.Load<Sprite>("Sprites/sound-off-click");
        onState = new SpriteState();
        offState = new SpriteState();
        onState.highlightedSprite = soundOnHover;
        onState.pressedSprite = soundOnClick;
        offState.highlightedSprite = soundOffHover;
        offState.pressedSprite = soundOffClick;

        isAudioOn = true;

        (buttons[0] as Button).onClick.AddListener(() =>
        {
            SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
        });
        (buttons[1] as Button).onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SecondScene", LoadSceneMode.Single);
        });
        var button = (buttons[2] as Button).gameObject;
        audioImage = button.GetComponent<Image>();
        audioButton = button.GetComponent<Button>();
        (buttons[2] as Button).onClick.AddListener(() =>
        {
            if(isAudioOn)
            {
                audioImage.sprite = soundOff;
                audioButton.spriteState = offState;
            }
            else
            {
                audioImage.sprite = soundOn;
                audioButton.spriteState = onState;
            }
            isAudioOn = !isAudioOn;
            Unmark();
        });
        (buttons[3] as Button).onClick.AddListener(() =>
        {
            Application.Quit();
        });

        canvas.enabled = false;

    }


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            canvas.enabled = canvas.enabled ? false :  true;
            if(firstPersonController != null) firstPersonController.enabled = firstPersonController.enabled ? false : true;
        }
    }

    private void Unmark()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
