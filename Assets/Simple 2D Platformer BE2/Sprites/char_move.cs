using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_move : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    float jumpForce = 270.0f;
    float walkForce = 50.0f;
    float maxWalkSpeed = 4.0f;

    int maxJumpCount = 2;
    int jumpCount = 0;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            jumpCount++;
        }


        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1;
        if(Input.GetKey(KeyCode.LeftArrow)) key = -1;
        

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if(speedx < this.maxWalkSpeed || IsInAir())
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
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
