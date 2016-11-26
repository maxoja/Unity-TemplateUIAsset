using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIProgressBar : UIElement ,IUIProgressBar
{
	[Header("Require tag imagefill")]
	[Header("Require tag imageframe")]
	[Header("Require tag textload")]
	[Header("Require tag texttitle")]
	public string notes = "";

	private Image image_bg;
	private Image image_fill;
	private Image image_frame;
	private Text text_load;
	private Text text_title;

	private float ratio = 0.5f;

	public override bool Init()
	{
		if (base.Init() == false)
			return false;
		
		image_bg = GetComponent<Image>();

		foreach (UIElement childElement in GetComponentsInChildren<UIElement>())
		{
			switch (childElement.GetUIType())
			{
				case UIType.IMAGE_FILL:
					image_fill = childElement.GetComponent<Image>();
					break;

				case UIType.IMAGE_FRAME:
					image_frame = childElement.GetComponent<Image>();
					break;

				case UIType.TEXT_LOAD:
					text_load = childElement.GetComponent<Text>();
					break;

				case UIType.TEXT_TITLE:
					text_title = childElement.GetComponent<Text>();
					break;
			}
		}

		return true;
	}

	// Update is called once per frame
	void Update () 
	{
		image_fill.fillAmount = Mathf.Lerp(image_fill.fillAmount, ratio, Time.deltaTime);
	}

	public void AddFill(float _add)
	{
		if (!inited)
			Init();

		ratio += _add;
	}

	public void SetFill(float _ratio)
	{
		if (!inited)
			Init();

		ratio = _ratio;
	}

	public void SetTitle(string _text)
	{
		if (!inited)
			Init();

		text_title.text = _text;
	}

	public void SetLoadText(string _text)
	{
		if (!inited)
			Init();

		text_load.text = _text;
	}
}
