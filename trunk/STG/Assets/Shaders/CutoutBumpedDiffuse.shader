// Upgrade NOTE: replaced 'glstate.matrix.mvp' with 'UNITY_MATRIX_MVP'

// Original shader by cboe - Mar, 23, 2009 
// Enhanced to 3 axis movement by Seon - Jan, 21, 2010
// Added _WaveSpeed by Eric5h5 - Jan, 26, 2010 
// CHANGE LOG - Gauthier BOAGLIO (golgauth) / Klakos - May, 07, 2011 :
// 		- Added Transparency support
// 		- Added Spec and Normal mapping support
// 		- Added Shadow casting support (+ Shadow Alpha and Shadow Alpha cutoff support)
//				[Done in the "ShadowCaster" additional Pass]
//		- Added advanced double-sided rendering support
// 		- Added _WaveStrength param
// 
// Requirements: assumes you are using a subdivided plane created with X (width) * Z (height) where Y is flat. 
// Requirements: assumes UV as: left X (U0) is attatched to pole, and Top Z (V1) is at top of pole.  
// 
// See [ http://klakos.com/en/advanced-waving-flag-shader-for-unity-double-sided-alpha-shadow-support-3/ ] for
// visuals and more informations


Shader "Selfmade/for-2sided/Bumped Diffuse Regular" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_Cutoff ("Shadow Alpha cutoff", Range(0.0, 1.0)) = 0.5
	_Cutoff2 ("Alpha cutoff", Range(0,1)) = 0.5
	
    _WaveSpeed ("Wave Speed", Range(0.0, 150.0)) = 50.0
	_WaveStrength ("Wave Strength", Range(0.0, 5.0)) = 1.0
}

SubShader {
	Tags {"IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 300
	
	
	Pass
    { 
			Name "ShadowCaster"
			Tags { "LightMode" = "ShadowCaster" }
			
			Fog {Mode Off}
			ZWrite On ZTest Less Cull Off
			Offset 1, 1

			CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma multi_compile_shadowcaster
			#include "FlagWaveCG.cginc"
			
			
			v2f vert( appdata_full v )
			{
				v2f o;
				computeWave(v, o);
				TRANSFER_SHADOW_CASTER(o)
    
			  return o;
			}
			
			//sampler2D _MainTex;
					
			float4 frag( v2f i ) : COLOR
			{
				fixed4 texcol = tex2D( _MainTex, i.uv );
				clip( texcol.a - _Cutoff );
				SHADOW_CASTER_FRAGMENT(i)
			}
			ENDCG


      //SetTexture [_MainTex] {combine texture} 
    } 

	

//CULL Front

Blend SrcAlpha OneMinusSrcAlpha
	
CGPROGRAM
		#pragma surface surf BlinnPhong vertex:vert fullforwardshadows alphatest:_Cutoff2
		#include "FlagWaveCG.cginc"

		//sampler2D _MainTex;
		sampler2D _BumpMap;
		//float4 _Color;

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};
 
		v2f vert (inout appdata_full v) { 
			v2f o; 
			computeWave(v, o);
			return o; 
		}
			  
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
		}
ENDCG
}

FallBack "Transparent/Cutout/Diffuse"
}