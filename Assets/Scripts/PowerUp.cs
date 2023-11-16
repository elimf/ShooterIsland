using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float VerticalScreenLimit;
    public GameObject Player;
    float GasolinePrefabTimer = 5;
    public GameObject GasolinePrefab;
    // Start is called before the first 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Player != null)
        {
            GasolinePrefabTimer = GasolinePrefabTimer - Time.deltaTime;
            if (GasolinePrefabTimer < 0)
            {

                GameObject GasolinePrefabObject = Instantiate(GasolinePrefab);
                GasolinePrefabObject.transform.SetParent(transform);
                GasolinePrefabObject.transform.position = new Vector3(Player.transform.position.x + 20, Random.Range(Player.transform.position.x + 30, Player.transform.position.y + 2), Player.transform.position.z);
                //GasolinePrefabObject.transform.position = new Vector3(Random.Range(VerticalScreenLimit, -VerticalScreenLimit), Player.transform.position.y - 5, Player.transform.position.z);
                GasolinePrefabTimer = Random.Range(1, 3);
                Destroy(GasolinePrefabObject.gameObject, 12);
            }
        }

    }
}
