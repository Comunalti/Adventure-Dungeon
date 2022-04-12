Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _size("my time",float) = 0
        _Color ("Tint", Color) = (1,1,1,1)

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
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _size;
            float4 _MainTex_ST;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            
            float sdBox( float2 p,float2 b , float r)
            {
                float2 d = max(abs(p)-b,0.0);
                return length(d) - r;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = step(length((i.uv *2 )-1)*(1/_size),0.5);
                float2 uv = ((i.uv *2 )-1);
                col = sdBox(uv,_size,0.1);
                col = step(col,-0.1);
                    //sin((i.uv.y+i.uv.x)*UNITY_PI*10 + _Time.y*20); //tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col*_Color;
            }
            ENDCG
        }
    }
}
