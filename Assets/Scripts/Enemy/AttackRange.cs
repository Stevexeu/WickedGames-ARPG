using System.Collections.Generic;
using UnityEngine;

namespace wickedgames
{
    public class AttackRange : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] public string tagTarget = "Player";
        [SerializeField] public List<Collider2D> detectedObjs = new List<Collider2D>();
        [SerializeField] public BoxCollider2D col;

        [Header("Scripts")]
        public EnemyCore enemyCore;

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == tagTarget)
            {
                detectedObjs.Add(collider);
                enemyCore._inDamageRange = true;
            }
        }

        public void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == tagTarget)
            {
                detectedObjs.Remove(collider);
                enemyCore._inDamageRange = false;
            }
        }
    }
}

