using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextBox : UIElement,IUITextbox
{
	[SerializeField]
	private Image image_box_bg;
	[SerializeField]
	private Text text_content;

	public virtual void SetText(string _text)
	{
		if (!inited)
			Init();

		text_content.text = _text;
	}
}

