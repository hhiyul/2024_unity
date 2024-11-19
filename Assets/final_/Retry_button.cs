using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry_button : MonoBehaviour
{
    public string main;

    void Start(){

    }
    void Updata(){

    }
    public void Load() {
        SceneManager.LoadScene("main");
    }
}

