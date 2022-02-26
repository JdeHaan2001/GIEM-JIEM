using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int HealAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            bool canHeal = other.GetComponent<Health>().Heal(HealAmount);
            if (canHeal)
                Destroy(this.gameObject);
        }
    }
}
