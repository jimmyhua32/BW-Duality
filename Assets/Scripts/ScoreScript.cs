using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    private float time;
    private Text score;
    private Color currColor;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        time = 0;
        score.text = "0";
        currColor = score.color;
    }

    void Update()
    {
        time += Time.deltaTime;
        score.text = Convert.ToInt32(time).ToString();
    }

    public void Flip()
    {
        if (currColor == Color.black)
        {
            score.color = Color.white;
        } else
        {
            score.color = Color.black;
        }
        currColor = score.color;
    }
}
