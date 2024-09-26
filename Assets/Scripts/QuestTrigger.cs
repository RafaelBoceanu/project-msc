using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestTrigger : MonoBehaviour
{
    public TMP_Text DialogText;
    public TMP_Text ObjectiveText;
    public GameObject QuestCamera;
    public GameObject PlayerCamera;
    public GameObject Player;
    public GameObject ObjectivePointer;
    public GameObject DialogPanel;
    public GameObject ObjectivePanel;
    public GameObject DoorTrigger;
    public Animator NPCController;

    public StarterAssetsInputs starterAssetsInputs;

    bool nearQuest;

    // Update is called once per frame
    void Update()
    {
        QuestStart();
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogPanel.SetActive(true);
        DialogText.text = "Press \"E\" to talk to Mary";
        nearQuest = true;
    }

    private void OnTriggerExit(Collider other)
    {
        DialogPanel.SetActive(false);
        DialogText.text = "";
        nearQuest = false;
    }

    void QuestStart()
    {
        if (nearQuest && starterAssetsInputs.action)
        {
            StartCoroutine(QuestInstructions());
        }
    }

    IEnumerator QuestInstructions()
    {
        Player.SetActive(false);
        PlayerCamera.SetActive(false);
        ObjectivePanel.SetActive(false);
        DialogText.text = "";
        QuestCamera.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        NPCController.SetBool("isTalking", true);
        DialogText.text = "I need your help! I have lost my tools in the abandoned house in the village. Can you please retrieve them for me?";
        yield return new WaitForSeconds(5);
        NPCController.SetBool("isTalking", false);
        DialogText.text = "";
        DialogPanel.SetActive(false);
        ObjectivePanel.SetActive(true);
        ObjectiveText.text = "Go to the abandoned house in the village";
        ObjectivePointer.SetActive(true);
        Player.SetActive(true);
        PlayerCamera.SetActive(true);
        DoorTrigger.SetActive(true);
        QuestCamera.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
