using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private Text mytext;
    private Font font;

    void Start () {
        mytext = GetComponentInChildren(typeof(Text)) as Text;
        font = Resources.Load("Fonts/Pacifico") as Font;

    }

    public void Display()
    {
        mytext.font = font;
        mytext.color = new Color(255,0,0);
        mytext.text = "Game Over";
    }
}
