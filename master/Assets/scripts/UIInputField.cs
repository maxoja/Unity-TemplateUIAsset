using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInputField : UIElement,IUIInputField 
{
	[SerializeField]
	private InputField input_field;
	[SerializeField]
	private Text text_placeholder;
	[SerializeField]
	private Image image_text_bg;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;
		
		inited = true;

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

	public virtual void SetPlaceHolderText(string _text)
	{
		if (!inited)
			Init();

		text_placeholder.text = _text;
	}

	public virtual string GetInputText()
	{
		if (!inited)
			Init();

		return input_field.text;
	}

	public virtual void AddCallbackOnChanged(UnityEngine.Events.UnityAction<string> action)
	{
		if (!inited)
			Init();
		
		input_field.onValueChanged.AddListener(action);
	}

	public virtual void AddCallbackOnEntered(UnityEngine.Events.UnityAction<string> action)
	{
		if (!inited)
			Init();

		input_field.onEndEdit.AddListener(action);
	}

	public virtual void ClearCallbackOnChanged()
	{
		if (!inited)
			Init();

		input_field.onValueChanged.RemoveAllListeners();
	}

	public virtual void ClearCallbackOnEntered()
	{
		if (!inited)
			Init();

		input_field.onEndEdit.RemoveAllListeners();
	}
}
