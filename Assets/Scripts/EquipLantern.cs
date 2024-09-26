using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EquipLantern : MonoBehaviour
{
    public TMP_Text DialogText;
    public GameObject DialogPanel;
    public GameObject lantern;

    StarterAssetsInputs starterAssetsInputs;
    [SerializeField] bool lanternEquipped = false;

    private void Awake()
    {
        starterAssetsInputs = this.GetComponent<StarterAssetsInputs>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            DialogPanel.SetActive(true);
            DialogText.text = "Press \"F\" to equip lantern";
        }
    }

    // Update is called once per frame
    void Update()
    {
        lanternEquipped = starterAssetsInputs.lantern;
    }

    void Equip()
    {
        if (lanternEquipped && starterAssetsInputs.lantern)
        {   
            lantern.SetActive(false);
            lanternEquipped = false;
            DialogPanel.SetActive(false);
            DialogText.text = "";
        }
        else
        {
            lantern.SetActive(true);
            lanternEquipped = true;
            DialogPanel.SetActive(false);
            DialogText.text = "";      
        }
    }
}
