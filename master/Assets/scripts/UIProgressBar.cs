using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIProgressBar : UIElement ,IUIProgressBar
{
	[SerializeField]
	private Image image_bar_bg;
	[SerializeField]
	private Image image_bar_fill;
	[SerializeField]
	private Image image_bar_frame;
	[SerializeField]
	private Text text_bar_load;
	[SerializeField]
	private Text text_bar_title;

	[SerializeField]
	private float ratio = 0.5f;

	public bool isFull { get { return ratio >= 1; } }

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		image_bar_fill.fillAmount = ratio;

		return true;
	}

	private void Update () 
	{
		image_bar_fill.fillAmount = Mathf.Lerp(image_bar_fill.fillAmount, ratio, Time.deltaTime*5);
	}

	public virtual void AddFill(float _add)
	{
		if (!inited)
			Init();

		ratio += _add;
	}

	public virtual void SetFill(float _ratio)
	{
		if (!inited)
			Init();

		ratio = _ratio;
	}

	public virtual float GetFill()
	{
		if (!inited)
			Init();

		return ratio;
	}

	public virtual void SetTitle(string _text)
	{
		if (!inited)
			Init();

		text_bar_title.text = _text;
	}

	public virtual void SetLoadText(string _text)
	{
		if (!inited)
			Init();

		text_bar_load.text = _text;
	}
}
