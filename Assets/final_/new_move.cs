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
    public Vector2 restrictedAreaMin = new Vector2(-5f, -5f); // 제한 영역의 최소 좌표
    public Vector2 restrictedAreaMax = new Vector2(5f, 5f);   // 제한 영역의 최대 좌표



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
        
        Vector2 frontVector = new Vector2(rigid.position.x + nextMove * 0.6f, rigid.position.y);

        //일정 영역 벗어나면 되돌리는 코드
        if (IsExitingRestrictedArea(transform.position))
        {
            Debug.Log("딱걸림");
            Turn(); // 방향 전환
            return; // 이동 중지
        }

    //   Debug.DrawRay(frontVector, Vector3.down, new Color(0, 1, 0));
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
        if (other.gameObject.tag == "enemy")
        { //같은 적끼리는 통과되는 문구
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
            return;
        }
        }
    //재귀함수
    void Think() {
        nextMove = Random.Range(-1, 2);
        //방향
         if (nextMove > 0)
    {
        spriteRenderer.flipX = true; // 오른쪽
    }
    else if (nextMove < 0)
    {
        spriteRenderer.flipX = false; // 왼쪽
    }

        //재귀함수 호출
        float nextThinkTime = Random.Range(2f, 5f);
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
        Invoke("Think", 3);
    }
    private void Die()
    {
        // 몹 사망 처리
        Destroy(gameObject);
    }
     private bool IsExitingRestrictedArea(Vector2 position)
    {
        // 제한 영역 바깥으로 나가려는지 확인
        if (position.x <= restrictedAreaMin.x && nextMove < 0)
        {
            return true; // 왼쪽 경계를 벗어나려고 함
        }
        if (position.x >= restrictedAreaMax.x && nextMove > 0)
        {
            return true; // 오른쪽 경계를 벗어나려고 함
        }
        if (position.y <= restrictedAreaMin.y || position.y >= restrictedAreaMax.y)
        {
            return true; // 위아래는 벗어나지 않게끔 로직 추가
        }
        return false;
    }
/*    void OnDrawGizmos() //이거 걍 디버깅용 시각화코드임 무시하셈
{
    // 제한된 영역 시각화
    Gizmos.color = Color.red; // 빨간색으로 표시
    Gizmos.DrawLine(new Vector3(restrictedAreaMin.x, restrictedAreaMin.y, 0),
                    new Vector3(restrictedAreaMax.x, restrictedAreaMin.y, 0));
    Gizmos.DrawLine(new Vector3(restrictedAreaMax.x, restrictedAreaMin.y, 0),
                    new Vector3(restrictedAreaMax.x, restrictedAreaMax.y, 0));
    Gizmos.DrawLine(new Vector3(restrictedAreaMax.x, restrictedAreaMax.y, 0),
                    new Vector3(restrictedAreaMin.x, restrictedAreaMax.y, 0));
    Gizmos.DrawLine(new Vector3(restrictedAreaMin.x, restrictedAreaMax.y, 0),
                    new Vector3(restrictedAreaMin.x, restrictedAreaMin.y, 0));
}
*/  
}