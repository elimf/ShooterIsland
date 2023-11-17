using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointLifeBoss : MonoBehaviour
{
    public GameObject alienObjet;

    public Slider slider;

    public AlienBoss alien;


    // Start is called before the first frame update
    void Start()
    {
        alien = alienObjet.GetComponent<AlienBoss>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = alien.stateEnemy.getPointLife();
    }
}
