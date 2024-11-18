using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry_button : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("main");
    }
    
    
}

