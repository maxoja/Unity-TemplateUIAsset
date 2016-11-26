using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UINotifyBox : UIElement,IUINotifyBox
{
	[Header("Require no tag")]
	public string note = "";

	private Image image_bg;
	private UITextBox textbox;
	private UIButton button_ok;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		image_bg = GetComponent<Image>();
		textbox = GetComponentInChildren<UITextBox>();
		button_ok = GetComponentInChildren<UIButton>();

		AddCallbackOk(OnOk);

		return true;
	}

	protected void OnOk()
	{
		return;
	}

	public void SetContent(string  _text)
	{
		if (!inited)
			Init();

		textbox.SetText(_text);
	}

	public void SetButton(string _text)
	{
		if (!inited)
			Init();

		button_ok.SetText(_text);
	}

	public void AddCallbackOk(UnityEngine.Events.UnityAction action)
	{
		if (!inited)
			Init();

		button_ok.AddCallback(action);
	}
}
