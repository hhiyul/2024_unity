using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class headattack : MonoBehaviour
{
    // Start is called before the first frame update
    public float respawnTime = 2f; // 몹이 재생성되는 시간
    private Vector3 spawnPosition; // 몹의 초기 위치
    public GameObject enemyPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D other){  
        // Player 태그를 가진 오브젝트와 충돌했을 때 게임오버로 가는 동작
        if(other.gameObject.tag == "Player")
        {
            if (other.transform.position.y > transform.position.y + 0.5f)
            {
                // 몹 죽음 처리
                Die();

                Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();

                if (playerRb != null)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, 5f); // 점프 높이 설정
                }
                char_move playerScript = other.gameObject.GetComponent<char_move>();
                if (playerScript != null)
                {
                    playerScript.jumpCount = 0; // 점프 카운트 초기화
                }
            }
            }
            else
            {
                // 머리를 밟지 않고 충돌하면 플레이어가 죽음
                SceneManager.LoadScene("gameover");
            }
        }

    
    private void Die()
    {
        // 몹 사망 처리
        GetComponent<Renderer>().enabled = false; // 스프라이트 렌더러 비활성화
        GetComponent<Collider2D>().enabled = false; // 충돌 처리 비활성화
        StartCoroutine(Respawn());
    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("몹 재생성 완료");
    }
}
