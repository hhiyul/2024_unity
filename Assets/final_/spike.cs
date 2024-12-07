using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spike : MonoBehaviour
{
    public Gameover_manager gameOverManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D other){  
        // Player 태그를 가진 오브젝트와 충돌했을 때만 동작
        if(other.gameObject.tag == "Player")
        {
            // "clear"라는 이름의 씬으로 전환
            gameOverManager.OnPlayerDeath();
        }
    }
}
