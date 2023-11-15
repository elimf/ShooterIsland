using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
public class sampleTest : MonoBehaviour

{
    private int[] tabPointLife = new int[] {100, 90, 70, 50, 30,10,0 };
    private float[] tabIndiceSpeed = new float[] { 0, 0.01f, 0.03f, 0.07f, 0.09f, 0.15f, 0 };
    private int indexLife;
    private Vector2 move;
    Rigidbody2D rb;
    private Vector2 linear;
    public StateStarShip stateStarShip;
    private SpriteRenderer UIStarShip;
    private bool isNotTrigger;
    float speed = 6f;
    float indiceSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        indexLife = 0;
        initialeStateStarShip(tabPointLife[indexLife]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        linear += new Vector2(0.025f, 0);
        rb.MovePosition(rb.position  + ((move * speed) + linear) * (Time.fixedDeltaTime));
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        UIStarShip = GetComponent<SpriteRenderer>();

    }

    private void OnMovement(InputValue value)
    {
        move = value.Get<Vector2>();
        
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
