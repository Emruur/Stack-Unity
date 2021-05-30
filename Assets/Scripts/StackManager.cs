using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class StackManager: MonoBehaviour
{
    public static int consecutiveStacks= 0;

    public static int maxConsecutiveStacks= 15;

    public GameManager gameManager;
    void Start(){
        gameManager.Miss += Clear;
        gameManager.Stack += Stack;
    }

    public static void Stack(){
        print("Stacked");
        consecutiveStacks++;
    }

    public static void Clear(){
        print("Cleared");
        
        consecutiveStacks= 0;
    }

    public static float getDifficultyPercentage(){
        if(consecutiveStacks>= maxConsecutiveStacks){
            return 1;
        }
        return (float) consecutiveStacks/ maxConsecutiveStacks;
    }






}
