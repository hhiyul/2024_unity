using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float fallSpeed = 8.0f;
    private Rigidbody2D rb;
    public float spawnInterval = 2.0f;
    void Start()
    {
        StartCoroutine(SpawnArrows());
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = fallSpeed;
        }
    }

  /*  void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            Vector3 generatorPosition = this.transform.position;
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            go.transform.position = new Vector3(generatorPosition.x, generatorPosition.y, generatorPosition.z);
        }
    }*/
    IEnumerator SpawnArrows()
    {
        yield return new WaitForSeconds(spawnInterval/2);
        while (true)
        {
            // 화살 생성
            Vector3 generatorPosition = this.transform.position;
            GameObject go = Instantiate(arrowPrefab);
            go.transform.position = generatorPosition;

            // 지정된 시간 동안 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
