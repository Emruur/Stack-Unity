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

    void OnEnable(){
        
        
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
        transform.Translate(velocity* Time.deltaTime);
        checkEdges();
    }

    public void Stop(){
        velocity= Vector3.zero;
    }

    void checkEdges(){
        if(transform.position.x> -Spawner.spawnPosition2.x || transform.position.x< Spawner.spawnPosition2.x ){
            velocity.x *= -1;
        }

        else if(transform.position.z>  -Spawner.spawnPosition1.z || transform.position.z< Spawner.spawnPosition1.z ){
            velocity.z *= -1;
        }
    }
}
