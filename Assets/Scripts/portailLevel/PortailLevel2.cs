using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortailLevel2 : MonoBehaviour
{
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        SceneManager.LoadScene(tag);
    }

    


}
