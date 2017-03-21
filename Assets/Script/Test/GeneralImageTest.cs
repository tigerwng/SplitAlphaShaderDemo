using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralImageTest : MonoBehaviour {

	public GeneralImageEvent m_customImageEvent;
	public Image m_image;

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
		if(m_customImageEvent && m_image)
		{
			string s = m_customImageEvent.GetNewTexture();
			
			if(s != null)
			{
				m_image.sprite = Resources.Load<Sprite>(s);
                m_image.SetNativeSize();
			}
		}
	}

}
