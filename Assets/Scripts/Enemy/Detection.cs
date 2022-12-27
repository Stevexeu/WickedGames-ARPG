using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public string tagTarget = "Player";
    [SerializeField] public List<Collider2D> detectedObjs = new List<Collider2D>();
    [SerializeField] public Collider2D col;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Add(collider);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Remove(collider);
        }
    }
}
