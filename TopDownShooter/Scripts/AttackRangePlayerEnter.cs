using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRangePlayerEnter : MonoBehaviour
{
    [Tooltip("Tags")]
    [SerializeField] private List<string> tags;
    [SerializeField] private UnityEvent enableAttack;
    [SerializeField]public UnityEvent disableAttack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tags.Contains(collision.tag))
        {
            enableAttack.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tags.Contains(collision.tag))
        {
            disableAttack.Invoke();
        }
    }
}
