Shader "Custom/CutOut Texture And Alpha Tex"
{
	Properties
	{
		_MainTex( "Main Texture", 2D ) = "white" {}
		_Color( "Main Color", Color ) = ( 1, 1, 1, 1 )
		_ColorAlpha( "Alpha Color", Color ) = ( 1, 1, 1, 1 )
	}
	
	SubShader
	{
		LOD 100

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Blend SrcAlpha OneMinusSrcAlpha
			
			Color[_Color]
			
			SetTexture[_MainTex]
			{
				ConstantColor[_ColorAlpha]
				combine previous lerp( texture ) constant
			}
		}
	}
}