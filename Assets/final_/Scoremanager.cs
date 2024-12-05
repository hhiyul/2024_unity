using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    public static Scoremanager instance;
    public int score = 0; // 점수 변수
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        // 싱글톤 패턴 구현
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 삭제되지 않음
        }
        else
        {
            Destroy(gameObject); // 중복된 Scoremanager 제거
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin")) // 태그가 "Coin"인 경우
        {
            score += 10; // 점수 추가
            UpdateScoreText(); // UI 업데이트
            Destroy(collision.gameObject); // 코인 오브젝트 제거
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void SetScoreText(TextMeshProUGUI newScoreText)
    {
        scoreText = newScoreText;
        UpdateScoreText(); // 새 텍스트로 점수 표시 업데이트
    }
    
}
