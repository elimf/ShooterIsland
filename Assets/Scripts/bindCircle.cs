using UnityEngine;

public class BindCircle : MonoBehaviour
{
    public GameObject circle; 
    public float activationDelay = 2f;
    public float deactivationDelay = 4f; 

    private void Start()
    {

        InvokeRepeating("ActivateObject", activationDelay, deactivationDelay + activationDelay);
    }

    private void ActivateObject()
    {
        

         
            circle.SetActive(true);

            
            Invoke("DeactivateObject", deactivationDelay);
        
    }

    private void DeactivateObject()
    {


       circle.SetActive(false);
        
    }
}