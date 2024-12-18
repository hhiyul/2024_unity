using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class char_move : MonoBehaviour
{
    
    private Vector3 startPosition;
    public Gameover_manager gameOverManager;
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 170.0f;
    float maxWalkSpeed = 5.0f;
    

    public int maxJumpCount = 2;
    public int jumpCount = 0;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
           Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("isjumping"))
        {
            animator.SetBool("isjumping", true);
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount == 2)
        {
            animator.SetBool("isdoublejumping", true);
        }


        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) key = 1;
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) key = -1;

        this.rigid2D.velocity = new Vector2(key * maxWalkSpeed, this.rigid2D.velocity.y);


        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (transform.position.y < -5)
        {
            gameOverManager.OnPlayerDeath();
        }
        //애니메이션
        if(rigid2D.velocity.normalized.x == 0)
        {
            animator.SetBool("iswalking", false);
        }
        else
        {
            animator.SetBool("iswalking", true);
        }
        
        
    }
    void FixedUpdate()
        {
          //  Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0,1,0));
           if(rigid2D.velocity.y < 0){
                Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);
             
                RaycastHit2D rayHit = Physics2D.Raycast(rayOrigin, Vector3.down, 0.6f, LayerMask.GetMask("Platform"));
            
                if(rayHit.collider != null)
                {
                //    Debug.Log(rayHit.collider.name);
                    if(rayHit.distance < 0.1f)
                    {
                        //Debug.Log(rayHit.collider.name);
                        animator.SetBool("isdoublejumping", false);
                        animator.SetBool("isjumping", false);
                    }

                }
            }

        }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Vector2 normal = contact.normal;

            if (normal.y > 0.5f)
            {
                jumpCount = 0;
                break;
            }
        }

        if(collision.gameObject.CompareTag("enemy"))
        {
            animator.SetBool("isjumping", false);
            animator.SetBool("isdoublejumping", false);
        }

        if(collision.gameObject.CompareTag("spike"))
        {
            gameOverManager.OnPlayerDeath();
        }
     /*   if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
            rigid2D.velocity = Vector2.zero; 

        }*/
        
    }
    void Jump()
    {
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
        rigid2D.AddForce(Vector2.up * jumpForce);
        jumpCount++;
        GetComponent<AudioSource>().Play();
    }
    public void ResetPlayer()
    {
        // 위치 및 물리 상태 초기화
        transform.position = startPosition; 
        rigid2D.velocity = Vector2.zero;  // 속도 초기화
        rigid2D.angularVelocity = 0f;     // 회전 속도 초기화
        gameObject.SetActive(true);  // 캐릭터 활성화
    }
}
