using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UINotifyBox : UIElement,IUINotifyBox
{
	[Header("Require IMAGE_BOX tag")]
	public string note = "";

	private Image image_box;
	private Image image_screen;
	private UITextBox textbox;
	private UIButton button_ok;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		image_screen = GetComponent<Image>();
		textbox = GetComponentInChildren<UITextBox>();
		button_ok = GetComponentInChildren<UIButton>();

		foreach (UIElement e in GetComponentsInChildren<UIElement>())
			if (e.GetUIType() == UIType.IMAGE_BOX)
				image_box = e.GetComponent<Image>();

		AddCallbackOk(OnOk);

		return true;
	}

	protected void OnOk()
	{
		Hide_Animated();
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

	public void ClearCallbackOk()
	{
		if (!inited)
			Init();

		button_ok.ClearCallback();
	}
}
