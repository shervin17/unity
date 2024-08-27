using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject question_mark;
    [SerializeField] private Gamecontrol Gamecontroller;


    public void OnMouseDown()
    {
        if (question_mark.activeSelf && Gamecontroller.canOpen)
        {
            question_mark.SetActive(false);
            Gamecontroller.imageOpen(this);
        }
    }
    public int _spriteId;
    public int spriteId
    {
        get
        {
            return _spriteId;
        }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void close()
    {
        question_mark.SetActive(true);
    }
}
