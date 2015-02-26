using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CreateBottom: SideCreator{



    public override void create(int blockWidth, int blockHeight, int blockProf, Vector3 start, int i)
    {
        //if (count == 0)
        //{
            Debug.Log("lol");
            //bottomOb = new GameObject();
           // gameObject.name = "Wow";
            //bottomOb.transform.parent = parent.transform;


            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z + blockProf / 2));
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z + blockProf / 2));
            addTriangles();
            addUVs();
            addReverseTriangles();
        //}
      //  Update();
        
    }
}
