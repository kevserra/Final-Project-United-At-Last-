using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] Collider2D dmgCol;
    [SerializeField] private float currentDmg = 1f;

    public void EnableCollider()
    {
        dmgCol.enabled = true;
    }

    public void DisableCollider()
    {
        dmgCol.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collis)
    {
        if (collis.CompareTag("Player"))
        {
            IDamagable other = collis.gameObject.GetComponent<IDamagable>();

            if (other != null)
            {
                other.TakeDamage(currentDmg);
                
            }
        }
    }






}
