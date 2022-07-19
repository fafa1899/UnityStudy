using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;

[ExecuteInEditMode]
public class Note9Main : MonoBehaviour
{
    public int type = 1;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();

        Shader shader = Shader.Find("Standard");
        meshRenderer.material = new Material(shader);
        Texture2D texture = CreateTexture();
        meshRenderer.sharedMaterial.mainTexture = texture;
    }

    Texture2D CreateTexture()
    {
        Texture2D texture = null;

        switch (type)
        {
            case 0:
            default:
                {
                    texture = Resources.Load<Texture2D>("ImageDemo");
                    break;
                }
            case 1:
                {
                    int width = 512;
                    int height = 512;
                    texture = new Texture2D(width, height, TextureFormat.RGB24, false);

                    byte[] imgData = new byte[width * height * 3];
       
                    for(int yi = 0; yi< 128; yi++)
                    {
                        for(int xi = 0; xi < 128; xi++)
                        {
                            int m = width * 3 * yi + 3 * xi;
                            imgData[m] = 135;
                            imgData[m+1] = 206;
                            imgData[m+2] = 235;
                        }
                    }

                    texture.SetPixelData(imgData, 0, 0);
                    texture.Apply(false, false);

                    break;
                }
        }

        return texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
