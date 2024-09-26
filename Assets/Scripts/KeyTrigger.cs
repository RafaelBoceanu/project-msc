using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public TMP_Text DialogText;
    public TMP_Text ObjectiveText;
    public GameObject ObjectivePointer;
    public GameObject DialogPanel;
    public GameObject ObjectivePanel;
    public GameObject Key;
   
    public DoorTrigger doorTrigger;
    public StarterAssetsInputs starterAssetsInputs;
    public AudioSource pickUpSound;

    bool nearKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PickUpKey();
    }

    void PickUpKey()
    {
        if (nearKey && !doorTrigger.hasKey && starterAssetsInputs.action)
        {
            doorTrigger.hasKey = true;
            ObjectivePointer.SetActive(true);
            ObjectiveText.text = "Go back and unlock the door";
            DialogPanel.SetActive(false);
            DialogText.text = "";
            Key.SetActive(false);
            pickUpSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogPanel.SetActive(true);
        DialogText.text = "Press \"E\" to pick up the key";
        nearKey = true;
    }

    private void OnTriggerExit(Collider other)
    {
        DialogPanel.SetActive(false);
        DialogText.text = "";
        nearKey = false;
    }
}
