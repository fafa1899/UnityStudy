using UnityEngine;

public class Note8Main : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int instanceCount = 5000;

    // Start is called before the first frame update
    void Start()
    {
        MaterialPropertyBlock props = new MaterialPropertyBlock();
      
        for (int i = 0; i < instanceCount; i++)
        {
            GameObject go = new GameObject();
            go.name = i.ToString();

            MeshFilter mf = go.AddComponent<MeshFilter>();
            mf.mesh = mesh;

            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            mr.material = material;

            float r = Random.Range(0.0f, 1.0f);
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);
            props.SetColor("_Color", new Color(r, g, b));
            mr.SetPropertyBlock(props);

            go.transform.position = Random.insideUnitSphere * 5;
            go.transform.eulerAngles = new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f));
            float s = Random.value;
            go.transform.localScale = new Vector3(s, s, s);
       
            go.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


