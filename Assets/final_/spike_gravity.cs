using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Gameover_manager gameOverManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.006f, 0);

        if(transform.position.y < -14)
        {
            Destroy(gameObject);
        }


    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player")
        {
            Die();
            gameOverManager.OnPlayerDeath();
        }
    }
    private void Die()
    {
        // 몹 사망 처리
        Destroy(gameObject);
    }
}
