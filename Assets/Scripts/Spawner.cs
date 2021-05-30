using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject fallerPrefab;

    public static Vector3 spawnPosition1;
    public static Vector3 spawnPosition2;
    
    float spawnIncrementHeight;
    public static float spawnDistance= 8;


    

    public void InitialRun()
    {
            spawnIncrementHeight= Block.currentBlock.transform.localScale.y;
            calculateSpawnPosition();
    }
    
    public Block spawnBlock(){
        GameObject newBlock;

        calculateSpawnPosition();

        //spawn new block
        if(Block.blockCount%2== 1){
            newBlock= Instantiate(blockPrefab,spawnPosition1,Quaternion.identity);
        }
        else{
            newBlock= Instantiate(blockPrefab,spawnPosition2,Quaternion.identity);
        }
        

        //Set its size to the previously stacked block
        newBlock.transform.localScale= Block.previousBlock.transform.localScale;

        

        //return spawned block
        return newBlock.GetComponent<Block>();
    }

    

    public void spawnFallerZ(float zScale,Vector3 position){

        if(zScale>0){
            GameObject newFaller= Instantiate(fallerPrefab,position, Quaternion.identity);

            //set its scale
            newFaller.transform.localScale= new Vector3(
            Block.currentBlock.transform.localScale.x,Block.currentBlock.transform.localScale.y,zScale);
        }

    }
    public void spawnFallerX(float xScale,Vector3 position){

        if(xScale>0){
            GameObject newFaller= Instantiate(fallerPrefab,position, Quaternion.identity);

            //set its scale
            newFaller.transform.localScale= new Vector3(
            xScale,Block.currentBlock.transform.localScale.y,Block.currentBlock.transform.localScale.z);
        }

    }

    void calculateSpawnPosition(){

        Vector3 currentPosition= Block.currentBlock.transform.position;

            //SHIFT BACKWARDS
        spawnPosition1= currentPosition- Vector3.forward* spawnDistance;
        spawnPosition2= currentPosition- Vector3.right* spawnDistance;

            //SHIFT UPWARDS
        spawnPosition1 += Vector3.up * spawnIncrementHeight;
        spawnPosition2 += Vector3.up * spawnIncrementHeight;

    }
    
}
