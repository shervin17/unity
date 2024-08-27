using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private string inputText = ""; // The text input by the user
    private TouchScreenKeyboard keyboard; // The keyboard instance

    void Update()
    {
        // Check if the keyboard is not active and if the user hasn't started typing yet
        if (keyboard == null)
        {
            // Open the keyboard
            if (Input.GetKeyDown(KeyCode.Space)) // For example, using Space key to trigger keyboard
            {
                keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            }
        }
        else
        {
            // If the keyboard is active and done, retrieve the text
            if (keyboard.done)
            {
                inputText = keyboard.text;
                keyboard = null; // Reset the keyboard instance
            }
        }
    }

    void OnGUI()
    {
        // Display the text entered by the user
        GUI.Label(new Rect(10, 10, 300, 30), "User Input: " + inputText);

        // A button to trigger the keyboard for testing purposes
        if (GUI.Button(new Rect(10, 50, 100, 30), "Open Keyboard"))
        {
            keyboard = TouchScreenKeyboard.Open(inputText, TouchScreenKeyboardType.Default);
        }
    }
}

