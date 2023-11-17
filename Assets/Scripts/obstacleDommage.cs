using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleDommage : MonoBehaviour

{
    public GameObject handleDommageTo;
    private sampleTest refTo;
    // Start is called before the first frame update
    void Start()
    {
        refTo = handleDommageTo.GetComponent<sampleTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1-" + handleDommageTo.tag);
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("2-" + handleDommageTo.tag);
            refTo.takeDommage();

        }
    }
}
