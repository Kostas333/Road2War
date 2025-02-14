// Upgrade NOTE: replaced 'glstate.matrix.mvp' with 'UNITY_MATRIX_MVP'
// Upgrade NOTE: replaced 'glstate.matrix.texture[0]' with 'UNITY_MATRIX_TEXTURE0'
// Upgrade NOTE: replaced 'samplerRECT' with 'sampler2D'
// Upgrade NOTE: replaced 'texRECT' with 'tex2D'

Shader "Hidden/Glow Downsample" {

Properties {
	_Color ("Color", color) = (1,1,1,0)
	_MainTex ("", RECT) = "white" {}
	_GlowThreshold("GlowThreshold", Float) = 0
	_DownsampleAmount("DownsampleAmount", Float) = 2
}

CGINCLUDE
#include "UnityCG.cginc"

struct v2f {
	float4 pos : POSITION;
	float4 uv[4] : TEXCOORD0;
};

float4 _MainTex_TexelSize;

v2f vert (appdata_img v)
{
	v2f o;
	o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
	float4 uv;
	uv.xy = MultiplyUV (UNITY_MATRIX_TEXTURE0, v.texcoord);
	uv.zw = 0;
	float offX = _MainTex_TexelSize.x;
	float offY = _MainTex_TexelSize.y;
	
	// Direct3D9 needs some texel offset!
	#ifdef SHADER_API_D3D9
	uv.x += offX * 2.0f;
	uv.y += offY * 2.0f;
	#endif
	o.uv[0] = uv + float4(-offX,-offY,0,1);
	o.uv[1] = uv + float4( offX,-offY,0,1);
	o.uv[2] = uv + float4( offX, offY,0,1);
	o.uv[3] = uv + float4(-offX, offY,0,1);
	return o;
}
ENDCG


Category {
	ZTest Always Cull Off ZWrite Off Fog { Mode Off }
	
	// -----------------------------------------------------------
	// ARB fragment program
	
	Subshader { 
		Pass {
		
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest

sampler2D _MainTex;
float4 _Color;
float _GlowThreshold;
int _DownsampleAmount;

half4 frag( v2f i ) : COLOR
{
	half4 c;
	c  = tex2D( _MainTex, i.uv[0].xy );
	c += tex2D( _MainTex, i.uv[1].xy );
	c += tex2D( _MainTex, i.uv[2].xy );
	c += tex2D( _MainTex, i.uv[3].xy );
	c /= _DownsampleAmount;
	c.rgb *= _Color.rgb;
	c.rgb *= (c.a + _Color.a);
	c.a = 0;
	
	return saturate((c - _GlowThreshold) / (1 - _GlowThreshold));
}
ENDCG

		}
	}
			
	// -----------------------------------------------------------
	// Radeon 9000
	
	Subshader {
		Pass {


CGPROGRAM
#pragma vertex vert
// use the same vertex program as in FP path
ENDCG

			
			// average 2x2 samples
			SetTexture [_MainTex] {constantColor (0,0,0,0.25) combine texture * constant alpha}
			SetTexture [_MainTex] {constantColor (0,0,0,0.25) combine texture * constant + previous}
			SetTexture [_MainTex] {constantColor (0,0,0,0.25) combine texture * constant + previous}
			SetTexture [_MainTex] {constantColor (0,0,0,0.25) combine texture * constant + previous}
			// apply glow tint and add additional glow
			SetTexture [_MainTex] {constantColor[_Color] combine previous * constant, previous + constant}
			SetTexture [_MainTex] {constantColor (0,0,0,0) combine previous * previous alpha, constant}
		}
	}
}

Fallback off

}
