using UnityEngine;
using TMPro;

public class NewSceneManager : MonoBehaviour
{
    public TextMeshProUGUI newScoreText;

    void Start()
    {
        if (Scoremanager.instance != null)
        {
            Scoremanager.instance.SetScoreText(newScoreText);
        }
    }
}