Shader "Custom/Glow" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		 _NormalMap ("Normal Map", 2D) = "bump" {}
		_RimColor("Rim Color",Color)=(1,1,1,1)
		_RimPower("Rim Power", Range(1.0,6.0))=3.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		//sampler2D _MainTex;

		struct Input {
			
			float4 color :Color;
			float2 uv_MainTex;
			float uv_BumpMap;
			float viewDir;
		};
		
		float4 _ColorTint;
		sampler2D _MainTex;
		//sampler2D _BumpMap;
		float4 _RimColor;
		float _RimPower;
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			
			//In.color=_ColorTint;
			
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			//o.Normal=UnpackNormal(text2D(_BumpMap, IN.uv_BumpMap));
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			
			half rim=1.0-saturate(dot(normalize(IN.viewDir),o.Normal));
			o.Emission=_RimColor.rgb*pow(rim, _RimPower);
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
