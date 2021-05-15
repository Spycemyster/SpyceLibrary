#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

sampler s0;
float opacity;
texture lightMask;
sampler lightSampler = sampler_state {
	Texture = <lightMask>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input, float2 coords : TEXCOORD0) : COLOR
{
	float4 color = tex2D(s0, coords) * input.Color;
	float4 lightColor = tex2D(lightSampler, coords);
	float4 retColor = color * lightColor;
	return retColor;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};