using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupSystem : MonoBehaviour
{
    private float point = 0;

    public TextMeshProUGUI textPoints;



    private void Start()
    {
        //Instantiate()

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Point")
        {
            point++;
            textPoints.text = point.ToString();

            float randomNummer = Random.Range(-0.4f, 0.4f);
            float randomNummer2 = Random.Range(0.4f, -0.4f);
            other.transform.localPosition = new Vector3(randomNummer, other.transform.localPosition.y, randomNummer2);
            
            //Destroy(other.gameObject);

        }
        
    }
}
