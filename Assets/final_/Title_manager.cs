using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title_manager : MonoBehaviour
{
    // Start is called before the first frame update
     public void StartGame()
    {
        // 점수 초기화
        if (Scoremanager.instance != null)
        {
            Scoremanager.instance.ResetScore();
        }
        Time.timeScale = 1f;

        // 게임 씬으로 전환
        SceneManager.LoadScene("stage1"); // stage1 시작
    }

    public void RestartGame()
    {
        // 점수 초기화
        if (Scoremanager.instance != null)
        {
            Scoremanager.instance.ResetScore();
        }

        // 게임 씬으로 전환
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재시작
    }

    public void QuitGame()
    {
        Application.Quit(); // 게임 종료
    }
}
