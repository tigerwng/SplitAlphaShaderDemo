using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName="GeneralImageEvent", menuName="ScriptableObject/GeneralImageEvent", order=2)]
[System.Serializable]
public class GeneralImageEvent : BaseImageEvent
{
    public string[] m_texDataArray;

    public string GetNewTexture()
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