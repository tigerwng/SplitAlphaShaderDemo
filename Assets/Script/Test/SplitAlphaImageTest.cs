using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using tiger.Component;

public class SplitAlphaImageTest : MonoBehaviour {

	public SplitAlphaImageEvent m_customImageEvent;
	public SplitAlphaWithUIImage m_splitAlphaImage;

	void Update()
	{
		#if UNITY_EDITOR

		if(Input.GetKeyDown(KeyCode.Space))
		{
			UpdateTexture2D();
		}

		#elif UNITY_IOS

		if(Input.touchCount > 0)
		{
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				UpdateTexture2D();
			}
		}

		#endif
	}

	private void UpdateTexture2D()
	{
		if(m_customImageEvent && m_splitAlphaImage)
		{
			SplitTexturePathData? d = m_customImageEvent.GetNewTexture();
			
			if(d.HasValue)
			{
				m_splitAlphaImage.RGB_SOURCE = Resources.Load<Texture2D>(d.Value._rgbFilePath) as Texture2D;
				m_splitAlphaImage.ALPHA_SOURCE = Resources.Load<Texture2D>(d.Value._alphaFilePath) as Texture2D;

				m_splitAlphaImage.UpdateTexture2D();
			}
		}
	}

}
