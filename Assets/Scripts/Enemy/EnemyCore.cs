using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wickedgames;

public class EnemyCore : MonoBehaviour
{
    public Rigidbody2D body;
    Detection detection;

    public void Start()
    {
        Detection detection = GetComponent<Detection>();
    }

    public void Freeze()
    {
        body.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void Unfreeze()
    {
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
