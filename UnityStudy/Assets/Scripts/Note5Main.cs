using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class Note5Main : MonoBehaviour
{
    public Material material1;
    public Material material2;
   
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = CreateMesh();

        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (mf == null)
        {
            mf = gameObject.AddComponent<MeshFilter>();
        }
        mf.sharedMesh = mesh;

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
        }

        Material[] materials = new Material[2];       
        materials[0] = material1;
        materials[1] = material2;
        meshRenderer.materials = materials;
    }

    Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();

        const int vertexCount = 8;
  
        Vector3[] vertices = new Vector3[vertexCount]
        {
            new Vector3(-5, 0, 0),
            new Vector3(-5, 5, 0),
            new Vector3(5, 0, 0),
            new Vector3(5, 5, 0),

            new Vector3(-5, -5, 0),
            new Vector3(-5, 0, 0),
            new Vector3(5, -5, 0),
            new Vector3(5, 0, 0),
        };

        Vector3[] normals = new Vector3[vertexCount]
        {
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),

            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
        };

        Vector2[] uv = new Vector2[vertexCount]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1),

            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(1, 1),
        };

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uv;

        int[] triangles = new int[12] { 0, 1, 2, 1, 3, 2, 4, 5, 6, 5, 7, 6 };

        MeshUpdateFlags flags = MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds
         | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds;
        //MeshUpdateFlags flags = MeshUpdateFlags.Default;

        int indexCount = triangles.Length;
        mesh.SetIndexBufferParams(indexCount, IndexFormat.UInt32);
        mesh.SetIndexBufferData(triangles, 0, 0, indexCount, flags);

        mesh.subMeshCount = 2;
        SubMeshDescriptor subMeshDescriptor1 = new SubMeshDescriptor(0, 6);
        mesh.SetSubMesh(0, subMeshDescriptor1, flags);

        SubMeshDescriptor subMeshDescriptor2 = new SubMeshDescriptor(6, 6);
        mesh.SetSubMesh(1, subMeshDescriptor2, flags);

        return mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
