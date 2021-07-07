using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HPrefSystem 
{
    //HDifficulty
    public static string easyH = "easyH";
    public static string mediumH = "mediumH";
    public static string hardH = "hardH";

    //HScores
    public static string easyScoreH = "easyScoreH";
    public static string mediumScoreH = "mediumScoreH";
    public static string hardScoreH = "hardScoreH";

    //Set Get for Easy Diff
    public static void SetEasyHDiff(int easyH)
    {
        PlayerPrefs.SetInt(HPrefSystem.easyH, easyH);
    }

    public static int GetEasyHDiff()
    {
        return PlayerPrefs.GetInt(HPrefSystem.easyH);
    }
    //Set Get for Medium Diff
    public static void SetMediumHDiff(int mediumH)
    {
        PlayerPrefs.SetInt(HPrefSystem.mediumH, mediumH);
    }

    public static int GetMediumHDiff()
    {
        return PlayerPrefs.GetInt(HPrefSystem.mediumH);
    }
    //Set Get for Hard Diff
    public static void SetHardHDiff(int hardH)
    {
        PlayerPrefs.SetInt(HPrefSystem.hardH, hardH);
    }

    public static int GetHardHDiff()
    {
        return PlayerPrefs.GetInt(HPrefSystem.hardH);
    }

    //Checking whether any difficulty option has been chosen
    public static bool CheckDiffRecord()
    {
        if (PlayerPrefs.HasKey(HPrefSystem.easyH) || PlayerPrefs.HasKey(HPrefSystem.mediumH) || PlayerPrefs.HasKey(HPrefSystem.hardH))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Set Get for Easy Diff Score
    public static void SetEasyHScore(int easyScoreH)
    {
        PlayerPrefs.SetInt(HPrefSystem.easyScoreH, easyScoreH);
    }

    public static int GetEasyHScore()
    {
        return PlayerPrefs.GetInt(HPrefSystem.easyScoreH);
    }
    //Set Get for Medium Diff Score
    public static void SetMediumHScore(int mediumScoreH)
    {
        PlayerPrefs.SetInt(HPrefSystem.mediumScoreH, mediumScoreH);
    }

    public static int GetMediumHScore()
    {
        return PlayerPrefs.GetInt(HPrefSystem.mediumScoreH);
    }
    //Set Get for Hard Diff Score
    public static void SetHardHScore(int hardScoreH)
    {
        PlayerPrefs.SetInt(HPrefSystem.hardScoreH, hardScoreH);
    }

    public static int GetHardHScore()
    {
        return PlayerPrefs.GetInt(HPrefSystem.hardScoreH);
    }

}
