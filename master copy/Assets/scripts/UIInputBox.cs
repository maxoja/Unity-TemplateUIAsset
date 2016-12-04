using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInputBox : UIElement,IUIInputBox
{
	private Image image_bg;
	private Text text_label;
	private UIInputField inputfield;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		image_bg = GetComponent<Image>();
		inputfield = GetComponentInChildren<UIInputField>();
		foreach (UIElement e in GetComponentsInChildren<UIElement>())
			if (e.GetUIType() == UIType.TEXT_LABEL)
			{
				text_label = e.GetComponent<Text>();
				break;
			}

		AddCallbackOnChanged(OnChanged);
		AddCallbackOnEntered(OnEntered);

		return true;
	}

	protected virtual void OnChanged(string text)
	{
		return;
	}

	protected virtual void OnEntered(string text)
	{
		return;
	}

	public string GetInputText()
	{
		if (!inited)
			Init();
		
		return inputfield.GetInputText();
	}

	public void SetLabelText(string _text)
	{
		if (!inited)
			Init();

		text_label.text = _text;
	}

	public void SetPlaceHolderText(string _text)
	{
		if (!inited)
			Init();

		inputfield.SetPlaceHolderText(_text);
	}

	public void AddCallbackOnChanged(UnityEngine.Events.UnityAction<string> action)
	{
		if (!inited)
			Init();

		inputfield.AddCallbackOnChanged(action);
	}

	public void AddCallbackOnEntered(UnityEngine.Events.UnityAction<string> action)
	{
		if (!inited)
			Init();

		inputfield.AddCallbackOnEntered(action);
	}

	public void ClearCallbackOnChanged()
	{
		if (!inited)
			Init();

		inputfield.ClearCallbackOnChanged();
	}

	public void ClearCallbackOnEntered()
	{
		if (!inited)
			Init();

		inputfield.ClearCallbackOnEntered();
	}
}
