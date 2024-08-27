using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class mathproblem : MonoBehaviour
{
    // Reference to the image components
    public Image image3;
    public Image image4;

    // Reference to the input field and button
    public TMP_InputField inputField;
    public Button submitButton;

    // Values for the images
    private int value1;
    private int value2;

    // Start is called before the first frame update
    void Start()
    {
        // Read values from the image names
        value1 = GetValueFromImageName(image3);
        value2 = GetValueFromImageName(image4);

        // Set input field to numeric input
        inputField.contentType = TMP_InputField.ContentType.IntegerNumber;

        // Add listener for the submit button
        submitButton.onClick.AddListener(CheckAnswer);

        // Ensure the input field gets focus to bring up the keyboard on mobile
        inputField.ActivateInputField();
    }

    // Method to extract the value from the image name
    int GetValueFromImageName(Image img)
    {
        // Assuming the image names are in the format "imageX" where X is the value
        string imageName = img.sprite.name;
        Match match = Regex.Match(imageName, @"\d+");
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        else
        {
            Debug.LogError("Invalid image name format. Expected a number in the name.");
            return 0;
        }
    }

    // Method to check the user's answer
    void CheckAnswer()
    {
        // Get the user input and parse it to an integer
        int userAnswer;
        if (int.TryParse(inputField.text, out userAnswer))
        {
            // Check if the user answer is correct
            if (userAnswer == (value1 + value2))
            {
                Debug.Log("Correct Answer!");
                // You can add further logic here, e.g., loading the next level
            }
            else
            {
                Debug.Log("Incorrect Answer. Try Again!");
                // Handle incorrect answer, e.g., show a message or clear the input field
                inputField.text = "";
            }
        }
        else
        {
            Debug.Log("Invalid input. Please enter a number.");
            // Handle invalid input, e.g., show a message or clear the input field
            inputField.text = "";
        }

        // Re-focus the input field to bring up the keyboard on mobile
        inputField.ActivateInputField();
    }
}
