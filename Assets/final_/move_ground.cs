using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ground : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2f;
    public float height = 3f;
    private bool movingUp = true;
     private Transform platform;
    private Vector3 lastPlatformPosition;

    public float waitsecond;
    public float delay;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        waitsecond = Random.Range(1,5);
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        delay = Random.Range(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
    rb.MovePosition(new Vector2(startPos.x, newY));
    }
    IEnumerator DelayedStart(float delay)
    {
        // 초기 지연 시간 대기
        yield return new WaitForSeconds(delay);

        // 왕복 이동 코루틴 시작
        StartCoroutine(MoveUpDown());
    }
     IEnumerator MoveUpDown()
    {
        while (true)
        {
            // 목표 위치 계산
            float targetY = movingUp ? transform.position.y + height : transform.position.y - height;
            Vector2 targetPos = new Vector2(transform.position.x, targetY);

            // 목표 위치로 부드럽게 이동
            while (Vector2.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                yield return null;
            }

            // 방향 전환
            movingUp = !movingUp;

            // 잠시 대기
            yield return new WaitForSeconds(waitsecond);
        }
    }
    
}
