using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float fallSpeed = 2.0f;
    private Rigidbody2D rb;
    public float spawnInterval;
    float Randommax = 11;
    float Randommin = 2;
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
        spawnInterval = Random.Range(Randommin,Randommax);
        yield return new WaitForSeconds(spawnInterval/3);
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Random.Range(Randommin,Randommax);
            // 화살 생성
            Vector3 generatorPosition = this.transform.position;
            GameObject go = Instantiate(arrowPrefab);
            go.transform.position = generatorPosition;
        }
    }
}
