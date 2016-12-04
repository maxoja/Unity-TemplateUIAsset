using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInputBox : UIInputField , IUIInputBox
{
	[SerializeField]
	private Text text_label;
	[SerializeField]
	private Image image_box_bg;

	public void SetLabelText(string _text)
	{
		if (!inited)
			Init();

		text_label.text = _text;
	}
}
