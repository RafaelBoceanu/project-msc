using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BucketTrigger : MonoBehaviour
{
    public TMP_Text DialogText;
    public TMP_Text ObjectiveText;
    public GameObject DialogPanel;
    public GameObject ObjectivePanel;
    public GameObject Sickle;
    public GameObject Saw;
    public GameObject Wrench;
    public GameObject Screwdriver;
    public GameObject Hammer;
    public GameObject PlayerBucket;
    public GameObject NPCTrigger;

    public GameManager gm;
    public StarterAssetsInputs starterAssetsInputs;
    public AudioSource pickUpSound;

    bool nearBucket;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlaceTool();
        PickUpBucket();
    }

    void PlaceTool()
    {
        if (nearBucket && starterAssetsInputs.action)
        {
            if (gm.hasSickle)
            {
                Sickle.SetActive(true);
                gm.hasSickle = false;
                counter++;
                if (counter == 5)
                {
                    DialogText.text = "Press \"E\" to pick up bucket";
                }
                else
                {
                    DialogText.text = "No tools collected";
                }
            }
            if (gm.hasSaw)
            {
                Saw.SetActive(true);
                gm.hasSaw = false;
                counter++;
                if (counter == 5)
                {
                    DialogText.text = "Press \"E\" to pick up bucket";
                }
                else
                {
                    DialogText.text = "No tools collected";
                }
            }
            if (gm.hasWrench)
            {
                Wrench.SetActive(true);
                gm.hasWrench = false;
                counter++;
                if (counter == 5)
                {
                    DialogText.text = "Press \"E\" to pick up bucket";
                }
                else
                {
                    DialogText.text = "No tools collected";
                }
            }
            if (gm.hasScrewdriver)
            {
                Screwdriver.SetActive(true);
                gm.hasScrewdriver = false;
                counter++;
                if (counter == 5)
                {
                    DialogText.text = "Press \"E\" to pick up bucket";
                }
                else
                {
                    DialogText.text = "No tools collected";
                }
            }
            if (gm.hasHammer)
            {
                Hammer.SetActive(true);
                gm.hasHammer = false;
                counter++;
                if (counter == 5)
                {
                    DialogText.text = "Press \"E\" to pick up bucket";
                }
                else
                {
                    DialogText.text = "No tools collected";
                }
            }
        }
    }

    void PickUpBucket()
    {
        if (nearBucket && counter == 5 && starterAssetsInputs.action)
        {
            StartCoroutine(BucketPickedUp());
            pickUpSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogPanel.SetActive(true);
        nearBucket = true;

        if (gm.hasSickle || gm.hasSaw || gm.hasScrewdriver || gm.hasWrench || gm.hasHammer)
        {
            DialogText.text = "Press \"E\" to place tools";
        }
        else if (counter == 5)
        {
            DialogText.text = "Press \"E\" to pick up bucket";
        }
        else
        {
            DialogText.text = "No tools collected";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DialogPanel.SetActive(false);
        DialogText.text = "";
        nearBucket = false;
    }

    IEnumerator BucketPickedUp()
    {
        NPCTrigger.SetActive(true);
        DialogPanel.SetActive(false);
        yield return new WaitForSeconds(2);
        this.transform.parent.gameObject.SetActive(false);
        PlayerBucket.SetActive(true);
        ObjectiveText.text = "Deliver the tools to Mary";
    }
}
