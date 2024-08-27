using UnityEngine;
using UnityEngine.UI;

public class SignCipherGame : MonoBehaviour
{
    public Image signImage;         // Image to show the sign language sentence
    public InputField userInput;    // Input field for user to type their answer
    public Text resultText;         // Text to display the result (Correct or Incorrect)
    public Button submitButton;     // Button to submit the answer
    public Sprite correctSprite;    // Sprite to show a green checkmark when correct

    private string correctAnswer = "Hello"; // The correct sentence

    void Start()
    {
        // Clear result text at the start
        resultText.text = "";

        // Add listener to submit button
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void CheckAnswer()
    {
        // Get the user's input
        string userAnswer = userInput.text;

        // Compare user answer to the correct answer
        if (userAnswer.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            // Show green checkmark or "Correct!" message
            resultText.text = "Correct!";
            resultText.color = Color.green; // Change text color to green
            resultText.fontSize = 30; // Make text larger

            // Optionally, display a green checkmark image
            signImage.sprite = correctSprite;
        }
        else
        {
            resultText.text = "Incorrect! Try again.";
            resultText.color = Color.red; // Change text color to red
            resultText.fontSize = 24; // Standard text size
        }
    }

    // This method can be used to load a new sign and sentence
    public void LoadNewSign(Sprite newSignSprite, string newCorrectAnswer)
    {
        signImage.sprite = newSignSprite;  // Set new sign image
        correctAnswer = newCorrectAnswer;  // Set new correct answer
        userInput.text = "";               // Clear the input field
        resultText.text = "";              // Clear the result text
    }
}
