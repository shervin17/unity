using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField] private Gamecontrol gameController;
    [SerializeField] private string FunctionOnclick;


    public void onMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
        {
            sprite.color = Color.cyan;
        }
    }


   
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 0.1f);
        if (gameController != null)
        {
            gameController.SendMessage(FunctionOnclick);
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = Color.white;
        }
    }
}
