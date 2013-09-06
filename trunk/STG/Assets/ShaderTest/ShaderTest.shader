Shader "Custom/ShaderTest"
{
	Properties
	{
		_Color( "Main Color", Color ) = ( 1.0, 0.0, 0.0, 1.0 )
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass
		{
			Material
			{
				Diffuse[_Color]
			}
			
			Lighting On
		}
	} 
	FallBack "Diffuse"
}
