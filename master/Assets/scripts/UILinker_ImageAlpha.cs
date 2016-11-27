using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILinker_ImageAlpha : MonoBehaviour 
{
	public float alpha_multi = 1;
	public float alpha_full = 1;

	private Image image;

	void Update()
	{
		if (image == null)
		{
			image = GetComponent<Image>();
		}
		
		Color color = image.color;
		color.a = alpha_multi*alpha_full;
		image.color = color;
	}
}
