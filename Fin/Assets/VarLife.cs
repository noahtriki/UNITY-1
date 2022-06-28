using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VarLife : MonoBehaviour
{

    public float soif = 100f;
    private float maxSoif = 100f;
    public float faim = 100f;
    private float maxFaim = 100f;
    public float vie = 100f;
    private float maxVie = 100f;

    public Image imageBarVie;
    public Image imageBarFaim;
    public Image imageBarSoif;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private MoveBehaviour playerMoveBehaviour;

    [SerializeField]
    private GameObject RespawnText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Respawn();

        if (vie > 0)
        {
            playerAnimator.SetTrigger("Respawn");
            playerMoveBehaviour.canMove = true;
            playerMoveBehaviour.isDead = false;
            Debug.Log("Je vie");
            Baissevie();
        }

        if (vie <= 0)
        {
            playerAnimator.SetTrigger("Death");
            playerMoveBehaviour.canMove = false;
            playerMoveBehaviour.isDead = true;
            Debug.Log("Je suis mort");
        }

        imageBarVie.fillAmount = vie / maxVie;
        imageBarFaim.fillAmount = faim / maxFaim; ;
        imageBarSoif.fillAmount = soif / maxSoif;

        #region verif
        if (faim > 0)
        {
            BaisseFaim();
        }
        else
            faim = 0f;

        if (soif > 100)
            soif = 100f;

        if (faim > 100)
            faim = 100f;


        if (soif > 0)
        {
            BaisseSoif();
        }
        else
            soif = 0f;
        #endregion

    }

    private void BaisseFaim()
    {
        faim -= 0.05f;
         new WaitForSeconds(1);
    }

    private void BaisseSoif()
    {
        soif -= 0.05f;
        new WaitForSeconds(1);
    }

    private void Baissevie()
    {
        if (faim <= 0 || soif <= 0)
        {
            vie -= 0.005f;
            new WaitForSeconds(1);
        }
    }

    private void Respawn()
    {
        if (playerMoveBehaviour.isDead)
        {
            RespawnText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerMoveBehaviour.transform.position = new Vector3(725, 9, 865);
                RespawnText.SetActive(false);
                vie = 50f;
                faim = 100f;
                soif = 100f;
            }
        }
        else
        {
            RespawnText.SetActive(false);
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            soif += 2f;
        }
    }*/
}