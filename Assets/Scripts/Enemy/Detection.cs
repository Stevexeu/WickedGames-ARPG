using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private string tagTarget = "Player";
    [SerializeField] private List<Collider2D> detectedObjs = new List<Collider2D>();
    [SerializeField] private Collider2D col;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Add(collider);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Remove(collider);
        }
    }
}
