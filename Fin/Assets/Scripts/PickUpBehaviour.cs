using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    [SerializeField]
    private MoveBehaviour playerMoveBehaviour;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private inventory inventory;

    private Item currentItem;


    public void DoPickUp(Item item)
    {
        if (inventory.IsFull())
        {
            Debug.Log($"Inventory full, can't pick up : {item.name}");
            return;
        }
            

        currentItem = item;

        playerAnimator.SetTrigger("PickUp");
        playerMoveBehaviour.canMove = false;
    }

    public void DoEat()
    {
        playerAnimator.SetTrigger("PickUp");
        playerMoveBehaviour.canMove = false;
    }

    public void AddItemToInventory()
    {
        if (currentItem.tag == "Item")
        {
            inventory.Additem(currentItem.itemData);
            Destroy(currentItem.gameObject);

            currentItem = null;
        }
    }

    public void ReEnablePlayerMovement()
    {
        playerMoveBehaviour.canMove = true;
    }
}
