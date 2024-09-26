using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public TMP_Text DialogText;
    public GameObject DialogPanel;
    public GameObject EndPanel;
    public GameObject QuestCamera;
    public GameObject PlayerCamera;
    public GameObject Player;
    public GameObject AmbianceSound;
    public GameObject Rain;
    public Animator NPCController;

    public StarterAssetsInputs starterAssetsInputs;

    bool nearNPC;

    // Update is called once per frame
    void Update()
    {
        ToolsHandover();
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogPanel.SetActive(true);
        DialogText.text = "Press \"E\" to hand over the tools";
        nearNPC = true;
    }

    void ToolsHandover()
    {
        if (nearNPC && starterAssetsInputs.action)
        {
            StartCoroutine(LevelFinished());
        }
    }

    IEnumerator LevelFinished()
    {
        Player.SetActive(false);
        PlayerCamera.SetActive(false);
        DialogText.text = "";
        QuestCamera.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        NPCController.SetBool("isTalking", true);
        DialogText.text = "Thank you very much for your help!";
        yield return new WaitForSeconds(3);
        NPCController.SetBool("isTalking", false);
        DialogText.text = "";
        DialogPanel.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        AmbianceSound.SetActive(false);
        Rain.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EndPanel.SetActive(true);
    }
}
