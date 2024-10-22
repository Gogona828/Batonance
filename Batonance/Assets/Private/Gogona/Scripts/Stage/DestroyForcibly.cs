using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForcibly : MonoBehaviour
{
    private GameObject destroyTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log($"Missed the enemy");
            BGMManager.instance.isMissed = false;
            
            AdministerGameState.instance.GameOver();
            destroyTarget = other.gameObject;
            StartCoroutine(DestroyEnemy());
        }
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3);
        Destroy(destroyTarget);
    }
}
