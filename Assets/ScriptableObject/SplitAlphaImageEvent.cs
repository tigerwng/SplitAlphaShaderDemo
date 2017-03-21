using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct SplitTexturePathData
{
    public string _rgbFilePath;
    public string _alphaFilePath;
}


[CreateAssetMenu(fileName="SplitAlphaImageEvent", menuName="ScriptableObject/SplitAlphaImageEvent", order=1)]
[System.Serializable]
public class SplitAlphaImageEvent : BaseImageEvent {

    public SplitTexturePathData[] m_texDataArray;

    public SplitTexturePathData? GetNewTexture()
    {
        if(m_texDataArray.Length <= 0)
        {
            return null;
        }

        m_texIndex++;

        if(m_texIndex >= m_texDataArray.Length)
        {
            m_texIndex = 0;
        }

        return m_texDataArray[m_texIndex];
    }
}


