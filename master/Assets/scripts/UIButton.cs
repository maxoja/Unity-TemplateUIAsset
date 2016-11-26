using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButton : UIElement,IUIButton 
{
	private Image image_button;
	private Button button;
	private Text text_button;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		button = GetComponent<Button>();
		image_button = GetComponent<Image>();
		text_button = GetComponentInChildren<Text>();

		button.onClick.AddListener(OnClick);

		return true;
	}

	protected virtual void OnClick()
	{
		return;
	}

	public void SetText(string _text)
	{
		if (!inited)
			Init();
		
		text_button.text = _text;
	}

	public void AddCallback(UnityEngine.Events.UnityAction action)
	{
		if (!inited)
			Init();
		
		button.onClick.AddListener(action);
	}
}
