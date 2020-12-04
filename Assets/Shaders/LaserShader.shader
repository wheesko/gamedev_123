// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32827,y:32662,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32617,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bd0292998a906744789172be8e1e0917,ntxv:0,isnm:False|UVIN-1234-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32609,y:32765,varname:node_2393,prsc:2|A-5484-OUT,B-2053-RGB,C-797-RGB,D-9248-OUT,E-9988-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33081,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:9988,x:32495,y:33012,varname:node_9988,prsc:2|A-6074-A,B-797-A;n:type:ShaderForge.SFN_Time,id:2391,x:31632,y:32757,varname:node_2391,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4393,x:31632,y:33021,ptovrint:False,ptlb:X Speed,ptin:_XSpeed,varname:node_4393,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;n:type:ShaderForge.SFN_ValueProperty,id:7757,x:31632,y:33150,ptovrint:False,ptlb:Y Speed,ptin:_YSpeed,varname:node_7757,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:2190,x:31835,y:33021,varname:node_2190,prsc:2|A-4393-OUT,B-7757-OUT;n:type:ShaderForge.SFN_Multiply,id:7892,x:31893,y:32807,varname:node_7892,prsc:2|A-2391-T,B-2190-OUT;n:type:ShaderForge.SFN_TexCoord,id:6924,x:31802,y:32608,varname:node_6924,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:1234,x:32075,y:32664,varname:node_1234,prsc:2|A-6924-UVOUT,B-7892-OUT;n:type:ShaderForge.SFN_Tex2d,id:2238,x:32235,y:32255,ptovrint:False,ptlb:Mask Frame,ptin:_MaskFrame,varname:node_2238,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d788763d4b7f6d14b973666f2b12619e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4553,x:32235,y:32435,ptovrint:False,ptlb:Mask Texture,ptin:_MaskTexture,varname:node_4553,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d788763d4b7f6d14b973666f2b12619e,ntxv:0,isnm:False|UVIN-1234-OUT;n:type:ShaderForge.SFN_Multiply,id:5484,x:32515,y:32444,varname:node_5484,prsc:2|A-4553-RGB,B-6074-RGB,C-2238-RGB;proporder:6074-797-4393-7757-4553-2238;pass:END;sub:END;*/

Shader "Shader Forge/LaserShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _XSpeed ("X Speed", Float ) = 0.8
        _YSpeed ("Y Speed", Float ) = 0
        _MaskTexture ("Mask Texture", 2D) = "white" {}
        _MaskFrame ("Mask Frame", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _MaskFrame; uniform float4 _MaskFrame_ST;
            uniform sampler2D _MaskTexture; uniform float4 _MaskTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _TintColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _XSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _YSpeed)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float4 node_2391 = _Time;
                float _XSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _XSpeed );
                float _YSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _YSpeed );
                float2 node_1234 = (i.uv0+(node_2391.g*float2(_XSpeed_var,_YSpeed_var)));
                float4 _MaskTexture_var = tex2D(_MaskTexture,TRANSFORM_TEX(node_1234, _MaskTexture));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1234, _MainTex));
                float4 _MaskFrame_var = tex2D(_MaskFrame,TRANSFORM_TEX(i.uv0, _MaskFrame));
                float4 _TintColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TintColor );
                float3 emissive = ((_MaskTexture_var.rgb*_MainTex_var.rgb*_MaskFrame_var.rgb)*i.vertexColor.rgb*_TintColor_var.rgb*2.0*(_MainTex_var.a*_TintColor_var.a));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.5,0.5,0.5,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
