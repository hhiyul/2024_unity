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
    public Gameover_manager gameOverManager;
    
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

    private void OnCollisionEnter2D(Collision2D collision){

        // Player 태그를 가진 오브젝트와 충돌했을 때 게임오버로 가는 동작
        if(collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y > transform.position.y + 0.5f)
            {
                // 몹 죽음 처리
                Die();

                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

                if (playerRb != null)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, 5f); // 반발 점프 높이 설정
                }
            }
            else
            {
                // 머리를 밟지 않고 충돌하면 플레이어가 죽음
                gameOverManager.OnPlayerDeath();
            }

        }
        if (collision.gameObject.tag == "enemy")
        { //같은 적끼리는 통과되는 문구
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            return;
        }
    
    }
    private void OnCollisionStay2D(Collision2D collision)
    { //이거 안배운거긴한데 콜리전stay로 벡터x좌표로 벽이랑 부딪히면 방향전환시킴
    // Ground 태그와의 충돌 처리
    if (collision.gameObject.tag == "Ground")
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Vector2 normal = contact.normal;

            // 벽에 닿았을 때 (좌우 방향)
            if (Mathf.Abs(normal.x) > 0.5f && Mathf.Abs(normal.y) < 0.5f)
            {
                direction *= -1; // 방향 반전
                spriteRenderer.flipX = direction < 0; // 스프라이트 방향 반전
                return;
            }
        }
    }
}    
    private void Die()
    {
        // 몹 사망 처리
        Destroy(gameObject);
    }

}

