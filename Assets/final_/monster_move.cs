using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//직선운동만 하다 땅끝으로가면 그냥 떨어짐
public class monster_move : MonoBehaviour
{
    public float speed = 2f;
    private int direction = -1; // 이동 방향 (1: 오른쪽, -1: 왼쪽)
    public string gameover;
    Animator animator;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        GetComponent<SpriteRenderer>().flipX = direction > 0;
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
            }
            else
            {
                // 머리를 밟지 않고 충돌하면 플레이어가 죽음
                SceneManager.LoadScene("gameover");
            }
        }


        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Ground")
        {
            direction *= -1; // 방향 반전

            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = direction < 0;    // 왼쪽 이동 시 반전
            }
        }
    }
     private void Die()
    {
        // 몹 사망 처리
        Destroy(gameObject);
    }
    

}
