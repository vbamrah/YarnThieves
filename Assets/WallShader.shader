Shader "Custom/TransparentWall" {
	Properties {
		_Color ("Color", Color) = (0.5,0.5,0.5,0.5)
		_WorldSpaceCameraForward ("World Space Camera Forward", Vector) = (0,0,0,0)
	}
 
	SubShader {
		Tags {"Queue"="Transparent" "RenderType"="Opaque"}
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
			float4 _Color;
 
			v2f vert (appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
 
			fixed4 frag (v2f i) : SV_Target {
				//clip(-dot((i.vertex.xyz / i.vertex.w - _WorldSpaceCameraPos.xyz), _WorldSpaceCameraForward.xyz);

				fixed4 col = tex2D(_MainTex, i.uv.xy) * _Color;
				col.a = 0.5;
				return col;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
