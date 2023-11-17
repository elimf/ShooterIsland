using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortailLevelBoss : MonoBehaviour
{

   public  GameObject ship;
   
    void Start()
    {
        ship.SetActive(true);
        StartCoroutine(removePortalwithTime(7));
        gameObject.SetActive(false);


    }
    IEnumerator removePortalwithTime(int time)

    {
        
       
            yield return new WaitForSeconds(time);
      


    }
    // Update is called once per frame
    void Update()
    {
    }

    

    


}
