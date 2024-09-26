using JetBrains.Annotations;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectibles : MonoBehaviour
{
    public TMP_Text DialogText;
    public TMP_Text ObjectiveText;
    public GameObject DialogPanel;
    public GameObject ObjectivePanel;

    public GameManager gm;
    public StarterAssetsInputs starterAssetsInputs;
    public AudioSource pickUpSound;

    bool nearCollectible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PickUpCollectible();
    }

    void PickUpCollectible()
    {
        if (nearCollectible && starterAssetsInputs.action)
        {
            switch (this.tag.ToString())
            {
                case "Sickle":
                    gm.hasSickle = true;
                    DialogPanel.SetActive(false);
                    this.transform.parent.gameObject.SetActive(false);
                    pickUpSound.Play();
                    break;
                case "Saw":
                    gm.hasSaw = true;
                    DialogPanel.SetActive(false);
                    this.transform.parent.gameObject.SetActive(false);
                    pickUpSound.Play();
                    break;
                case "Wrench":
                    gm.hasWrench = true;
                    DialogPanel.SetActive(false);
                    this.transform.parent.gameObject.SetActive(false);
                    pickUpSound.Play();
                    break;
                case "Screwdriver":
                    gm.hasScrewdriver = true;
                    DialogPanel.SetActive(false);
                    this.transform.parent.gameObject.SetActive(false);
                    pickUpSound.Play();
                    break;
                case "Hammer":
                    gm.hasHammer = true;
                    DialogPanel.SetActive(false);
                    this.transform.parent.gameObject.SetActive(false);
                    pickUpSound.Play();
                    break;
            }
        }
    }

    void PickUpSickle()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogPanel.SetActive(true);
        DialogText.text = "Press \"E\" to pick up the " + this.tag.ToString().ToLower();
        nearCollectible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        DialogPanel.SetActive(false);
        DialogText.text = "";
        nearCollectible = false;
    }
}
