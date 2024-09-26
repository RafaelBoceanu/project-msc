using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public TMP_Text DialogText;
    public TMP_Text ObjectiveText;
    public GameObject ObjectivePointer;
    public GameObject DialogPanel;
    public GameObject ObjectivePanel;
    public GameObject KeyTrigger;
    public Animator DoorController;
    public bool hasKey = false;

    public StarterAssetsInputs starterAssetsInputs;

    bool nearDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnlocKDoor();
    }

    void UnlocKDoor()
    {
        if (nearDoor && hasKey && starterAssetsInputs.action)
        {
            DoorController.SetBool("isUnlocked", true);
            DialogPanel.SetActive(false);
            ObjectiveText.text = "Find Mary's tools\nMake sure you avoid the guard patrolling outside!";
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        KeyTrigger.SetActive(true);
        ObjectivePointer.SetActive(false);
        nearDoor = true;

        if (!hasKey)
        {
            DialogPanel.SetActive(true);
            DialogText.text = "Door locked!";
            ObjectiveText.text = "Find the rusty key to the abandoned house. \nIt should be in one of the sheds!";
        }
        else
        {
            DialogPanel.SetActive(true);
            DialogText.text = "Press \"E\" to unlock the door";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DialogPanel.SetActive(false);
        DialogText.text = "";
        nearDoor = false;
    }
}
