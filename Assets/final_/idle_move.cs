using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_move : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 270.0f;
    float walkForce = 6.0f;
    float maxWalkSpeed = 3.0f;

    int maxJumpCount = 2;
    int jumpCount = 0;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount) //점프
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            jumpCount++;
        }


        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) key = 1;
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (!IsInAir())
        {
            if (speedx < this.maxWalkSpeed)
            {
                this.rigid2D.velocity = new Vector2(key * maxWalkSpeed, this.rigid2D.velocity.y);
            }
        }
        else
        {
        // 공중에서 속도가 maxWalkSpeed를 초과하지 않도록 제한
            if (speedx < maxWalkSpeed)
            {
            // 공중에서도 일정한 속도 내에서 이동 가능하게 설정
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }
            else
            {
            // 속도 제한을 넘는 경우에는 maxWalkSpeed로 고정
                this.rigid2D.velocity = new Vector2(key * maxWalkSpeed, this.rigid2D.velocity.y);
            }
        }   
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1); // 방향에 따라 캐릭터를 좌우 반전
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
    bool IsInAir()
    {
        // 캐릭터가 공중에 있는지 확인하는 함수
        return Mathf.Abs(rigid2D.velocity.y) > 0.01f;
    }

}
