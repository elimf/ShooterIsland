using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointLifeUI : MonoBehaviour
{
    public GameObject starShipe;

    public Slider slider;

    public sampleTest starShipRef;


    // Start is called before the first frame update
    void Start()
    {
         starShipRef = starShipe.GetComponent<sampleTest>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = starShipRef.stateStarShip.getPointLife();
    }
}
