Shader "TimeForAHero/EnemyShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		//Dissolve properties
		[Header(Dissolve Settings)]
		_DissolveTexture("Dissolve Texutre", 2D) = "white" {}
		_Amount("Amount", Range(0,1)) = 0
		_EdgeColor("Edge Colour", Color) = (1, 1, 1, 1)
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		Cull Off //Fast way to turn your material double-sided

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _EdgeColor;

		//Dissolve properties
		sampler2D _DissolveTexture;
		half _Amount;

		/*
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)
		*/
		void surf(Input IN, inout SurfaceOutputStandard o) {
			//Dissolve function
			half dissolve_value = tex2D(_DissolveTexture, IN.uv_MainTex).r;
			clip(dissolve_value - _Amount);									//Remove colour below amount
			o.Emission = _EdgeColor * step(dissolve_value - _Amount, 0.05f); //emits white color with 0.05 border size

			//Basic shader function
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
	ENDCG
	}
	FallBack "Diffuse"
}
