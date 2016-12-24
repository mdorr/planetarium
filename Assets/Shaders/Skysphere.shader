Shader "Custom/Skysphere" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader {
        Pass {
            Cull Front
            SetTexture [_MainTex]
        }
    }
}