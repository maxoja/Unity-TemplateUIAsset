using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIElement : MonoBehaviour , IUIElement
{
	[SerializeField]
	protected UIType type;

	[HideInInspector]
	public bool showed = false;

	private Animator animator;
	private UIElement[] childElements;

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

		foreach (UIElement e in childElements)
			e.Init();

		return true;
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

		if (animator != null)
		{
			if (!animator.isInitialized)
				animator.StartPlayback();

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
				animator.StartPlayback();

			animator.Play("hidden");
		}
		
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

		if (!animator.isInitialized)
			animator.StartPlayback();

		animator.SetTrigger("show");

		foreach (UIElement childElement in childElements)
			if ( childElement != this )
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
			animator.StartPlayback();
		
		animator.SetTrigger("hide");

		foreach (UIElement childElement in childElements)
			if ( childElement != this )
				childElement.Hide_Animated();

	}
}
