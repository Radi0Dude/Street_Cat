using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public int health;

    [SerializeField]private Slider healthSlider;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            health = health - 1;
            Debug.Log("Health is at  " + health);
            
        }
        healthSlider.value = health;

    }
}
