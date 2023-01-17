using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public string tagTarget = "Player";
    [SerializeField] public float defaultRadius = 5.3f;
    [SerializeField] public float followRadius = 24.27f;
    [SerializeField] public List<Collider2D> detectedObjs = new List<Collider2D>();
    [SerializeField] public CircleCollider2D col;
    [SerializeField] EnemyCore ec;
    [SerializeField] public bool canFollow = false;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Add(collider);
            col.radius = followRadius;
            ec.startFollow();
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Remove(collider);
            col.radius = defaultRadius;
            ec.stopFollow();
        }
    }
}

