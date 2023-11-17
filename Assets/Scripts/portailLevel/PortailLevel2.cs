using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortailLevel2 : MonoBehaviour
{
    public GameObject portail;

   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = portail.tag;
        if(collision.gameObject.tag == "Player"){
        SceneManager.LoadScene(tag);
        } 
    }

    


}
