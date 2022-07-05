using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class Note4Main : MonoBehaviour
{
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "quad";

        //顶点数据
        VertexAttributeDescriptor[] vertexAttributeDescriptorList = new[]{
             new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3),
             new VertexAttributeDescriptor(VertexAttribute.Normal, VertexAttributeFormat.Float32, 3),
             new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2)};

        const int vertexCount = 4;
        const int verticesAttributeBufferLength = vertexCount * (3 + 3 + 2);
        float[] verticesAttributeBuffer = new float[verticesAttributeBufferLength] {
            -5, -5, 0, 0, 0, -1,0, 0,
            -5, 5, 0, 0, 0, -1, 0, 1,
            5, -5, 0, 0, 0, -1, 1, 0,
            5, 5, 0, 0, 0, -1, 1, 1
        };

        mesh.SetVertexBufferParams(vertexCount, vertexAttributeDescriptorList);
        mesh.SetVertexBufferData(verticesAttributeBuffer, 0, 0, verticesAttributeBufferLength, 0);

        int[] triangles = new int[6] { 0, 1, 2, 1, 3, 2 };
        int indexCount = triangles.Length;

        //顶点索引文件
        mesh.SetIndexBufferParams(indexCount, IndexFormat.UInt32);
        mesh.SetIndexBufferData(triangles, 0, 0, indexCount);

        //子Mesh描述
        mesh.subMeshCount = 1;
        SubMeshDescriptor subMeshDescriptor = new SubMeshDescriptor(0, indexCount);
        mesh.SetSubMesh(0, subMeshDescriptor);

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
        meshRenderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
