using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UILinker_TextAlpha : MonoBehaviour 
{
	public float alpha_multi = 1;
	public float alpha_full = 1;

	private Text text;

	void Update()
	{
		if (text == null)
		{
			text = GetComponent<Text>();
		}

		Color color = text.color;
		color.a = alpha_multi * alpha_full;
		text.color = color;
	}
}
