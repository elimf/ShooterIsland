using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class sampleTest : MonoBehaviour

{
    private int[] tabPointLife = new int[] {100, 90, 70, 50, 30,10,0 };
    private float[] tabIndiceSpeed = new float[] { 0, 1f, 3f, 7f, 9f, 11f, 0 };
    private string[] triggerDommageStep =  { "obstacle", "bullets" };
    private int indexLife;
    public bool cine = false;
    private Vector2 move;
    Rigidbody2D rb;
    private Vector2 linear;
    public StateStarShip stateStarShip;
    private SpriteRenderer UIStarShip;
    private bool isNotTrigger;
    public float speed = 6f;
    public float indiceSpeed = 0;
    private Quaternion initialRotation; // Rotation initiale de l'objet
    string nomDeLaScene;


    // Start is called before the first frame update
    void Start()
    {
        if (cine)
        {
            Vector2 pos = new Vector2(0, 90);
            moveTo(pos, 4);
        }
        nomDeLaScene = SceneManager.GetActiveScene().name;
        initialRotation = transform.rotation;
        indexLife = 0;
        initialeStateStarShip(tabPointLife[indexLife]);
    }
    private void Update()
    {
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (nomDeLaScene.Contains("Boss")){
            rb.MovePosition(rb.position + move* speed * (Time.fixedDeltaTime));
        }
        else {
            linear = new Vector2(3f + indiceSpeed, 0);
            rb.MovePosition(rb.position + ((move * speed) + linear) * (Time.fixedDeltaTime));
        }
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        UIStarShip = GetComponent<SpriteRenderer>();

    }
    void ProcessEventsInDynamicUpdate(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.name);

    }

   


    

    public void InputSystemActionZ(InputAction.CallbackContext context)
    {

        move = context.ReadValue<Vector2>();

        Debug.Log(context.control.valueType.Name);
    }

  


    public void takeDommage()
    {
        if (isNotTrigger) { return; }
        indexLife += 1;
        if (indexLife == tabPointLife.Length - 1)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
        indiceSpeed = tabIndiceSpeed[indexLife];
        stateStarShip.setPointLife(tabPointLife[indexLife]);
        isNotTrigger = true;
        StartCoroutine(renderDommageInStarShip());
    }

    public void initialeStateStarShip(int value)

    {
        stateStarShip = new StateStarShip();
        stateStarShip.setPointLife(value);
    }

    IEnumerator renderDommageInStarShip()
    {
        UIStarShip.color = Color.red;
        ;
        StartCoroutine(clignoteStarShip(5));

        yield return new WaitForSeconds(2.5f);

        UIStarShip.color = Color.white;

        isNotTrigger = false;
        


    }

    IEnumerator clignoteStarShip(int numberClignote)

    {
        for (int i = 0; i <= numberClignote; i++)
        {
            UIStarShip.enabled = !UIStarShip.enabled;
            yield return new WaitForSeconds(0.35f);
        }
        UIStarShip.enabled = true;


    }

    public void moveTo(Vector2 position, int speed)
    {
        rb.MovePosition(rb.position + position * speed * (Time.fixedDeltaTime));

    }

}

public class StateStarShip
{
    public int pointLife = 0 ;

    public void setPointLife(int value)
    {
        pointLife = value;
    }

    public int getPointLife()
    {
        return pointLife;
    }

}
