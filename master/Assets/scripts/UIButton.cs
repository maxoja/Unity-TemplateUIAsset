using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButton : UIElement,IUIButton 
{
	[SerializeField]
	private Image image_button_bg;
	[SerializeField]
	private Button button;
	[SerializeField]
	private Text text_button;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;
		
		button.onClick.AddListener(OnClick);

		return true;
	}

	protected virtual void OnClick()
	{
		return;
	}

	public virtual void SetText(string _text)
	{
		if (!inited)
			Init();
		
		text_button.text = _text;
	}

	public virtual void SetImage(Sprite sprite)
	{
		if (!inited)
			Init();
		
		image_button_bg.sprite = sprite;
	}

	public virtual void AddCallback(UnityEngine.Events.UnityAction action)
	{
		if (!inited)
			Init();
		
		button.onClick.AddListener(action);
	}

	public virtual void ClearCallback()
	{
		if (!inited)
			Init();

		button.onClick.RemoveAllListeners();
	}
}
