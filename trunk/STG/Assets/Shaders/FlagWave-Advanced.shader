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


Shader "Selfmade/for-2sided/FlagWave Advanced Regular" 
{ 

Properties 
{ 
 	// Ususal stuffs
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 0)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_MainTex ("Base (RGB) TransGloss (A)", 2D) = "white" {}

	// Bump stuffs
	//_Parallax ("Height", Range (0.005, 0.08)) = 0.02
	//_ParallaxMap ("Heightmap (A)", 2D) = "black" {}
	
	// Shadow Stuff
	_Cutoff ("Shadow Alpha cutoff", Range(0.25,0.9)) = 1.0

	// Flag Stuffs
    _WaveSpeed ("Wave Speed", float) = 50.0 
    _WaveStrength ("Wave Strength", float) = 1.0 
    _WaveSinStrength("Wave Sin Strength", float) = 1.0
} 


SubShader 
{ 
	Tags {
	"Queue"="AlphaTest" 
	"IgnoreProjector"="True" 
	"RenderType"="Transparent"}

	LOD 300



	Pass
    { 
			Name "ShadowCaster"
			Tags { "LightMode" = "ShadowCaster" }
			
			Fog {Mode Off}
			ZWrite On ZTest Less Cull Off
			Offset 1, 1
			Lighting Off

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

CGPROGRAM
		#pragma surface surf BlinnPhong alpha vertex:vert fullforwardshadows approxview
		#include "FlagWaveCG.cginc"


		half _Shininess;

		float _Parallax;

		struct Input {
			float2 uv_MainTex;
		};

		v2f vert (inout appdata_full v) { 
			v2f o; 
			computeWave(v, o);
			return o; 
		} 

		void surf (Input IN, inout SurfaceOutput o) {
			// Comment the next 4 following lines to get a standard bumped rendering
			// [Without Parallax usage, which can cause strange result on the back side of the plane]

			fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = tex.rgb * _Color.rgb;
			o.Gloss = tex.a;
			o.Alpha = tex.a * _Color.a;
			//clip(o.Alpha - _Cutoff);
		}
ENDCG
}
	
Fallback "Transparent/VertexLit"
}


