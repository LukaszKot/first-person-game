using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public int Score { get; private set; }

    public void AddScore()
    {
        Score++;
        text.text = "Score: " + Score + "/3";
    }

    private Text text;
    private Font font;


    void Start () {
        Score = 0;
        text = GetComponentInChildren(typeof(Text)) as Text;
        font = Resources.Load("Fonts/Pacifico") as Font;
        text.font = font;
    }
}
