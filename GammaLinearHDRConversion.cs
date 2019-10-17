#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
 
public static class GammaLinearHDRConversion
{
    [MenuItem("Assets/HDR Colors to linear", false, -753)]
    private static void ConvertToLinear()
    {
        Object[] mmm = Selection.objects;
        if (mmm == null)
        {
             Debug.Log(mmm);
            return;
        }
 
        foreach(MaterialProperty m in MaterialEditor.GetMaterialProperties(mmm))
        {
            if(m.flags==MaterialProperty.PropFlags.HDR)
            {
                m.colorValue=m.colorValue.linear;
            }          
        }
    }

    [MenuItem("Assets/HDR Colors to gamma", false, -752)]
    private static void ConvertToGamma()
    {
        Object[] mmm = Selection.objects;
        if (mmm == null)
        {
             Debug.Log(mmm);
            return;
        }
 
        foreach(MaterialProperty m in MaterialEditor.GetMaterialProperties(mmm))
        {
            if(m.flags==MaterialProperty.PropFlags.HDR)
            {
                m.colorValue=m.colorValue.gamma;
            }          
        }
    }

    [MenuItem("Assets/HDR Colors to gamma", true, -752)]
    [MenuItem("Assets/HDR Colors to linear", true, -753)]
    private static bool CheckMaterial(){
        bool allMaterials=true;
        foreach(Object obj in Selection.objects)
        {
            if(obj.GetType() != typeof(Material))
            {
                allMaterials=false;
                break;
            }
        }
        return allMaterials;
    }
}
#endif