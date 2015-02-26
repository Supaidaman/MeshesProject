using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SizeManager : MonoBehaviour {

    public int blockWidth; public int blockHeight; public int blockProf; public int numberOfFloors;
    public Vector3 start;
    
    private int defWidth=5, defHeight=5, defProf=5, defFloor=1;
    private Vector3 defStart = Vector3.zero;

   public bool hasChanged = false;
   private int countPasses = 0;
   private List<GameObject> listaDeCasarias = new List<GameObject>();
   private bool createNewCasaria;
   public GameObject Casaria;
	// Use this for initialization
	
    void Awake () {
        defWidth= blockWidth;
         defHeight= blockHeight;
        defProf= blockProf;
        defFloor = numberOfFloors;
        defStart = start;
        //listaDeCasarias.Add

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

        if (numberOfFloors!= defFloor)
        {
            //colocar um construtor em casaria...?
            Instantiate(Casaria);
            hasChanged = true;
            defFloor = numberOfFloors;
            start = new Vector3(start.x, start.y + (blockHeight * (numberOfFloors-1)), start.z);
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
