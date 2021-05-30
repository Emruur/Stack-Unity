using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Block startingBlock;
    public Block secondBlock;

    public Spawner spawner;




    void Start()
    {
        secondBlock.setAsCurrent();
        startingBlock.setAsPrevious();
        spawner.InitialRun();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){


            Block current= Block.currentBlock;
            Block previous= Block.previousBlock;
            Block spawnedBlock;

            

            current.Stop();

            //slice blocks 
            if(Block.blockCount%2==0){
                SliceBlockOnZ();
            }
            else{
                SliceBlockOnX();
            }
            

            //set current as previous
            current.setAsPrevious();

            //spawn block
            spawnedBlock= spawner.spawnBlock();

            //set spawned block as current
            spawnedBlock.setAsCurrent();

            //move camera
        }
        
    }

    void SliceBlockOnZ(){
        Block current= Block.currentBlock;
        Block previous= Block.previousBlock;
        Vector3 fallerPosition;

        float currentBlockEdgeZ= current.transform.position.z+ current.transform.localScale.z/2;
        float previousBlockEdgeZ= previous.transform.position.z+ previous.transform.localScale.z/2;

        float hangLength= currentBlockEdgeZ-previousBlockEdgeZ;

        //print(hangLength);

        float newCurrentZScale= current.transform.localScale.z- Mathf.Abs(hangLength);

        if(newCurrentZScale<= 0){
            print("GameOver");
            //temporary for test purposes
            newCurrentZScale= 0;
        }

        //resize current block
        current.transform.localScale -= Vector3.forward* Mathf.Abs(hangLength);

        //shift current block
        if(hangLength>0){
            //Block has gone past the previous
            //Shift it back
            current.transform.Translate(current.transform.forward*-1* hangLength/2);

            //falling block is going to be in front of the current block
            fallerPosition= current.transform.position +current.transform.forward*(current.transform.localScale.z/2+ hangLength/2);


        }
        else{
            //Block has come short 
            //shift it forward
            current.transform.Translate(current.transform.forward*-1* hangLength/2);

           // Falling block is going to be behind the current block;
            fallerPosition= current.transform.position +current.transform.forward*(-current.transform.localScale.z/2+ hangLength/2);
        }

        spawner.spawnFallerZ(Mathf.Abs(hangLength), fallerPosition);
    }
    void SliceBlockOnX(){
            Block current= Block.currentBlock;
            Block previous= Block.previousBlock;
            Vector3 fallerPosition;

            float currentBlockEdgeX= current.transform.position.x+ current.transform.localScale.x/2;
            float previousBlockEdgeX= previous.transform.position.x+ previous.transform.localScale.x/2;

            float hangLength= currentBlockEdgeX-previousBlockEdgeX;

            //print(hangLength);

            float newCurrentXScale= current.transform.localScale.x- Mathf.Abs(hangLength);

                if(newCurrentXScale<= 0){
                    print("GameOver");
                    //temporary for test purposes
                    newCurrentXScale= 0;
                }

            //resize current block
            current.transform.localScale -= Vector3.right* Mathf.Abs(hangLength);

                //shift current block
            if(hangLength>0){
                //Block has gone past the previous
                //Shift it back
                current.transform.Translate(current.transform.right*-1* hangLength/2);

                //falling block is going to be in front of the current block
                fallerPosition= current.transform.position +current.transform.right*(current.transform.localScale.x/2+ hangLength/2);


            }
            else{
                //Block has come short 
                //shift it forward
                current.transform.Translate(current.transform.right*-1* hangLength/2);

                // Falling block is going to be behind the current block;
                fallerPosition= current.transform.position +current.transform.right*(-current.transform.localScale.x/2+ hangLength/2);
            }

            spawner.spawnFallerX(Mathf.Abs(hangLength), fallerPosition);
        }

    

    
}
