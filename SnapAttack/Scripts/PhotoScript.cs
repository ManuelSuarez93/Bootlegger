using System;
using UnityEngine;
using UnityEngine.Events;

public class PhotoScript : MonoBehaviour
{
    [SerializeField] private bool photoObjInside;
    [SerializeField] private GameObject gmObj;
    
    [SerializeField] private GameObject starIn;

    public photoEvent _photoEvent;
    [Serializable]
    public class photoEvent : UnityEvent<int> { }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && photoObjInside)
        {
            if(gmObj.CompareTag("PhotoObj"))
            {
                _photoEvent.Invoke(1);
            }
            else
            {
                _photoEvent.Invoke(-1);
            }
            Destroy(gmObj);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            gmObj = collision.gameObject;
            starIn.SetActive(true);
            photoObjInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            gmObj = null;
            starIn.SetActive(false);
            photoObjInside = false;
    }

}
