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

        if(other.gameObject.tag == "Player")
        {
            if (other.transform.position.y > transform.position.y + 0.5f) 
            // 위에서 몹을 밟으면
            {
                // 몹 처치
                Die();

                Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();

                if (playerRb != null)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, 5f); // 반발력추가
                }
                char_move playerScript = other.gameObject.GetComponent<char_move>();
                if (playerScript != null)
                {
                    playerScript.jumpCount = 0; // 죽이는데 성공하면 다시 더블점프 가능
                }
            }
            }
            else
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                PlayerPrefs.SetString("LastPlayedScene", currentSceneName);
                PlayerPrefs.Save();
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
    }
}
