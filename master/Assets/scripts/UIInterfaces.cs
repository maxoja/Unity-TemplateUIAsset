using UnityEngine;
using UnityEngine.Events;

public interface IUIElement
{
	bool Init();

	void Show_Sudden();
	void Hide_Sudden();

	void Hide_Animated();
	void Show_Animated();
}

public interface IUIProgressBar
{
	void AddFill(float _add);
	void SetFill(float _ratio);
	void SetTitle(string _text);
	void SetLoadText(string _text);
}

public interface IUIButton
{
	void SetText(string _text);
	void SetImage(Sprite sprite);

	void AddCallback(UnityAction action);
	void ClearCallback();
}

public interface IUITextbox
{
	void SetText(string _text);
}

public interface IUIInputField
{
	void SetPlaceHolderText(string _text);
	string GetInputText();

	void AddCallbackOnChanged(UnityAction<string> action);
	void AddCallbackOnEntered(UnityAction<string> action);
	void ClearCallbackOnChanged();
	void ClearCallbackOnEntered();
}

public interface IUIInputBox : IUIInputField
{
	void SetLabelText(string _text);
}

public interface IUINotifyBox
{
	void SetContent(string _text);
	void SetButton(string _text);

	void AddCallbackOk(UnityAction action);
	void ClearCallbackOk();
}

public interface IUIAskBox
{
	void SetContent(string _text);

	void SetButton(int _id , string _text);
	void SetButtons(string[] texts);

	void AddButtonCallback(int _id, UnityAction action);
	void AddButtonsCallback(UnityAction[] actions);
	void ClearButtonCallback(int _id);
	void ClearButtonsCallbacks();
}



public interface IUIScrollBox
{

}


//public enum UIType
//{
//	NOTSET = 0,

//	//group
//	PROGRESSBAR = 1,
//	TEXT_BOX = 2,
//	BOX_NOTIFY = 3,
//	BUTTON_OK = 4,
//	BUTTON_NO = 5,
//	BUTTON = 6,
//	BOARD = 17,
//	INPUTFIELD = 19,
//	BOX_INPUT = 20,
//	BOX_SCROLL = 21,
//	BOX_ASK2 = 22,
//	SCREEN_NOTIFY = 23,

//	//text
//	TEXT_TITLE = 7,
//	TEXT_LOAD = 8,
//	TEXT_BUTTON = 9,
//	TEXT_CONTENT = 10,
//	TEXT_LABEL = 16,
//	TEXT_PLACE = 18,

//	//image
//	IMAGE_AREA = 11,
//	IMAGE_BUTTON = 12,
//	IMAGE_FILL = 13,
//	IMAGE_BG = 14,
//	IMAGE_FRAME = 15,
//	IMAGE_BOX = 24,

//	//next 25
//}