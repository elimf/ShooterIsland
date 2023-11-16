using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class playerControl : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletSpeed;
    bool fired = false;
    public GameObject targetFrom;
    public sampleTest refTargetFrom;
    // Start is called before the first frame update
    void Start()
    {
        refTargetFrom = targetFrom.GetComponent<sampleTest>();

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal"),0);

        if(Input.GetAxis("Fire1") == 1) 
        {
            Vector3 positionClic = Input.mousePosition;


            Vector3 positionDansScene = Camera.main.ScreenToWorldPoint(positionClic);
            Debug.Log(positionDansScene);
            

            if (fired == false) 
            {
                fired = true;
            GameObject BulletInstance = Instantiate(BulletPrefab);
            BulletInstance.transform.SetParent(transform.parent);
                if (positionDansScene.x <= transform.position.x) { Debug.Log("d"); return; }
                    BulletInstance.transform.position = new Vector3(transform.position.x + 2.10f , transform.position.y, transform.position.z);
            BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3((positionDansScene.x - transform.position.x) + refTargetFrom.indiceSpeed, positionDansScene.y - transform.position.y, 0) ;
            Destroy(BulletInstance.gameObject,5); 
            }
        }
        else 
        {
            fired = false;
        }

    }
}
