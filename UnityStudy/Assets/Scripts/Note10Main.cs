using Unity.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class Note10Main : MonoBehaviour
{
    public Texture2D texture1;
    public Texture2D texture2;

    [Range(0.0f, 1.0f)]
    public float weight;

    Material material;

    // Start is called before the first frame update
    void Start()
    { 
        MeshRenderer mr = GetComponent<MeshRenderer>();
        material = mr.sharedMaterial;

        Texture2DArray texture2DArray = CreateTexture2DArray();

        material.mainTexture = texture2DArray;
        material.SetFloat("_Weight", weight);
    }

    Texture2DArray CreateTexture2DArray()
    {
        Texture2DArray texture2DArray = new Texture2DArray(texture1.width, texture1.height, 2,
            texture1.format, false);

        NativeArray<byte> pixelData1 = texture1.GetPixelData<byte>(0);
        NativeArray<byte> pixelData2 = texture2.GetPixelData<byte>(0);
                
        texture2DArray.SetPixelData(pixelData1, 0, 0, 0);
        texture2DArray.SetPixelData(pixelData2, 0, 1, 0);

        texture2DArray.Apply(false, false);

        return texture2DArray;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_Weight", weight);
    }
}
