using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerPont : MonoBehaviour
{
    [SerializeField]
    private inventory myInventory;

    [SerializeField]
    private GameObject pontText;

    [SerializeField]
    private GameObject pont;

    private void Start()
    {
        pont.SetActive(false);
        pontText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.transform.gameObject.tag == "Player")
        {
            pontText.SetActive(true);
            List<itemData> myWood = myInventory.content.FindAll(x => x.name == "Wood");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (myWood.Count >= 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        myInventory.content.Remove(myInventory.content.Find(x => x.name == "Wood"));
                    }
                    pont.SetActive(true);
                }

            }
        }
        else
        {
            pontText.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pontText.SetActive(false);
    }
}
