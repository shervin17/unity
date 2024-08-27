using UnityEngine;
using UnityEngine.UI;

public class SignWordChallenge : MonoBehaviour
{
    public Text wordDisplay;
    public Text messageText;
    public Image signImage;
    public InputField guessInputField;
    public Button submitButton;

    private string fixedWord = "ARIGATO";
    private string guesses;
    private int turns = 12;

    public Sprite signSprite;

    void Start()
    {
        submitButton.onClick.RemoveAllListeners(); // Ensure no duplicate listeners
        submitButton.onClick.AddListener(OnSubmitGuess);
        StartNewGame();
    }

    void StartNewGame()
    {
        Debug.Log("Starting new game...");
        guesses = "";
        turns = 12;
        UpdateUI();
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI...");
        string displayWord = "";
        foreach (char c in fixedWord)
        {
            if (guesses.Contains(c.ToString()))
            {
                displayWord += c + " ";
            }
            else
            {
                displayWord += "_ ";
            }
        }
        wordDisplay.text = displayWord.Trim();
        Debug.Log("Display Word: " + displayWord.Trim());

        UpdateSignImage();
        messageText.text = "Guess the letter!";
    }

    void UpdateSignImage()
    {
        if (signSprite != null)
        {
            signImage.sprite = signSprite;
            Debug.Log("Sign Image updated.");
        }
    }

    void OnSubmitGuess()
    {
        string guess = guessInputField.text.ToUpper().Trim(); // Get input and trim whitespace
        Debug.Log("Submitted Guess: '" + guess + "'");

        if (!string.IsNullOrEmpty(guess) && guess.Length == 1)
        {
            if (!guesses.Contains(guess))
            {
                Debug.Log("Processing new guess: " + guess);
                guesses += guess;
                OnGuess(guess);
                guessInputField.text = ""; // Clear the input field after submission
            }
            else
            {
                messageText.text = "You already guessed that letter.";
                Debug.Log("Letter already guessed: " + guess);
            }
        }
        else
        {
            messageText.text = "Please enter a single letter.";
            Debug.LogWarning("Invalid input: " + guess);
        }
    }

    public void OnGuess(string guess)
    {
        Debug.Log("OnGuess called with: '" + guess + "'");

        if (fixedWord.Contains(guess))
        {
            Debug.Log("Correct guess!");

            // Check if the word is completely guessed
            if (IsWordGuessed())
            {
                messageText.text = "You win! The word was: " + fixedWord;
                Debug.Log("Player wins!");
                Invoke("StartNewGame", 2.0f);  // Restart the game after 2 seconds
            }
            else
            {
                UpdateUI();
            }
        }
        else
        {
            turns--;
            messageText.text = "Wrong guess! You have " + turns + " more guesses.";
            Debug.Log("Wrong guess! Turns left: " + turns);

            if (turns <= 0)
            {
                messageText.text = "Game Over! The word was: " + fixedWord;
                Debug.Log("Game Over!");
                Invoke("StartNewGame", 2.0f);  // Restart the game after 2 seconds
            }
        }
    }

    bool IsWordGuessed()
    {
        foreach (char c in fixedWord)
        {
            if (!guesses.Contains(c.ToString()))
            {
                return false;
            }
        }
        return true;
    }
}
