// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

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


#include "UnityCG.cginc"

float4 _Color; 
sampler2D _MainTex;
fixed _Cutoff;
float _WaveSpeed;
float _WaveStrength;
float _WaveSinStrength;

struct v2f { 
	V2F_SHADOW_CASTER; 
	float2 uv : TEXCOORD1;
};


void computeWave (inout appdata_full v, inout v2f o)
{
	float sinOff=(v.vertex.x+v.vertex.y+v.vertex.z) * _WaveStrength; 
	float t=-_Time*_WaveSpeed; 
	float fx=v.texcoord.x; 
	float fy=v.texcoord.x*v.texcoord.y; 

	v.vertex.x+=sin(t*1.45+sinOff)*(0.5 * _WaveSinStrength); 
	v.vertex.y=(sin(t*3.12+sinOff)*(0.5 * _WaveSinStrength)); 
	v.vertex.z-=(sin(t*2.2+sinOff)*(0.2 * _WaveSinStrength)); 
//	v.vertex.x+=sin(t*1.45+sinOff)*fx*0.5; 
//	v.vertex.y=(sin(t*3.12+sinOff)*fx*0.5); 
//	v.vertex.z-=(sin(t*2.2+sinOff)*fx*0.2); 
	o.pos = UnityObjectToClipPos( v.vertex ); 
	o.uv = v.texcoord;
}