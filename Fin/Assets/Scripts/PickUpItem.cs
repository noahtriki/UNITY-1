using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private float pickUpRange = 2.6f;

    public PickUpBehaviour playerPickUpBehaviour;

    [SerializeField]
    private GameObject pickUpText;

    [SerializeField]
    private GameObject EatText;

    [SerializeField]
    private VarLife playerLife;

    [SerializeField]
    private LayerMask layerMask;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpRange, layerMask))
        {
            if (hit.transform.CompareTag("Item"))
            {
                pickUpText.SetActive(true);
                Debug.Log("Item devant");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerPickUpBehaviour.DoPickUp(hit.transform.gameObject.GetComponent<Item>());
                }
            }

            if (hit.transform.CompareTag("Bouffe"))
            {
                EatText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    playerPickUpBehaviour.DoEat();
                    playerLife.faim += 20;
                }
            }
        }
        else
        {
            EatText.SetActive(false);
            pickUpText.SetActive(false);
        }
    }
}
