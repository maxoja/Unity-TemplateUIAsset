using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public UIElement box,block;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			box.Hide_Animated();
			//block.Hide_Animated();
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			box.Show_Animated();
			//block.Show_Animated();
		}
	}
}
