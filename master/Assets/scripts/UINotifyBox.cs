using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UINotifyBox : UIElement,IUINotifyBox
{
	[SerializeField]
	private Image image_box_bg;
	[SerializeField]
	private Image image_blockade;
	[SerializeField]
	private UITextBox textbox;
	[SerializeField]
	private UIButton button_ok;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		AddCallbackOk(OnOk);

		return true;
	}

	protected virtual void OnOk()
	{
		Hide_Animated();
	}

	public virtual void SetContent(string  _text)
	{
		if (!inited)
			Init();

		textbox.SetText(_text);
	}

	public virtual void SetButton(string _text)
	{
		if (!inited)
			Init();

		button_ok.SetText(_text);
	}

	public virtual void AddCallbackOk(UnityEngine.Events.UnityAction action)
	{
		if (!inited)
			Init();

		button_ok.AddCallback(action);
	}

	public virtual void ClearCallbackOk()
	{
		if (!inited)
			Init();

		button_ok.ClearCallback();
	}
}
