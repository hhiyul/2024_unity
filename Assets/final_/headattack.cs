using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class headattack : MonoBehaviour
{
    // Start is called before the first frame update
    public Gameover_manager gameOverManager;
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
                // 머리를 밟지 않고 충돌하면 플레이어가 죽음
                gameOverManager.OnPlayerDeath();
            }

        }

    
    private void Die()
    {
        Destroy(gameObject);    
    }
    
}
