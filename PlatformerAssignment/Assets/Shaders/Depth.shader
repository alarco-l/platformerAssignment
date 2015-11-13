Shader "Terrain Depth Mask Simple" {
  SubShader {
    Tags {"Queue" = "Geometry-200" } // earlier = hides stuff later in queue
    Lighting Off
    ZTest LEqual
    ZWrite On
    ColorMask 0
    Pass {}
  }
}
