using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextBox : UIElement,IUITextbox
{
	[Header("Require no tag")]
	public string note = "";

	private Image image_bg;
	private Text text_content;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		image_bg = GetComponent<Image>();
		text_content = GetComponentInChildren<Text>();

		return true;
	}

	public void SetText(string _text)
	{
		if (!inited)
			Init();

		text_content.text = _text;
	}
}

