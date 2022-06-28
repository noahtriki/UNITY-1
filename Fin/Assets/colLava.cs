using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colLava : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private VarLife playerLife;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife.vie -= 1;
        }
    }
}