using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear_flag : MonoBehaviour
{
    public string gameOverSceneName = "gameover";
    public string clear;
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
            LoadNextStage();
        }
    }

     public void LoadNextStage() //깃발에 도착하면 다음스테이지 불러오는 함수
    {
        // 현재 활성화된 씬의 빌드 인덱스 가져오기
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 다음 씬 인덱스 계산
        int nextSceneIndex = currentSceneIndex + 1;

        // 게임오버 씬으로 넘어가는 거 막는 문구
        string nextSceneName = SceneUtility.GetScenePathByBuildIndex(nextSceneIndex);
        if (nextSceneName.Contains(gameOverSceneName)) // 게임오버 씬인지 확인
        {
            return;
        }

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // 다음 씬 로드
            SceneManager.LoadScene(nextSceneIndex);
        }
        else //다음스테이지 없으면 클리어씬 출력
        {
            SceneManager.LoadScene("clear");
        }
    }
}
