using UnityEngine;

public enum UIType
{
	NOTSET = 0,

	//group
	PROGRESSBAR = 1,
	TEXT_BOX = 2,
	BOX_NOTIFY = 3,
	BUTTON_OK = 4,
	BUTTON_NO = 5,
	BUTTON = 6,
	BOARD = 17,
	INPUTFIELD = 19,
	BOX_INPUT = 20,
	BOX_SCROLL = 21,
	BOX_ASK2 = 22,
	SCREEN_NOTIFY = 23,

	//text
	TEXT_TITLE = 7,
	TEXT_LOAD = 8,
	TEXT_BUTTON = 9,
	TEXT_CONTENT = 10,
	TEXT_LABEL = 16,
	TEXT_PLACE = 18,

	//image
	IMAGE_AREA = 11,
	IMAGE_BUTTON = 12,
	IMAGE_FILL = 13,
	IMAGE_BG = 14,
	IMAGE_FRAME = 15,
	IMAGE_BOX = 24,

	//next 25
}

public interface IUIElement
{
	UIType GetUIType();

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

public interface IUINotifyBox
{
	void SetContent(string _text);
	void SetButton(string _text);

	void AddCallbackOk(UnityEngine.Events.UnityAction action);
	void ClearCallbackOk();
}

public interface IUIAskBox2
{
	void SetContent(string _text);
	void SetButton(string _text1, string _tex2);

	void AddCallbackYes(UnityEngine.Events.UnityAction action);
	void AddCallbackNo(UnityEngine.Events.UnityAction action);
	void ClearCallbackYes();
	void ClearCallbackNo();
}

public interface IUIButton
{
	void SetText(string _text);
	void SetImage(Sprite sprite);

	void AddCallback(UnityEngine.Events.UnityAction action);
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

	void AddCallbackOnChanged(UnityEngine.Events.UnityAction<string> action);
	void AddCallbackOnEntered(UnityEngine.Events.UnityAction<string> action);
	void ClearCallbackOnChanged();
	void ClearCallbackOnEntered();
}

public interface IUIInputBox
{
	string GetInputText();
	void SetLabelText(string _text);
	void SetPlaceHolderText(string _text);

	void AddCallbackOnChanged(UnityEngine.Events.UnityAction<string> action);
	void AddCallbackOnEntered(UnityEngine.Events.UnityAction<string> action);
	void ClearCallbackOnChanged();
	void ClearCallbackOnEntered();
}

public interface IUIScrollBox
{

}