using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnTriggerEnter2D(Collider2D collision)
    {
        // 태그가 Player인 오브젝트와 충돌했을 때
        if (collision.CompareTag("Player"))
        {
            // ScoreManager에 점수 추가
            Scoremanager.instance.score += 10;
            Scoremanager.instance.UpdateScoreText();

            // 코인 오브젝트 파괴
            Destroy(gameObject);
        }
    }
}
