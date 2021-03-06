using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Block currentBlock;
    public static Block previousBlock;

    
    public Vector2 speedMinMax;

    public float speed;
    Vector3 velocity;

    public static int blockCount;
    

    public bool stopped;

    void Start()
    {
        speed= speedMinMax.x;
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

    void Update(){
        UpdateVelocity();
    }

    

    public void Stop(){
        speed= 0;
        stopped= true;
    }

    void FixedUpdate(){

        
        checkEdges();
        transform.Translate(velocity* Time.smoothDeltaTime);
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

    void UpdateVelocity(){

        if(!stopped){
            speed= Mathf.Lerp(speedMinMax.x, speedMinMax.y, StackManager.getDifficultyPercentage());
        }
        
        velocity= velocity.normalized*speed;
        
    }
}
