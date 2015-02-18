using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PolygonGenerator : MonoBehaviour
{

    // This first list contains every vertex of the mesh that we are going to render
    public List<Vector3>[] newVertices = new List<Vector3>[6];

    // The triangles tell Unity how to build each section of the mesh joining
    // the vertices
    public List<int>[] newTriangles = new List<int>[6];
    public GameObject[] objetos = new GameObject[6];
    // The UV list is unimportant right now but it tells Unity how the texture is
    // aligned on each polygon
    public List<Vector2>[] newUV = new List<Vector2>[6];

    //parametros do usuario
    public int blockWidth = 5;
    public int blockProf = 5;
    public int blockHeight = 2;
    public int numberOfFloors = 1;
    public Vector3 start = new Vector3(0, 0, 0);
    // A mesh is made up of the vertices, triangles and UVs we are going to define,
    // after we make them up we'll save them as this mesh
    private Mesh[] meshes;
    private MeshFilter[] mFilters;
    // Use this for initialization
    int c = 0;

    private float tUnit = 0.25f;
    //em que face estou??
    private int faceCount = 0;
    private Vector2 tStone = new Vector2(0, 0);
    private Vector2 tGrass = new Vector2(0, 1);
    void Start()
    {
        //CreateFront front = gameObject.AddComponent<CreateFront>();
        //CreateRight right = gameObject.AddComponent<CreateRight>();
        //CreateLeft left = gameObject.AddComponent<CreateLeft>();
        //CreateBottom bottom = gameObject.AddComponent<CreateBottom>();
        //CreateTop top = gameObject.AddComponent<CreateTop>();
        //CreateBack back = gameObject.AddComponent<CreateBack>();
        meshes = new Mesh[6];
        mFilters = new MeshFilter[6];
        Debug.Log("To no start");
        for (int i = 0; i < 6; i++)
        {
            objetos[i] = new GameObject();
            meshes[i] = new Mesh();
            Debug.Log(i + " ta funfando");
            newVertices[i] = new List<Vector3>();
            newTriangles[i] = new List<int>();
            newUV[i] = new List<Vector2>();
            mFilters[i] = objetos[i].AddComponent<MeshFilter>();// GetComponent<MeshFilter>().mesh;
            objetos[i].AddComponent<MeshRenderer>();
            
            mFilters[i].mesh = meshes[i];
        }
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

    void UpdateMesh(int i)
    {
        //if (newVertices.Count != newUV.Count)
        //{ 
        //    mesh.Clear();
        //    newVertices.Clear();
        //    newUV.Clear();
        //    newTriangles.Clear();
        //    mesh.triangles = null;
        //    return;
        //}

       // for (int i = 0; i < 6; i++)
        //{

            meshes[i].Clear();

            meshes[i].vertices = newVertices[i].ToArray();
            Debug.Log("vertices.. :" + newVertices[i].Count + " uvs...: " + newUV[i].Count);
            meshes[i].triangles = newTriangles[i].ToArray();
            //  Debug.Log("vertices.. :" + newVertices.Count + " uvs...: " + newUV.Count );

            meshes[i].uv = newUV[i].ToArray();

            meshes[i].Optimize();
            meshes[i].RecalculateNormals();



            faceCount = 0;
            newVertices[i].Clear();
            newTriangles[i].Clear();
            newUV[i].Clear();
            faceCount = 0;
            MeshCollider collider =objetos[i].GetComponent<MeshCollider>();
            if ( collider ==null)
            {
                objetos[i].AddComponent<MeshCollider>();
                objetos[i].GetComponent<MeshCollider>().sharedMesh = meshes[i];
            }
        //}
       }


    //void GenSquare(int x, int y, Vector2 texture)
    //{
    //    newVertices.Add(new Vector3(x, y, 0));
    //    newVertices.Add(new Vector3(x + 1, y, 0));
    //    newVertices.Add(new Vector3(x + 1, y - 1, 0));
    //    newVertices.Add(new Vector3(x, y - 1, 0));

    //    newTriangles.Add(faceCount * 4);
    //    newTriangles.Add((faceCount * 4) + 1);
    //    newTriangles.Add((faceCount * 4) + 3);
    //    newTriangles.Add((faceCount * 4) + 1);
    //    newTriangles.Add((faceCount * 4) + 2);
    //    newTriangles.Add((faceCount * 4) + 3);

    //    newUV.Add(new Vector2(0, 0));
    //    newUV.Add(new Vector2(0, 1));
    //    newUV.Add(new Vector2(1, 0));
    //    newUV.Add(new Vector2(1, 1));

    //    faceCount++;

    //}

    // Update is called once per frame
    void Update()
    {
        UpdateMesh(0);
        if (numberOfFloors != 0)
        {
           // GenFirstBlock();

            GenFaces();


        }
        //UpdateMesh();

       
    }

    private void addTriangles(int i)
    {
        newTriangles[i].Add((faceCount * 4));
        newTriangles[i].Add((faceCount * 4) + 1);
        newTriangles[i].Add((faceCount * 4) + 2);
        newTriangles[i].Add((faceCount * 4) + 0);
        newTriangles[i].Add((faceCount * 4) + 2);
        newTriangles[i].Add((faceCount * 4) + 3);


        // para os uvs de cada face...: vejo quem é o topo/fim etc
        //OU
        //tento aplicar a ideia do atlas
        //newUV.Add(new Vector2(0, 1));
        //newUV.Add(new Vector2(1, 1));
        //newUV.Add(new Vector2(1, 0));
        //newUV.Add(new Vector2(0, 0));
    }

    void addUVs(int i)
    {
        newUV[i].Add(new Vector2(0, 1));
        newUV[i].Add(new Vector2(1, 1));
        newUV[i].Add(new Vector2(1, 0));
        newUV[i].Add(new Vector2(0, 0));
    }


    private void addReverseTriangles(int i)
    {
        newTriangles[i].Add((faceCount * 4));
        newTriangles[i].Add((faceCount * 4) + 2);
        newTriangles[i].Add((faceCount * 4) + 1);
        newTriangles[i].Add((faceCount * 4) + 0);
        newTriangles[i].Add((faceCount * 4) + 3);
        newTriangles[i].Add((faceCount * 4) + 2);

        //newUV.Add(new Vector2(0, 1));
        //newUV.Add(new Vector2(1, 1));
        //newUV.Add(new Vector2(1, 0));
        //newUV.Add(new Vector2(0, 0));
    }

    private void GenFaces()
    {
        for (int i = 0; i < 1; i++)
        {
            //bottom
            newVertices[0].Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            newVertices[0].Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z - -blockProf / 2));
            newVertices[0].Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            newVertices[0].Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));

            faceCount++;
            addTriangles(0);
            addUVs(0);
            addReverseTriangles(0);
            UpdateMesh(0);
            //top

            //newVertices[1].Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[1].Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[1].Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));
            //newVertices[1].Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));

            //faceCount++;
            //addReverseTriangles(1);//
            //addUVs(1);
            //addTriangles(1);
            //UpdateMesh(1);
            
            ////left
            //newVertices[2].Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[2].Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[2].Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            //newVertices[2].Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));

            //faceCount++;
            //addTriangles(2);
            //addUVs(2);

            //addReverseTriangles(2);
            //UpdateMesh(2);
            
            ////throw new System.NotImplementedException();


            ////right
            //newVertices[3].Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[3].Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[3].Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            //newVertices[3].Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));

            //faceCount++;

            //addReverseTriangles(3);
            //addUVs(3);
            //addTriangles(3);
            //UpdateMesh(3);
            
            ////front
            //newVertices[4].Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[4].Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[4].Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            //newVertices[4].Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            //faceCount++;
            //addReverseTriangles(4);
            //addUVs(4);
            //addTriangles(4);
            //UpdateMesh(4);
            
            ////back
            //newVertices[5].Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            //newVertices[5].Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            //newVertices[5].Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));
            //newVertices[5].Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));
            //faceCount++;
            //addTriangles(5);
            //addUVs(5);
            //addReverseTriangles(5);
            //UpdateMesh(5);
            
        }
    }


    //private void GenFirstBlock()
    //{
    //    //pra criar de ponto qualquer, definir um start point. Primeiro é start, depois é width + start, prof + start, height + start
    //    //bottom

    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z + blockProf / 2));
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z + blockProf / 2));

    //    //////isso aqui pode ir pra uma função
    //    addTriangles();
    //    addUVs();

    //    addReverseTriangles();
    //    //  //UpdateMesh();
    //    //  //top

    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));

    //    faceCount++;
    //    addReverseTriangles();// -<< virado para cima!
    //    addUVs();

    //    addTriangles();

    //    //  //left
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z + blockProf / 2));
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));

    //    faceCount++;
    //    addTriangles();
    //    addUVs();

    //    addReverseTriangles();
    //    //  //throw new System.NotImplementedException();


    //    //  //right
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z + blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));

    //    faceCount++;
    //    addReverseTriangles();
    //    addUVs();

    //    addTriangles();


    //    //  //front
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
    //    faceCount++;
    //    addReverseTriangles();
    //    addUVs();

    //    addTriangles();


    //    //  //back
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z + blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z + blockProf / 2));
    //    newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));
    //    newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));
    //    faceCount++;
    //    addTriangles();
    //    addUVs();

    //    addReverseTriangles();


    //    ////falta FRONT E BACK que sao identicos
    //}


}
