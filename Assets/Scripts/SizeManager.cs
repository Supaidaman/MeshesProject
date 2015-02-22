using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SizeManager : MonoBehaviour {

    public int blockWidth; public int blockHeight; public int blockProf;
    private int defWidth=5, defHeight=5, defProf=5, defFloor=1;

   public bool hasChanged = false;
   private int countPasses = 0;
	// Use this for initialization
	
    void Awake () {
        defWidth= blockWidth;
         defHeight= blockHeight;
        defProf= blockProf;
        

	}


	// Update is called once per frame
	void Update () {
        if ((blockWidth != defWidth) || (blockHeight != defHeight) || (blockProf != defProf))
        {
            hasChanged = true;
            Debug.Log("É diferente!");
            countPasses++;
          //return;
         //   StartCoroutine("timerForChange");
           // hasChanged = false;
        }
        if (countPasses > 7)
        {
           //tartCoroutine("timerForChange");
            defWidth = blockWidth;
            defHeight = blockHeight;
            defProf = blockProf;
            hasChanged = false;
            countPasses = 0;
        }
         // hasChanged = false;
         //ebug.Log("wow such not changing");
        
       
	}

    IEnumerator timerForChange()
    {

        Debug.Log("Na corotina...");
      
       
        yield return new WaitForSeconds(0.5f);
    }
}
