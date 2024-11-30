using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//땅끝으로 가도 안떨어지는 ai
public class new_move : MonoBehaviour
{
    Rigidbody2D rigid;
    private int nextMove;
    private SpriteRenderer spriteRenderer;
    public string gameover;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Think();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        this.rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        //자기 한수 앞
        Vector2 frontVector = new Vector2(rigid.position.x + nextMove * 0.6f, rigid.position.y);
        //Platform Check
        Debug.DrawRay(frontVector, Vector3.down, new Color(0, 1, 0));
        //빔을 쏘고 빔을 맞은 오브젝트에 대한 정보 (여기서는 layer가 Platform인 오브젝트만 받겠다.)
        RaycastHit2D rayhit = Physics2D.Raycast(frontVector, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayhit.collider == null) {
            Turn();
        }
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
        }
    //재귀함수
    void Think() {
        nextMove = Random.Range(-1, 2);
        //방향
        if (nextMove != 0) {
            spriteRenderer.flipX = nextMove == 1;
        }

        //재귀함수 호출
        float nextThinkTime = Random.Range(2f, 6f);
        Invoke("Think", nextThinkTime);
    }

    void Turn() {
        //방향 바꾸기
        nextMove *= -1;
        //캐릭터 뒤집기
        spriteRenderer.flipX = nextMove == 1;
        //생각 취소
        CancelInvoke();
        //다시 생각
        Invoke("Think", 5);
    }
    private void Die()
    {
        // 몹 사망 처리
        Destroy(gameObject);
    }

}