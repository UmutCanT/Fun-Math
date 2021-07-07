using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PmPrefSystem
{
    //PmDifficulty
    public static string easyPm = "easyPm";
    public static string mediumPm = "mediumPm";
    public static string hardPm = "hardPm";

    //PmScores
    public static string easyScorePm = "easyScorePm";
    public static string mediumScorePm = "mediumScorePm";
    public static string hardScorePm = "hardScorePm";

    //Set Get for Easy Diff
    public static void SetEasyPmDiff(int easyPm)
    {
        PlayerPrefs.SetInt(PmPrefSystem.easyPm, easyPm);
    }

    public static int GetEasyPmDiff()
    {
        return PlayerPrefs.GetInt(PmPrefSystem.easyPm);
    }
    //Set Get for Medium Diff
    public static void SetMediumPmDiff(int mediumPm)
    {
        PlayerPrefs.SetInt(PmPrefSystem.mediumPm, mediumPm);
    }

    public static int GetMediumPmDiff()
    {
        return PlayerPrefs.GetInt(PmPrefSystem.mediumPm);
    }
    //Set Get for Hard Diff
    public static void SetHardPmDiff(int hardPm)
    {
        PlayerPrefs.SetInt(PmPrefSystem.hardPm, hardPm);
    }

    public static int GetHardPmDiff()
    {
        return PlayerPrefs.GetInt(PmPrefSystem.hardPm);
    }

    //Checking whether any difficulty option has been chosen
    public static bool CheckDiffRecord()
    {
        if (PlayerPrefs.HasKey(PmPrefSystem.easyPm) || PlayerPrefs.HasKey(PmPrefSystem.mediumPm) || PlayerPrefs.HasKey(PmPrefSystem.hardPm))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Set Get for Easy Diff Score
    public static void SetEasyPmScore(int easyScorePm)
    {
        PlayerPrefs.SetInt(PmPrefSystem.easyScorePm, easyScorePm);
    }

    public static int GetEasyPmScore()
    {
        return PlayerPrefs.GetInt(PmPrefSystem.easyScorePm);
    }
    //Set Get for Medium Diff Score
    public static void SetMediumPmScore(int mediumScorePm)
    {
        PlayerPrefs.SetInt(PmPrefSystem.mediumScorePm, mediumScorePm);
    }

    public static int GetMediumPmScore()
    {
        return PlayerPrefs.GetInt(PmPrefSystem.mediumScorePm);
    }
    //Set Get for Hard Diff Score
    public static void SetHardPmScore(int hardScorePm)
    {
        PlayerPrefs.SetInt(PmPrefSystem.hardScorePm, hardScorePm);
    }

    public static int GetHardPmScore()
    {
        return PlayerPrefs.GetInt(PmPrefSystem.hardScorePm);
    }

}
