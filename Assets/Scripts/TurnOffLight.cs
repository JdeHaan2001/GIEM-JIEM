using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnOffLight : MonoBehaviour
{
    public Transform BtnIndicator;
    public Transform DmgLight;

    private bool canDisable = false;
    private void Start()
    {
        BtnIndicator.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDisable)
        {
            DmgLight.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            canDisable = true;
            BtnIndicator.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            canDisable = false;
            BtnIndicator.gameObject.SetActive(false);
        }
    }
}
