using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInputField : UIElement,IUIInputField 
{
	[Header("no tagging required")]
	public string note = "";

	private InputField input;
	private Text text_placeholder;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;
		
		inited = true;
		input = GetComponent<InputField>();

		foreach (UIElement e in GetComponentsInChildren<UIElement>())
			if (e.GetUIType() == UIType.TEXT_PLACE)
			{
				text_placeholder = e.GetComponent<Text>();
				break;
			}

		AddCallbackOnChanged(OnChanged);
		AddCallbackOnEntered(OnEntered);

		return true;
	}

	protected virtual void OnChanged(string text )
	{
		return;
	}

	protected virtual void OnEntered(string text)
	{
		return;
	}

	public void SetPlaceHolderText(string _text)
	{
		if (!inited)
			Init();

		text_placeholder.text = _text;
	}

	public string GetInputText()
	{
		if (!inited)
			Init();

		return input.text;
	}

	public void AddCallbackOnChanged(UnityEngine.Events.UnityAction<string> action)
	{
		if (!inited)
			Init();

		input.onValueChanged.AddListener(action);
	}

	public void AddCallbackOnEntered(UnityEngine.Events.UnityAction<string> action)
	{
		if (!inited)
			Init();

		input.onEndEdit.AddListener(action);
	}
}
