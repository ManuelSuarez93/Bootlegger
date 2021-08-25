using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    

    [SerializeField] private AudioClip closeSound;
    [SerializeField] private AudioClip openSound;

    [SerializeField] private Sprite closeSprite;
    [SerializeField] private Sprite openSprite;

    private AudioSource _as;
    private SpriteRenderer _sr;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
        _sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    public void Open()
    {
        _as.clip = openSound;
        _as.Play();
        _sr.sprite = openSprite;
    }
    public void Close()
    {
        _as.clip = closeSound;
        _as.Play();
        _sr.sprite = closeSprite;
    }
}
