Shader "Texture Only" {
 
Properties {
	_MainTex ("Texture", 2D) = ""
}
 
SubShader {Pass {	// iPhone 3.S and later
	GLSLPROGRAM
	varying mediump vec2 uv;
 
	#ifdef VERTEX
	void main() {
		gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
		uv = gl_MultiTexCoord0.xy;
	}
	#endif
 
	#ifdef FRAGMENT
	uniform lowp sampler2D _MainTex;
	void main() {
		gl_FragColor = texture2D(_MainTex, uv);
	}
	#endif		
	ENDGLSL
}}
 
SubShader {Pass {	// pre-3.S devices, including the September 2009 8.B iPod touch
	SetTexture[_MainTex]
}}
 
}