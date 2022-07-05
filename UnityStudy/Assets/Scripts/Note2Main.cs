using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note2Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject main = GameObject.Find("/Root");
        if (main == null)
        {
            return;
        }

        GameObject triangleGameObject = GreateQuad();
        triangleGameObject.transform.parent = main.transform;
    }

    GameObject GreateQuad()
    {
        string name = "quad";

        Mesh mesh = new Mesh();
        mesh.name = name;

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(-5, -5, 0),
            new Vector3(-5, 5, 0),
            new Vector3(5, -5, 0),
            new Vector3(5, 5, 0),
        };
        mesh.vertices = vertices;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1),
        };
        mesh.uv = uv;

        Vector3[] normals = new Vector3[4]
        {
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
        };
        mesh.normals = normals;
        //mesh.RecalculateNormals();

        int[] triangles = new int[6] { 0, 1, 2, 1, 3, 2 };
        mesh.triangles = triangles;
               
        GameObject newGameObject = new GameObject(name);
        MeshFilter mf = newGameObject.AddComponent<MeshFilter>();
        mf.sharedMesh = mesh;

        MeshRenderer meshRenderer = newGameObject.AddComponent<MeshRenderer>();                
        Material material = Resources.Load<Material>("MaterialDemo");   
        meshRenderer.material = material;

        return newGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
