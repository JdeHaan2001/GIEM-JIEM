using UnityEngine;
using System;
using System.Collections;

public class LightDamage : MonoBehaviour
{
    public int damage = 5;
    public float waitTimeForDamage = 1.5f;

    bool doDamage = false;

    Light _light;
    Transform playerTrans = null;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void FixedUpdate()
    {
        RaycastHit hitInfo;
        Vector3 direction = Vector3.down;

        Debug.DrawRay(transform.position, Quaternion.AngleAxis(-(_light.spotAngle / 2), Vector3.forward) * direction.normalized * _light.range, Color.red);
        Debug.DrawRay(transform.position, Quaternion.AngleAxis(-(_light.spotAngle / 4), Vector3.forward) * direction.normalized * _light.range, Color.red);
        Debug.DrawRay(transform.position, Quaternion.AngleAxis((_light.spotAngle / 2), Vector3.forward) * direction.normalized * _light.range, Color.red);
        Debug.DrawRay(transform.position, Quaternion.AngleAxis((_light.spotAngle / 4), Vector3.forward) * direction.normalized * _light.range, Color.red);
        Debug.DrawRay(transform.position, direction.normalized * _light.range, Color.red);

        if (Physics.Raycast(transform.position,
                               Quaternion.AngleAxis(-(_light.spotAngle / 2), Vector3.forward) * direction.normalized
                               , out hitInfo, _light.range) && !doDamage)
        {
            if (hitInfo.transform.tag == "Player")
            {
                playerTrans = hitInfo.transform;
                dealDamage();
            }
        }
        if (Physics.Raycast(transform.position,
                               Quaternion.AngleAxis((_light.spotAngle / 2), Vector3.forward) * direction.normalized
                               , out hitInfo, _light.range) && !doDamage)
        {
            if (hitInfo.transform.tag == "Player")
            {
                playerTrans = hitInfo.transform;
                dealDamage();
            }
        }
        if (Physics.Raycast(transform.position,
                               direction.normalized
                               , out hitInfo, _light.range) && !doDamage)
        {
            if (hitInfo.transform.tag == "Player")
            {
                playerTrans = hitInfo.transform;
                dealDamage();
            }
        }
        if (Physics.Raycast(transform.position,
                              Quaternion.AngleAxis(-(_light.spotAngle / 4), Vector3.forward) * direction.normalized
                              , out hitInfo, _light.range) && !doDamage)
        {
            if (hitInfo.transform.tag == "Player")
            {
                playerTrans = hitInfo.transform;
                dealDamage();
            }
        }
        if (Physics.Raycast(transform.position,
                              Quaternion.AngleAxis((_light.spotAngle / 4), Vector3.forward) * direction.normalized
                              , out hitInfo, _light.range) && !doDamage)
        {
            if (hitInfo.transform.tag == "Player")
            {
                playerTrans = hitInfo.transform;
                dealDamage();
            }
        }
    }

    private void dealDamage()
    {
        if (!doDamage)
        {
            doDamage = true;
            StartCoroutine(DamageOverTime());
        }
    }

    private IEnumerator DamageOverTime()
    {
        if (playerTrans != null)
        {
            yield return new WaitForSeconds(waitTimeForDamage);
            if (doDamage)
            {
                playerTrans.GetComponent<Health>().DealDamage(damage);
                Debug.Log("Damage Dealt");
                doDamage = false;
            }
        }
    }
}
