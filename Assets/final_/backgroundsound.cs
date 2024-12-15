using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundsound : MonoBehaviour
{
    private static backgroundsound instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        // 싱글톤 패턴: 인스턴스가 이미 존재하면 파괴
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 넘어가도 오브젝트 유지
        }
        else
        {
            Destroy(gameObject); // 기존 인스턴스가 있으면 새로 생성된 오브젝트 파괴
        }
    }
}
