using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D other){  
        // Player 태그를 가진 오브젝트와 충돌했을 때만 동작
        if (other.CompareTag("Player"))
        {
            // "clear"라는 이름의 씬으로 전환
          //  Debug.Log("플레이어가 깃발에 닿음"); 충돌 확인 디버그
            SceneManager.LoadScene("gameover");
        }
    }
}
