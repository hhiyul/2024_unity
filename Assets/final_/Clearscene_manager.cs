using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clearscene_manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
         if (Scoremanager.instance != null)
        {
            int totalScore = Scoremanager.instance.GetScore();
            scoreText.text = "총 점수: " + totalScore;
        }
        else
        {
            scoreText.text = "저런...";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
