using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SizeManager : MonoBehaviour {

    public int blockWidth; public int blockHeight; public int blockProf;
    private int defWidth=30, defHeight=30, defProf=30, defFloor=30;
    List<Transform> sides;
	// Use this for initialization
	
    void Awake () {
        blockWidth = 8;
        blockHeight = 8;
        blockProf = 8;
        

	}

    static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }


	// Update is called once per frame
	void Update () {
            
	
	}
}
