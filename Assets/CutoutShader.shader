Shader "PaperCone/ColoredCutoff" {

    Properties {
       _Color ("Main Color", Color) = (1,1,1,1)
       _MainTex ("Texture Atlas", 2D) = "white" {}
       _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }

    SubShader {

       Tags {"IgnoreProjector"="True" "RenderType"="TransparentCutout"}
       Fog { Mode Off }
       Blend One OneMinusSrcAlpha
       CGPROGRAM

          #pragma surface surf Lambert alphatest:_Cutoff
          sampler2D _MainTex;
          fixed4 _Color;

          struct Input {
             float2 uv_MainTex;
             fixed4 color : COLOR;
          };

          void surf (Input IN, inout SurfaceOutput o) {
             fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.color * _Color;
             o.Albedo = c.rgb * 10;
             o.Alpha = c.a;
          }

       ENDCG

    }
    FallBack "Transparent/Cutout/Bumped Diffuse"
}