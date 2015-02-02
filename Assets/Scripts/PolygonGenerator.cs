using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PolygonGenerator : MonoBehaviour
{

    // This first list contains every vertex of the mesh that we are going to render
    public List<Vector3> newVertices = new List<Vector3>();

    // The triangles tell Unity how to build each section of the mesh joining
    // the vertices
    public List<int> newTriangles = new List<int>();

    // The UV list is unimportant right now but it tells Unity how the texture is
    // aligned on each polygon
    public List<Vector2> newUV = new List<Vector2>();

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


    private float tUnit = 0.25f;
    //em que face estou??
    private int faceCount = 0;
    private Vector2 tStone = new Vector2(0, 0);
    private Vector2 tGrass = new Vector2(0, 1);
    void Start()
    {

        mesh = GetComponent<MeshFilter>().mesh;

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

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = newVertices.ToArray();
        mesh.triangles = newTriangles.ToArray();
        mesh.uv = newUV.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();

        faceCount = 0;
        newVertices.Clear();
        newTriangles.Clear();
        newUV.Clear();
        faceCount = 0;
    }


    void GenSquare(int x, int y, Vector2 texture)
    {
        newVertices.Add(new Vector3(x, y, 0));
        newVertices.Add(new Vector3(x + 1, y, 0));
        newVertices.Add(new Vector3(x + 1, y - 1, 0));
        newVertices.Add(new Vector3(x, y - 1, 0));

        newTriangles.Add(faceCount * 4);
        newTriangles.Add((faceCount * 4) + 1);
        newTriangles.Add((faceCount * 4) + 3);
        newTriangles.Add((faceCount * 4) + 1);
        newTriangles.Add((faceCount * 4) + 2);
        newTriangles.Add((faceCount * 4) + 3);

        newUV.Add(new Vector2(0, 0));
        newUV.Add(new Vector2(0, 1));
        newUV.Add(new Vector2(1, 0));
        newUV.Add(new Vector2(1, 1));

        faceCount++;

    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfFloors != 0)
        {
            GenFirstBlock();
            GenFaces();

        }
        UpdateMesh();
    }

    private void addTriangles()
    {
        newTriangles.Add((faceCount * 4));
        newTriangles.Add((faceCount * 4) + 1);
        newTriangles.Add((faceCount * 4) + 2);
        newTriangles.Add((faceCount * 4) + 0);
        newTriangles.Add((faceCount * 4) + 2);
        newTriangles.Add((faceCount * 4) + 3);

        newUV.Add(new Vector2(0, 0));
        newUV.Add(new Vector2(0, 1));
        newUV.Add(new Vector2(1, 0));
        newUV.Add(new Vector2(1, 1));
    }


    private void addReverseTriangles()
    {
        newTriangles.Add((faceCount * 4));
        newTriangles.Add((faceCount * 4) + 2);
        newTriangles.Add((faceCount * 4) + 1);
        newTriangles.Add((faceCount * 4) + 0);
        newTriangles.Add((faceCount * 4) + 3);
        newTriangles.Add((faceCount * 4) + 2);

        newUV.Add(new Vector2(0, 0));
        newUV.Add(new Vector2(0, 1));
        newUV.Add(new Vector2(1, 0));
        newUV.Add(new Vector2(1, 1));
    }

    private void GenFaces()
    {
        for (int i = 1; i < numberOfFloors; i++)
        {

            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z - -blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));

            faceCount++;
            addTriangles();
            //addReverseTriangles();
            //UpdateMesh();
            //top

            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));

            faceCount++;
           // addTriangles();
            addReverseTriangles();//
            //left
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));

            faceCount++;
            addTriangles();
            //addReverseTriangles();
            //throw new System.NotImplementedException();


            //right
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));

            faceCount++;
           // addTriangles();
            addReverseTriangles();

            //front
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z - blockProf / 2));
            faceCount++;
           // addTriangles();
           addReverseTriangles();

            //back
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + (blockHeight * i), start.z + blockProf / 2));
            newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));
            newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight + (blockHeight * i), start.z + blockProf / 2));
            faceCount++;
            addTriangles();
            //addReverseTriangles();

        }
    }


    private void GenFirstBlock()
    {
        //pra criar de ponto qualquer, definir um start point. Primeiro é start, depois é width + start, prof + start, height + start
        //bottom

        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z + blockProf / 2));
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z + blockProf / 2));

        //////isso aqui pode ir pra uma função
        addTriangles();
        // addReverseTriangles();
        //  //UpdateMesh();
        //  //top

        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));

        faceCount++;
        addReverseTriangles();// -<< virado para cima!
        //  addTriangles();

        //  //left
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z + blockProf / 2));
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));

        faceCount++;
        addTriangles();
        //addReverseTriangles();
        //  //throw new System.NotImplementedException();


        //  //right
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z + blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));

        faceCount++;
        addReverseTriangles();
        // addTriangles();


        //  //front
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z - blockProf / 2));
        faceCount++;
        addReverseTriangles();
        //  addTriangles();


        //  //back
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y, start.z + blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y, start.z + blockProf / 2));
        newVertices.Add(new Vector3(start.x + blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));
        newVertices.Add(new Vector3(start.x - blockWidth / 2, start.y + blockHeight, start.z + blockProf / 2));
        faceCount++;
        addTriangles();
        //  addReverseTriangles();


        ////falta FRONT E BACK que sao identicos
    }


}
