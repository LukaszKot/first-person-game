using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuManager : MonoBehaviour {

    private SoundManager soundManager;
    private Slider slider;
    private Dropdown dropdown;
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
    private Toggle toggle;

    void Start () {
        soundManager = GameObject.Find("Sounds").GetComponent<SoundManager>();
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
                soundManager.StopMusic();
            }
            else
            {
                audioImage.sprite = soundOn;
                audioButton.spriteState = onState;
                soundManager.PlayMusic();
            }
            isAudioOn = !isAudioOn;
            Unmark();
        });
        (buttons[3] as Button).onClick.AddListener(() =>
        {
            Application.Quit();
        });

        canvas.enabled = false;

        slider = GetComponentInChildren(typeof(Slider)) as Slider;
        slider.value = 0.3f;
        slider.onValueChanged.AddListener((float x) =>
        {
            soundManager.SetVolume(x);
            Unmark();
        });

        dropdown = GetComponentInChildren(typeof(Dropdown)) as Dropdown;
        toggle = GetComponentInChildren(typeof(Toggle)) as Toggle;
        dropdown.ClearOptions();
        List<string> resolutionsString = Screen.resolutions.Select(x =>
        {
            return x.width + "x" + x.height + " "+ x.refreshRate+"fps";
        }).ToList();

        dropdown.AddOptions(resolutionsString);
        dropdown.value = Screen.resolutions.ToList().IndexOf(Screen.currentResolution);
        dropdown.onValueChanged.AddListener((int index) =>
        {
            Screen.SetResolution(Screen.resolutions[index].width, Screen.resolutions[index].height, false);
            toggle.isOn = false;
            Unmark();
        });
        if (Screen.fullScreen) dropdown.interactable = false;
        toggle.isOn = Screen.fullScreen;
        toggle.onValueChanged.AddListener(SetResolution);

    }

    private void SetResolution(bool value)
    {
        Screen.fullScreen = value;
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            dropdown.interactable = true;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            dropdown.interactable = false;
        }
        Unmark();
    }


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Unmark();
            canvas.enabled = canvas.enabled ? false :  true;
            if(firstPersonController != null) firstPersonController.enabled = firstPersonController.enabled ? false : true;
        }
    }

    private void Unmark()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
