using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletSpeed;
    bool fired = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Fire1") == 1) 
        {
            if (fired == false) 
            {
                fired = true;
            GameObject BulletInstance = Instantiate(BulletPrefab);
            BulletInstance.transform.SetParent(transform.parent);
            BulletInstance.transform.position = new Vector3(transform.position.x, transform.position.y+1.10f, transform.position.z);
            BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(0, BulletSpeed, transform.position.z);
            Destroy(BulletInstance.gameObject,5); 
            }
        }
        else 
        {
            fired = false;
        }

    }
}
