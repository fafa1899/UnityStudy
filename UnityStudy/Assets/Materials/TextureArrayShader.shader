Shader "Custom/TextureArrayShader"
{
    Properties
    {
		_MainTex ("Texture", 2DArray) = "" {}
		_Weight ("Weight", float) = 0.0 
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
  
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;       
                float4 vertex : SV_POSITION;
            };

            UNITY_DECLARE_TEX2DARRAY(_MainTex);
			float _Weight;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;          
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {           
				fixed4 col0 = UNITY_SAMPLE_TEX2DARRAY(_MainTex, float3(i.uv, 0));
				fixed4 col1 = UNITY_SAMPLE_TEX2DARRAY(_MainTex, float3(i.uv, 1));		
                return lerp(col0, col1, _Weight);
            }
            ENDCG
        }
    }
}
