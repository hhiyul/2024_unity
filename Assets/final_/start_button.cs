using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_button : MonoBehaviour
{
    public string stage1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("stage1");
    }
}
