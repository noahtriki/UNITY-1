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
            
            List<itemData> myWood = myInventory.content.FindAll(x => x.name == "Wood");
            List<itemData> myStone = myInventory.content.FindAll(x => x.name == "stone");
            pontText.GetComponent<Text>().text = $"Press E to Build the Bridge\n ({myStone.Count}/5 stones AND {myWood.Count}/10 woods)";
            pontText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (myWood.Count >= 10 && myStone.Count >= 5)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        myInventory.content.Remove(myInventory.content.Find(x => x.name == "Wood"));
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        myInventory.content.Remove(myInventory.content.Find(x => x.name == "Stone"));
                    }
                    pont.SetActive(true);
                    pontText.GetComponent<Text>().text = "";
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
