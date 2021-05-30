using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Block currentBlock;
    public static Block previousBlock;

    
    public float speed= 1;
    Vector3 velocity;

    public static int blockCount;

    void Start()
    {
        blockCount++;

        name= "Block"+blockCount;


        if(blockCount %2==0){
            velocity= Vector3.forward* speed;
        }
        else{
            velocity= Vector3.right * speed;
        }
    }

    public void setAsCurrent(){
        currentBlock= this;
    }

    public void setAsPrevious(){
        previousBlock= this;
    }

    // Update is called once per frame
    void Update()
    {
        checkEdges();
        transform.Translate(velocity* Time.deltaTime);
        
    }

    public void Stop(){
        velocity= Vector3.zero;
    }

    void FixedUpdate(){
        
    }

    void checkEdges(){

        Block previous= previousBlock;

        float distanceX, distanceZ;

        distanceX= Mathf.Abs(transform.position.x- previous.transform.position.x);
        distanceZ= Mathf.Abs(transform.position.z- previous.transform.position.z);

        if(distanceX> Spawner.spawnDistance){
            velocity.x *= -1;
        }
        
        else if(distanceZ> Spawner.spawnDistance){
            velocity.z *= -1;
        }



        
    }
}
