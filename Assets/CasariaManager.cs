using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CasariaManager : MonoBehaviour
{

    public int blockWidth; public int blockHeight; public int blockProf; public int numberOfFloors;
    public Vector3 start;

    private int defWidth = 5, defHeight = 5, defProf = 5, defFloor = 1;
    private Vector3 defStart = Vector3.zero;

    public bool hasChanged = false;
    private int countPasses = 0;
    public List<GameObject> listaDeCasarias = new List<GameObject>();
    private bool createNewCasaria;
    private int count;
    public GameObject Casaria;
    // Use this for initialization

    void Awake()
    {
        defWidth = blockWidth;
        defHeight = blockHeight;
        defProf = blockProf;
        defFloor = numberOfFloors;
        defStart = start;
       // GameObject first = GetComponentInChildren<GameObject>();
        listaDeCasarias.Add(GameObject.FindGameObjectWithTag("Casaria"));
        //listaDeCasarias.Add

    }


    // Update is called once per frame
    void Update()
    {
        foreach (GameObject casarias in listaDeCasarias)
        {
            if (listaDeCasarias.Count > 1)
                Debug.Log("oi oi oi oi oi oi");
            
            SizeManager sizeManager = casarias.GetComponent<SizeManager>();
            if ((blockWidth != defWidth) || (blockHeight != defHeight) || (blockProf != defProf))
            {
                count++;
                sizeManager.hasChanged = true;
                Debug.Log("É diferente!");
                sizeManager.countPasses++;
                //return;
                //   StartCoroutine("timerForChange");
                // hasChanged = false;
            }

            if (sizeManager.countPasses > 7)
            {
                //tartCoroutine("timerForChange");
               
                sizeManager.blockWidth = defWidth;
                sizeManager.blockHeight = defHeight;
                sizeManager.blockProf = defProf;
                sizeManager.hasChanged = false;
                sizeManager.countPasses = 0;
            }
        }
        if (count == (numberOfFloors * 7))
        {
            defWidth = blockWidth;
            defHeight = blockHeight;
            defProf = blockProf;
            count = 0;
        }
        if (numberOfFloors > defFloor)
        {
            //colocar um construtor em casaria...?
            //como instanciar como criança
            GameObject a = (GameObject)Instantiate(Casaria);
            listaDeCasarias.Add(a);
            a.transform.parent = gameObject.transform;
            a.name = "Andar" + numberOfFloors;

           // a.GetComponent<SizeManager>().enabled = false;
            hasChanged = true;
            defFloor = numberOfFloors;
            start = new Vector3(start.x, start.y + (blockHeight * (numberOfFloors - 1)), start.z);
        }
        if (numberOfFloors < defFloor)
        {
            Destroy(Casaria);
            hasChanged = true;
            defFloor = numberOfFloors;
            start = new Vector3(start.x, start.y + (blockHeight * (numberOfFloors - 1)), start.z);


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
