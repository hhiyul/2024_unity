using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public AudioClip keys;

    public GameObject obstacle;    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){  
        // Player 태그를 가진 오브젝트와 충돌했을 때 게임오버로 가는 동작
        if (other.CompareTag("Player"))
        {
        
            AudioSource.PlayClipAtPoint(keys, transform.position);
            Destroy(gameObject);

            if (obstacle != null)
            {
                Destroy(obstacle);
            }
        }
    }
}