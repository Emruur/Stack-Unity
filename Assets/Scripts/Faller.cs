using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour
{
    public int yTreshold= -10;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y< yTreshold){
            Destroy(gameObject);
        }
    }
}
