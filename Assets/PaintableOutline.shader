Shader "PaintableOutline" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _OutlineColor("Outline Color", Color) = (1, 1, 1, 1)
        _Outline("Outline Width", Range(0.0, 0.1)) = 0.01
    }

        SubShader{
            Tags {"RenderType" = "Opaque"}
            LOD 100

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _OutlineColor;
                float _Outline;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                float4 frag(v2f i) : SV_Target {
                    float4 col = tex2D(_MainTex, i.uv);
                    float4 outline = step(_Outline, col.a);
                    return outline * _OutlineColor + (1.0 - outline) * col;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}