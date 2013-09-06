Shader "Custom/Vertex Color And Texture Alpha"
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
			Blend SrcAlpha SrcColor
			Color [_Color]
			SetTexture[_MainTex]
			{
				combine previous * texture
			}
		}
	}
}