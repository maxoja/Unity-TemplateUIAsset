using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class UIAskBox : UIElement,IUIAskBox 
{
	[SerializeField]
	private Image image_blockade;
	[SerializeField]
	private Image image_box_bg;
	[SerializeField]
	private UITextBox textbox;
	[SerializeField]
	private UIButton[] buttons;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		AddButtonsCallback(new UnityAction[] { OnYes, OnNo });

		return true;
	}

	protected virtual void OnYes()
	{
		return;
	}

	protected virtual void OnNo()
	{
		return;
	}

	public virtual void SetContent(string  _text)
	{
		if (!inited)
			Init();

		textbox.SetText(_text);
	}

	public virtual void SetButton(int _id , string _text )
	{
		if (!inited)
			Init();

		if (_id >= buttons.Length || _id < 0)
		{
			print("button id out of range for set text");
			return;
		}
		
		buttons[_id].SetText(_text);
	}

	public virtual void SetButtons(string[] texts)
	{
		if (!inited)
			Init();

		for (int i = 0; i < texts.Length; i++)
		{
			if (i >= buttons.Length)
				break;
			SetButton(i, texts[i]);
		}
	}

	public virtual void AddButtonCallback(int _id, UnityAction action)
	{
		if (!inited)
			Init();

		if (_id >= buttons.Length || _id < 0)
		{
			print("button id out of range for add a button callback : " + _id.ToString());
			return;
		}

		buttons[_id].AddCallback(action);
	}

	public virtual void AddButtonsCallback(UnityAction[] actions)
	{
		if (!inited)
			Init();

		for (int i = 0; i < actions.Length; i++)
			if (i <= buttons.Length)
				AddButtonCallback(i, actions[i]);
	}

	public virtual void ClearButtonCallback(int _id)
	{
		if (!inited)
			Init();

		if (_id >= buttons.Length || _id < 0)
		{
			print("button id out of range for add a button callback : " + _id.ToString());
			return;
		}

		buttons[_id].ClearCallback();
	}

	public virtual void ClearButtonsCallbacks()
	{
		if (!inited)
			Init();

		for (int i = 0; i < buttons.Length; i++)
		{
			ClearButtonCallback(i);
		}
	}
}
