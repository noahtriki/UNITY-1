using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [SerializeField]
    private VarLife playerLife;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerLife.soif += 2f;
        }
    }
}
