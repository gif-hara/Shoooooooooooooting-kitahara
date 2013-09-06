Shader "Custom/Vertex Color And Texture"
{
	Properties
	{
		_MainTex( "Main Texture", 2D ) = "white" {}
		_Color( "Main Color", Color ) = ( 1, 1, 1, 1 )
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
			Color [_Color]
			Blend SrcAlpha OneMinusSrcAlpha
			SetTexture[_MainTex]
			{
				combine previous * texture
			}
		}
	}
}