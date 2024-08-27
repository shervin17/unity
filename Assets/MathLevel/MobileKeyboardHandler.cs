using UnityEngine;
using UnityEngine.UI;

public class MobileKeyboardHandler : MonoBehaviour
{
    public InputField inputField;

    void Start()
    {
        inputField.onEndEdit.AddListener(OnInputFieldClick);
    }

    public void OnInputFieldClick(string text)
    {
        inputField.ActivateInputField();
    }
}

