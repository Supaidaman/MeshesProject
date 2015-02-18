using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void create(List<Vector3> newVertices, int blockWidth, int blockHeight, int blockProf, Vector3 start, int i)
    {
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));

    }
}
