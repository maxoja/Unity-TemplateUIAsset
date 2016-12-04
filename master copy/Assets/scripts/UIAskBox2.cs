using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIAskBox2 : UIElement,IUIAskBox2 
{
	[Header("Require IMAGE_BOX tag")]
	[Header("Require BUTTON_OK tag")]
	[Header("Require BUTTON_NO tag")]
	public string note = "";

	private Image image_board;
	private Image image_box;
	private UITextBox textbox;
	private UIButton button_yes;
	private UIButton button_no;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		image_board = GetComponent<Image>();
		textbox = GetComponentInChildren<UITextBox>();

		foreach ( UIElement e in GetComponentsInChildren<UIElement>())
			switch (e.GetUIType())
			{
			case UIType.IMAGE_BOX :
					image_box = e.GetComponent<Image>();
					break;
			case UIType.BUTTON_OK :
					button_yes = e.GetComponent<UIButton>();
					break;
			case UIType.BUTTON_NO :
					button_no = e.GetComponent<UIButton>();
					break;
			}

		AddCallbackYes(OnYes);
		AddCallbackNo(OnNo);

		return true;
	}

	protected void OnYes()
	{
		return;
	}

	protected void OnNo()
	{
		return;
	}

	public void SetContent(string  _text)
	{
		if (!inited)
			Init();

		textbox.SetText(_text);
	}

	public void SetButton(string _text1 , string _text2 )
	{
		if (!inited)
			Init();

		button_yes.SetText(_text1);
		button_no.SetText(_text2);
	}

	public void AddCallbackYes(UnityEngine.Events.UnityAction action)
	{
		if (!inited)
			Init();

		button_yes.AddCallback(action);
	}

	public void AddCallbackNo(UnityEngine.Events.UnityAction action)
	{
		if (!inited)
			Init();

		button_no.AddCallback(action);
	}

	public void ClearCallbackYes()
	{
		if (!inited)
			Init();
		
		button_yes.ClearCallback();
	}

	public void ClearCallbackNo()
	{
		if (!inited)
			Init();

		button_no.ClearCallback();
	}
}
