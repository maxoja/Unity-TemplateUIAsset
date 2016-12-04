using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIElement : MonoBehaviour, IUIElement
{
	[SerializeField]
	protected UIType type;
	[SerializeField]
	protected float speed_animator = 1f;

	[HideInInspector]
	public bool showed = false;

	private Animator animator;
	private UIElement[] childElements;
	private Image thisImage;
	private Text thisText;

	protected bool raycasting = true;
	protected bool inited = false;

	protected virtual void Awake()
	{
		Init();
	}

	public virtual bool Init()
	{
		if (inited)
			return false;

		inited = true;

		childElements = GetComponentsInChildren<UIElement>();
		animator = GetComponent<Animator>();
		thisImage = GetComponent<Image>();
		thisText = GetComponent<Text>();

		raycasting = !raycasting;
		SetRaycasting(!raycasting);

		if (animator != null)
			animator.speed = speed_animator;

		foreach (UIElement e in childElements)
			e.Init();
		
		return true;
	}

	private void SetRaycasting(bool enable)
	{
		if (raycasting == enable)
			return;

		raycasting = enable;

		if (thisImage != null)
			thisImage.raycastTarget = enable;
		if (thisText != null)
			thisText.raycastTarget = enable;

		foreach (UIElement e in childElements)
			e.SetRaycasting(enable);
	}

	public UIType GetUIType()
	{
		return type;
	}

	public void Show_Sudden()
	{
		if (!inited)
			Init();

		if (showed)
			return;

		showed = true;
		gameObject.SetActive(true);
		SetRaycasting(true);

		if (animator != null)
		{
			if (!animator.isInitialized)
			{
				animator.StartPlayback();
				animator.speed = speed_animator;
			}
			animator.Play("showed");
		}
	}

	public void Hide_Sudden()
	{
		if (!inited)
			Init();

		if (!showed)
			return;

		showed = false;

		if (animator != null)
		{
			if (!animator.isInitialized)
			{
				animator.StartPlayback();
				animator.speed = speed_animator;
			}

			animator.Play("hidden");
		}

		SetRaycasting(false);
		gameObject.SetActive(false);
	}

	public void Show_Animated()
	{
		if (!inited)
			Init();

		if (showed)
			return;

		if (animator == null)
		{
			Debug.LogWarning("no animator attached\ncannot Show_Animated()");
			return;
		}

		showed = true;
		gameObject.SetActive(true);
		SetRaycasting(true);

		if (!animator.isInitialized)
		{
			animator.StartPlayback();
			animator.speed = speed_animator;
		}

		animator.SetTrigger("show");

		foreach (UIElement childElement in childElements)
			if (childElement != this)
				childElement.Show_Animated();
	}

	public void Hide_Animated()
	{
		if (!inited)
			Init();

		if (!showed)
			return;

		if (animator == null)
		{
			Debug.LogWarning("no animator attached\ncannot Show_Animated()");
			return;
		}

		showed = false;

		if (!animator.isInitialized)
		{
			animator.StartPlayback();
			animator.speed = speed_animator;
		}

		SetRaycasting(false);
		animator.SetTrigger("hide");

		foreach (UIElement childElement in childElements)
			if (childElement != this)
				childElement.Hide_Animated();

	}
}
