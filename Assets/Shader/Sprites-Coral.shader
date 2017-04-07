Shader "Sprites/Coral"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0

		_DetailsTex ("Details Texture", 2D) = "white" {}
		_ColorLight ("Light Color", Color) = (1,1,1,1)
		_ColorShadow ("Shadow Color", Color) = (0,0,0,0)
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite On // Fog
//		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
			#pragma multi_compile _ PIXELSNAP_ON
			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA

			#pragma shader_feature _EMISSION
			#pragma multi_compile_fog // Fog
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
				UNITY_FOG_COORDS(1) // Fog
				UNITY_VERTEX_OUTPUT_STEREO
			};
			
			fixed4 _Color;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif
				UNITY_TRANSFER_FOG(OUT,OUT.vertex); // Fog

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;

			sampler2D _DetailsTex;
			fixed4 _ColorLight;
			fixed4 _ColorShadow;

			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);

				fixed4 white = (1,1,1,1);

				fixed4 colorDetails = tex2D (_DetailsTex, uv);

				color.rgb = colorDetails.rgb * _ColorLight + (1 - colorDetails.rgb) * _ColorShadow;

#if ETC1_EXTERNAL_ALPHA
				// get the color from an external texture (usecase: Alpha support for ETC1 on android)
				color.a = tex2D (_AlphaTex, uv).r;
#endif //ETC1_EXTERNAL_ALPHA

				return color;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
				UNITY_APPLY_FOG(IN.fogCoord, c); // Fog
				c.rgb *= c.a;
//				UNITY_APPLY_FOG(IN.fogCoord, c);
				return c;
			}
		ENDCG
		}
	}
}
