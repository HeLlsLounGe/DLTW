using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    float timer = 0;
    [SerializeField] float timeTillLoad = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeTillLoad)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
