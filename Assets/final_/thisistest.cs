using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;
    void Start()
    {
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            Vector3 generatorPosition = this.transform.position;
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            go.transform.position = new Vector3(generatorPosition.x, generatorPosition.y, generatorPosition.z);
        }
    }
}
