using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SideCreator : MonoBehaviour
{
    public List<Vector3> newVertices = new List<Vector3>();

    // The triangles tell Unity how to build each section of the mesh joining
    // the vertices
    public List<int> newTriangles = new List<int>();

    // The UV list is unimportant right now but it tells Unity how the texture is
    // aligned on each polygon
    public List<Vector2> newUV = new List<Vector2>();
    int faceCount = 0;
    // Use this for initialization
    public Mesh mesh;
    public MeshFilter mF;
   
    //GameObject bottomOb;
    int count = 0;

    public int blockWidth = 3; public int blockHeight = 3; public int blockProf = 3;
    public bool hasChanged = false;
    SizeManager sizeManager;
    protected void addTriangles()
    {
        newTriangles.Add((faceCount * 4));
        newTriangles.Add((faceCount * 4) + 1);
        newTriangles.Add((faceCount * 4) + 2);
        newTriangles.Add((faceCount * 4) + 0);
        newTriangles.Add((faceCount * 4) + 2);
        newTriangles.Add((faceCount * 4) + 3);


        // para os uvs de cada face...: vejo quem é o topo/fim etc
        //OU
        //tento aplicar a ideia do atlas
        //newUV.Add(new Vector2(0, 1));
        //newUV.Add(new Vector2(1, 1));
        //newUV.Add(new Vector2(1, 0));
        //newUV.Add(new Vector2(0, 0));
    }
    //deletar tudo antes de adicionar de novo mas primeiro testo isso...


    protected void addReverseTriangles()
    {
        newTriangles.Add((faceCount * 4));
        newTriangles.Add((faceCount * 4) + 2);
        newTriangles.Add((faceCount * 4) + 1);
        newTriangles.Add((faceCount * 4) + 0);
        newTriangles.Add((faceCount * 4) + 3);
        newTriangles.Add((faceCount * 4) + 2);

        //newUV.Add(new Vector2(0, 1));
        //newUV.Add(new Vector2(1, 1));
        //newUV.Add(new Vector2(1, 0));
        //newUV.Add(new Vector2(0, 0));
    }
   protected void addUVs()
    {
        newUV.Add(new Vector2(0, 1));
        newUV.Add(new Vector2(1, 1));
        newUV.Add(new Vector2(1, 0));
        newUV.Add(new Vector2(0, 0));
    }


    public void Start()
    {
        sizeManager = transform.parent.GetComponent<SizeManager>();
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;
        Init();
    }

    public void Init()
    {


        blockProf = sizeManager.blockProf;
        blockWidth = sizeManager.blockWidth;
        blockHeight = sizeManager.blockHeight;

        create(blockWidth, blockHeight, blockProf, Vector3.zero, 0, gameObject);
        Debug.Log("aaaaaaaaaaaaaaaaaaaa " + blockWidth);
        mesh.Clear();

        mesh.vertices = newVertices.ToArray();
        Debug.Log("vertices.. :" + newVertices.Count + " uvs...: " + newUV.Count);
        mesh.triangles = newTriangles.ToArray();
        //  Debug.Log("vertices.. :" + newVertices.Count + " uvs...: " + newUV.Count );
        Debug.Log("triangulo" + newTriangles.Count + " uvs...: " + newUV.Count);
        mesh.uv = newUV.ToArray();

        mesh.Optimize();
        mesh.RecalculateNormals();



        faceCount = 0;
        newVertices.Clear();
        newTriangles.Clear();
        newUV.Clear();
        faceCount = 0;
        Debug.Log("lol");
       // hasChanged = false;
    }

    public void Update()
    {
        hasChanged = sizeManager.hasChanged;
        if (hasChanged == true)
        {
            Init();
          //StartCoroutine("timerForChange");
            //sizeManager.hasChanged = false;
            //hasChanged = false;
        }
    }
    IEnumerator timerForChange() 
    {
     
        Debug.Log("Na corotina...");
        yield return new WaitForSeconds(.5f);
    }

    public abstract void create(int blockWidth, int blockHeight, int blockProf, Vector3 start, int i, GameObject parent);

}
