using UnityEngine;

//ʵ��������
public struct InstanceParam
{  
    public Color color;
    public Matrix4x4 instanceToObjectMatrix;        //ʵ�������﷽����
}

[ExecuteInEditMode]
public class Note6Main : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    int instanceCount = 200;
    Bounds instanceBounds;

    ComputeBuffer bufferWithArgs = null;
    ComputeBuffer instanceParamBufferData = null;

    // Start is called before the first frame update
    void Start()
    {
        instanceBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 100));

        uint[] args = new uint[5] { 0, 0, 0, 0, 0 };
        bufferWithArgs = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
        int subMeshIndex = 0;
        args[0] = mesh.GetIndexCount(subMeshIndex);
        args[1] = (uint)instanceCount;
        args[2] = mesh.GetIndexStart(subMeshIndex);
        args[3] = mesh.GetBaseVertex(subMeshIndex);
        bufferWithArgs.SetData(args);
        
        InstanceParam[] instanceParam = new InstanceParam[instanceCount];

        for (int i = 0; i < instanceCount; i++)
        {   
            Vector3 position = Random.insideUnitSphere * 5;        
            Quaternion q =  Quaternion.Euler(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f));
            float s = Random.value;
            Vector3 scale = new Vector3(s, s, s);

            instanceParam[i].instanceToObjectMatrix = Matrix4x4.TRS(position, q, scale);
            instanceParam[i].color = Random.ColorHSV();
        }

        int stride = System.Runtime.InteropServices.Marshal.SizeOf(typeof(InstanceParam));
        instanceParamBufferData = new ComputeBuffer(instanceCount, stride);
        instanceParamBufferData.SetData(instanceParam);
        material.SetBuffer("dataBuffer", instanceParamBufferData);
        material.SetMatrix("ObjectToWorld", Matrix4x4.identity);
    }

    // Update is called once per frame
    void Update()
    {        
        if(bufferWithArgs != null)
        {         
            Graphics.DrawMeshInstancedIndirect(mesh, 0, material, instanceBounds, bufferWithArgs, 0);
        }        
    }

    private void OnDestroy()
    {
        if (bufferWithArgs != null)
        {
            bufferWithArgs.Release();
        }
        
        if(instanceParamBufferData != null)
        {
            instanceParamBufferData.Release();
        }        
    }
}
