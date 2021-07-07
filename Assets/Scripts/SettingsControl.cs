using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsControl : MonoBehaviour
{
    // EC Buttons
    [SerializeField]
    Button easyButtonEc;
    [SerializeField]
    Button mediumButtonEc;
    [SerializeField]
    Button hardButtonEc;

    //PM Buttons
    [SerializeField]
    Button easyButtonPm;
    [SerializeField]
    Button mediumButtonPm;
    [SerializeField]
    Button hardButtonPm;

    //H Buttons
    [SerializeField]
    Button easyButtonH;
    [SerializeField]
    Button mediumButtonH;
    [SerializeField]
    Button hardButtonH;

    // Start is called before the first frame update
    void Start()
    {
        //Checking whether difficulty registered or not for EC
        if (PrefSystem.GetEasyDiff() == 1)
        {
            easyButtonEc.interactable = false;
            mediumButtonEc.interactable = true;
            hardButtonEc.interactable = true;
        }
        if (PrefSystem.GetMediumDiff() == 1)
        {
            easyButtonEc.interactable = true;
            mediumButtonEc.interactable = false;
            hardButtonEc.interactable = true;
        }
        if (PrefSystem.GetHardDiff() == 1)
        {
            easyButtonEc.interactable = true;
            mediumButtonEc.interactable = true;
            hardButtonEc.interactable = false;
        }

        //Checking whether difficulty registered or not for PM
        if (PmPrefSystem.GetEasyPmDiff() == 1)
        {
            easyButtonPm.interactable = false;
            mediumButtonPm.interactable = true;
            hardButtonPm.interactable = true;
        }
        if (PmPrefSystem.GetMediumPmDiff() == 1)
        {
            easyButtonPm.interactable = true;
            mediumButtonPm.interactable = false;
            hardButtonPm.interactable = true;
        }
        if (PmPrefSystem.GetHardPmDiff() == 1)
        {
            easyButtonPm.interactable = true;
            mediumButtonPm.interactable = true;
            hardButtonPm.interactable = false;
        }

        //Checking whether difficulty registered or not for H
        if (HPrefSystem.GetEasyHDiff() == 1)
        {
            easyButtonH.interactable = false;
            mediumButtonH.interactable = true;
            hardButtonH.interactable = true;
        }
        if (HPrefSystem.GetMediumHDiff() == 1)
        {
            easyButtonH.interactable = true;
            mediumButtonH.interactable = false;
            hardButtonH.interactable = true;
        }
        if (HPrefSystem.GetHardHDiff() == 1)
        {
            easyButtonH.interactable = true;
            mediumButtonH.interactable = true;
            hardButtonH.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ECDifficulty(string level)
    {
        switch (level)
        {
            case "easy":
                PrefSystem.SetEasyDiff(1);
                PrefSystem.SetMediumDiff(0);
                PrefSystem.SetHardDiff(0);
                easyButtonEc.interactable = false;
                mediumButtonEc.interactable = true;
                hardButtonEc.interactable = true;
                break;
            case "medium":
                PrefSystem.SetEasyDiff(0);
                PrefSystem.SetMediumDiff(1);
                PrefSystem.SetHardDiff(0);
                easyButtonEc.interactable = true;
                mediumButtonEc.interactable = false;
                hardButtonEc.interactable = true;
                break;
            case "hard":
                PrefSystem.SetEasyDiff(0);
                PrefSystem.SetMediumDiff(0);
                PrefSystem.SetHardDiff(1);
                easyButtonEc.interactable = true;
                mediumButtonEc.interactable = true;
                hardButtonEc.interactable = false;
                break;
            default:
                break;
        }
    }

    public void PmDifficulty(string level)
    {
        switch (level)
        {
            case "easyPm":
                PmPrefSystem.SetEasyPmDiff(1);
                PmPrefSystem.SetMediumPmDiff(0);
                PmPrefSystem.SetHardPmDiff(0);
                easyButtonPm.interactable = false;
                mediumButtonPm.interactable = true;
                hardButtonPm.interactable = true;
                break;
            case "mediumPm":
                PmPrefSystem.SetEasyPmDiff(0);
                PmPrefSystem.SetMediumPmDiff(1);
                PmPrefSystem.SetHardPmDiff(0);
                easyButtonPm.interactable = true;
                mediumButtonPm.interactable = false;
                hardButtonPm.interactable = true;
                break;
            case "hardPm":
                PmPrefSystem.SetEasyPmDiff(0);
                PmPrefSystem.SetMediumPmDiff(0);
                PmPrefSystem.SetHardPmDiff(1);
                easyButtonPm.interactable = true;
                mediumButtonPm.interactable = true;
                hardButtonPm.interactable = false;
                break;
            default:
                break;
        }
    }

    public void HDifficulty(string level)
    {
        switch (level)
        {
            case "easyH":
                HPrefSystem.SetEasyHDiff(1);
                HPrefSystem.SetMediumHDiff(0);
                HPrefSystem.SetHardHDiff(0);
                easyButtonH.interactable = false;
                mediumButtonH.interactable = true;
                hardButtonH.interactable = true;
                break;
            case "mediumH":
                HPrefSystem.SetEasyHDiff(0);
                HPrefSystem.SetMediumHDiff(1);
                HPrefSystem.SetHardHDiff(0);
                easyButtonH.interactable = true;
                mediumButtonH.interactable = false;
                hardButtonH.interactable = true;
                break;
            case "hardH":
                HPrefSystem.SetEasyHDiff(0);
                HPrefSystem.SetMediumHDiff(0);
                HPrefSystem.SetHardHDiff(1);
                easyButtonH.interactable = true;
                mediumButtonH.interactable = true;
                hardButtonH.interactable = false;
                break;
            default:
                break;
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
