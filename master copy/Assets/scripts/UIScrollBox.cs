using UnityEngine;
using System.Collections;

public class UIScrollBox : UIElement , IUIScrollBox 
{ 
	public override bool Init()
	{
		if (base.Init() == false)
			return false;



		return true;
	}
}
