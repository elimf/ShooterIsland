using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// 1 - La vitesse de déplacement
    /// </summary>
    public Vector2 speed = new Vector2(50, 50);
 
     // 2 - Stockage du mouvement
     private Vector2 movement;
      public GameObject BulletPrefab;
      public float BulletSpeed;
      bool fired = false;
      public GameObject targetFrom;
      //public sampleTest refTargetFrom;
  // Start is called before the first frame update
  void Start()
  {
      //refTargetFrom = targetFrom.GetComponent<sampleTest>();
  }

   void Update()
  {
    // 3 - Récupérer les informations du clavier/manette
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    // 4 - Calcul du mouvement
    movement = new Vector2(
      speed.x * inputX,
      speed.y * inputY);

    GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal"), 0);

    if (Input.GetAxis("Fire1") == 1)
    {
      Vector3 positionClic = Input.mousePosition;

      Vector3 positionDansScene = Camera.main.ScreenToWorldPoint(positionClic);
      Debug.Log(positionDansScene);

      if (fired == false)
      {
        fired = true;
        GameObject BulletInstance = Instantiate(BulletPrefab);
        BulletInstance.transform.SetParent(transform.parent);
        BulletInstance.transform.position = new Vector3(transform.position.x + 2.10f, transform.position.y, transform.position.z);
        BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3((positionDansScene.x - transform.position.x) + positionDansScene.y - transform.position.y, 0);
        Destroy(BulletInstance.gameObject, 5);
      }
    }
    else
    {
      fired = false;
    }

  }

  void FixedUpdate()
  {
    // 5 - Déplacement
    GetComponent<Rigidbody2D>().velocity = movement;
  }
}
