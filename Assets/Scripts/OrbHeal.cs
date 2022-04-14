using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHeal : MonoBehaviour
{
    public float heal = 1;
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.BroadcastMessage("HealHp", heal, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
