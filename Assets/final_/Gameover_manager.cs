using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameover_manager : MonoBehaviour
{
     public GameObject gameOverUI; // Game Over UI Panel 연결

    // 캐릭터가 죽었을 때 호출되는 메서드
    
        public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true); // Game Over UI 활성화
        Time.timeScale = 0f; // 게임 시간 정지 (선택 사항)
    }

    // 게임 재시작 버튼 이벤트
    public void RestartGame()
    {
        Time.timeScale = 1f; // 게임 시간 다시 정상화
        char_move player = FindObjectOfType<char_move>();
        if (player != null)
        {
            player.ResetPlayer();
        }
        if (Scoremanager.instance != null)
        {   
            Scoremanager.instance.ResetScore();
        }
         UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        // 현재 씬 재시작
    }
     public void Gototitle()
    {
       SceneManager.LoadScene("Title"); // 게임 종료
    }
}
