using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshManager : MonoBehaviour {
    // This first list contains every vertex of the mesh that we are going to render
    //public List<Vector3> newVertices = new List<Vector3>();

    //// The triangles tell Unity how to build each section of the mesh joining
    //// the vertices
    //public List<int> newTriangles = new List<int>();

    //// The UV list is unimportant right now but it tells Unity how the texture is
    //// aligned on each polygon
    //public List<Vector2> newUV = new List<Vector2>();

    //parametros do usuario
    public int blockWidth = 5;
    public int blockProf = 5;
    public int blockHeight = 2;
    public int numberOfFloors = 1;
    public Vector3 start = new Vector3(0, 0, 0);
    // A mesh is made up of the vertices, triangles and UVs we are going to define,
    // after we make them up we'll save them as this mesh
    private Mesh mesh;
    // Use this for initialization
    int c = 0;

    private float tUnit = 0.25f;
    //em que face estou??
    private int faceCount = 0;
    private Vector2 tStone = new Vector2(0, 0);
    private Vector2 tGrass = new Vector2(0, 1);
    CreateFront front;
    CreateRight right; 
    CreateLeft left; 
    CreateBottom bottom; 
    CreateTop top;
    CreateBack back;
    void Start()
    {
         front = gameObject.AddComponent<CreateFront>();
         right = gameObject.AddComponent<CreateRight>();
         left = gameObject.AddComponent<CreateLeft>();
         bottom = gameObject.AddComponent<CreateBottom>();
         top = gameObject.AddComponent<CreateTop>();
         back = gameObject.AddComponent<CreateBack>();
        //gameObject.AddComponent<MeshFilter>();
       // mesh = GetComponent<MeshFilter>().mesh;

        //float x = transform.position.x;
        //float y = transform.position.y;
        //float z = transform.position.z;


        //newVertices.Add(new Vector3(x, y, z));
        //newVertices.Add(new Vector3(x + 1, y, z));
        //newVertices.Add(new Vector3(x + 1, y - 1, z));
        //newVertices.Add(new Vector3(x, y - 1, z));

        //newTriangles.Add(0);
        //newTriangles.Add(1);
        //newTriangles.Add(3);
        //newTriangles.Add(1);
        //newTriangles.Add(2);
        //newTriangles.Add(3);

        //newUV.Add(new Vector2(tUnit * tStone.x, tUnit * tStone.y + tUnit));
        //newUV.Add(new Vector2(tUnit * tStone.x + tUnit, tUnit * tStone.y + tUnit));
        //newUV.Add(new Vector2(tUnit * tStone.x + tUnit, tUnit * tStone.y));
        //newUV.Add(new Vector2(tUnit * tStone.x, tUnit * tStone.y));



    }
	// Update is called once per frame
	void Update () {

        GenFirstBlock();

        GenFaces();
	}

    private void GenFaces()
    {
       // throw new System.NotImplementedException();
    }

    private void GenFirstBlock()
    {
        //(List<Vector3> newVertices,  int blockWidth, int blockHeight, int blockProf, Vector3 start, int i)
            bottom.create(blockWidth, blockHeight, blockProf, start, 0, gameObject);
        //throw new System.NotImplementedException();
    }
}
