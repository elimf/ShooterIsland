using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
public class sampleTest : MonoBehaviour

{
    private int[] tabPointLife = new int[] {100, 90, 70, 50, 30,10,0 };
    private float[] tabIndiceSpeed = new float[] { 0, 1f, 3f, 7f, 9f, 11f, 0 };
    private int indexLife;
    private Vector2 move;
    Rigidbody2D rb;
    private Vector2 linear;
    public StateStarShip stateStarShip;
    private SpriteRenderer UIStarShip;
    private bool isNotTrigger;
    public float speed = 6f;
    public float indiceSpeed = 0;
    private Quaternion initialRotation; // Rotation initiale de l'objet


    // Start is called before the first frame update
    void Start()
    {
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
        linear = new Vector2(3f + indiceSpeed, 0);
        rb.MovePosition(rb.position  + ((move * speed) + linear) * (Time.fixedDeltaTime));
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

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (isNotTrigger) { return; }
        indexLife += 1;
        if(indexLife == tabPointLife.Length - 1)
        {
            //TODO GAMEOVER
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
