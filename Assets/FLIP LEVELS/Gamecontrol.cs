using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamecontrol : MonoBehaviour
{
    public const int column = 2;
    public const int rows = 2;

    public static float xspace = 4f;
    public static float yspace = -5f;

    [SerializeField] private NewBehaviourScript startObject;
    [SerializeField] private Sprite[] images;

    private int[] Randomizer(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int temp = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
    }

    private void Start()
    {
        // Adjust locations array to have only two pairs
        int[] locations = { 0, 0, 1, 1 };
        locations = Randomizer(locations);

        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < column; j++)
            {
                NewBehaviourScript gameImage;
                if (i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as NewBehaviourScript;
                }
                int index = j + column * i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (xspace * j) + startPosition.x;
                float positionY = (yspace * i) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private NewBehaviourScript firstOpen;
    private NewBehaviourScript secondOpen;

    private int score = 0;
    private int attempts = 0;

    [SerializeField] private TextMesh scoreText;
    [SerializeField] private TextMesh attemptText;

    public bool canOpen
    {
        get
        {
            return secondOpen == null;
        }
    }

    public void imageOpen(NewBehaviourScript startObject)
    {
        if (firstOpen == null)
        {
            Debug.Log("First image opened");
            firstOpen = startObject;
        }
        else if (secondOpen == null)
        {
            Debug.Log("Second image opened");
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId) //compares the two
        {
            Debug.Log("Match found");
            score++; // add score
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.Log("No match found");
            yield return new WaitForSeconds(0.5f); //start timer
            firstOpen.close();
            secondOpen.close();
        }

        attempts++;
        attemptText.text = "Attempt: " + attempts;

        Debug.Log("Resetting firstOpen and secondOpen");
        firstOpen = null;
        secondOpen = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("level 1");
    }
}
