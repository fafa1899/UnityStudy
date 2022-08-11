using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class Note11Main : MonoBehaviour
{
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {       
        Graphics.Blit(source, destination, material);
    }
}
