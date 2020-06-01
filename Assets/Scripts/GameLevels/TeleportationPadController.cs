﻿using UnityEngine;
using System.Collections;

public class TeleportationPadController : MonoBehaviour
{
    public TeleportationPadController otherPad;

    private bool enable;
    private float delay = 1f;
    
    private void Start()
    {
        enable = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Teleport(other.gameObject);
        }
    }

    private void Teleport(GameObject player)
    {
        if (enable)
        {
            SetPosition(player, otherPad.gameObject.transform.position);
            otherPad.StartCoroutine("TemporaryDisable");
        }
    }

    private void SetPosition(GameObject other, Vector3 position)
    {
        other.transform.position = position;
    }

    private IEnumerator TemporaryDisable()
    {
        enable = false;
        yield return new WaitForSeconds(delay);
        enable = true;
    }
}
