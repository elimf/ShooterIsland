using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float HorizontalScreenLimit;
    public float EnemySnawnTime;
    public GameObject EnnemyPrefab;
    public GameObject Player;

    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        Vector3 positionClic = Input.mousePosition;

        Vector3 positionDansScene = Camera.main.ScreenToWorldPoint(positionClic);
        Debug.Log(positionDansScene);

        EnemySnawnTime = EnemySnawnTime - Time.deltaTime;
        if (EnemySnawnTime < 0 && Player != null)
        {
            GameObject EnnemyObject = Instantiate(EnnemyPrefab);
            EnnemyObject.transform.SetParent(transform);
            EnnemyObject.transform.position = new Vector3(Player.transform.position.x + 30, Random.Range(0, 10), 0);
            EnemySnawnTime = Random.Range(1, 4);
            Destroy(EnnemyObject.gameObject, 10);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerUp")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }

}
