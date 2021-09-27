Shader "Custom/GroundShader"
{
    Properties
    {
        
        
        _MainTex1 ("Albedo 1 (RGB)", 2D) = "white" {}
        _MainTex2 ("Albedo 2 (RGB)", 2D) = "white" {}
        _MainTex3 ("Albedo 3 (RGB)", 2D) = "white" {}
        _MainTex4 ("Albedo 4 (RGB)", 2D) = "white" {}
        _MainTex5 ("Albedo 5 (RGB)", 2D) = "white" {}
        _MainTex6 ("Albedo 6 (RGB)", 2D) = "white" {}
        _MainTex7 ("Albedo 7 (RGB)", 2D) = "white" {}
        


        _OpacityMap1 ("Opacity 1 (byte)", 2D) = "white" {}
        _OpacityMap2 ("Opacity 2 (byte)", 2D) = "white" {}
        _OpacityMap3 ("Opacity 3 (byte)", 2D) = "white" {}
        _OpacityMap4 ("Opacity 4 (byte)", 2D) = "white" {}
        _OpacityMap5 ("Opacity 5 (byte)", 2D) = "white" {}
        _OpacityMap6 ("Opacity 6 (byte)", 2D) = "white" {}
        _OpacityMap7 ("Opacity 7 (byte)", 2D) = "white" {}
        

        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex1;
        sampler2D _MainTex2;
        sampler2D _MainTex3;
        sampler2D _MainTex4;
        sampler2D _MainTex5;
        sampler2D _MainTex6;
        sampler2D _MainTex7;
        

        sampler2D _OpacityMap1;
        sampler2D _OpacityMap2;
        sampler2D _OpacityMap3; 
        sampler2D _OpacityMap4;
        sampler2D _OpacityMap5; 
        sampler2D _OpacityMap6;
        sampler2D _OpacityMap7;
       

        struct Input
        {
            float2 uv_MainTex1;
        };


        half _Glossiness;
        half _Metallic;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color

            fixed4 c =
            tex2D (_MainTex1, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap1, IN.uv_MainTex1).x +
            tex2D (_MainTex2, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap2, IN.uv_MainTex1).x +
            tex2D (_MainTex3, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap3, IN.uv_MainTex1).x +
            tex2D (_MainTex4, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap4, IN.uv_MainTex1).x +
            tex2D (_MainTex5, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap5, IN.uv_MainTex1).x +
            tex2D (_MainTex6, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap6, IN.uv_MainTex1).x;
            //tex2D (_MainTex8, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap8, IN.uv_MainTex1).x;

            if (tex2D (_OpacityMap7, IN.uv_MainTex1).x > 0) {
                c = (tex2D (_MainTex1, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap1, IN.uv_MainTex1).x +
                tex2D (_MainTex2, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap2, IN.uv_MainTex1).x +
                tex2D (_MainTex3, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap3, IN.uv_MainTex1).x +
                tex2D (_MainTex4, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap4, IN.uv_MainTex1).x +
                tex2D (_MainTex5, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap5, IN.uv_MainTex1).x +
                tex2D (_MainTex6, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap6, IN.uv_MainTex1).x) * (1 - tex2D (_OpacityMap7, IN.uv_MainTex1).x) +
                tex2D (_MainTex7, IN.uv_MainTex1 * 12) * tex2D (_OpacityMap7, IN.uv_MainTex1).x;
            }


            o.Albedo = c.rgb;

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
