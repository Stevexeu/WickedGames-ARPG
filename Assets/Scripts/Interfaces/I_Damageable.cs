using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Damageable
{
    public float Health { set; get; }
    public bool Targetable { set; get; }
    public void OnHit(float damage, Vector2 knockback);
    public void OnHit(float damage);
    public void OnObjectDestroyed();
}
