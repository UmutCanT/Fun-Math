using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefSystem
{
    //ECDifficulty
    public static string easy = "easy";
    public static string medium = "medium";
    public static string hard = "hard";

    //ECScores
    public static string easyScoreEc = "easyScoreEc";
    public static string mediumScoreEc = "mediumScoreEc";
    public static string hardScoreEc = "hardScoreEc";

    //Set Get for Easy Diff
    public static void SetEasyDiff(int easy)
    {
        PlayerPrefs.SetInt(PrefSystem.easy, easy);
    }

    public static int GetEasyDiff()
    {
        return PlayerPrefs.GetInt(PrefSystem.easy);
    }
    //Set Get for Medium Diff
    public static void SetMediumDiff(int medium)
    {
        PlayerPrefs.SetInt(PrefSystem.medium, medium);
    }

    public static int GetMediumDiff()
    {
        return PlayerPrefs.GetInt(PrefSystem.medium);
    }
    //Set Get for Hard Diff
    public static void SetHardDiff(int hard)
    {
        PlayerPrefs.SetInt(PrefSystem.hard, hard);
    }

    public static int GetHardDiff()
    {
        return PlayerPrefs.GetInt(PrefSystem.hard);
    }

    //Checking whether any difficulty option has been chosen
    public static bool CheckDiffRecord()
    {
        if(PlayerPrefs.HasKey(PrefSystem.easy) || PlayerPrefs.HasKey(PrefSystem.medium) || PlayerPrefs.HasKey(PrefSystem.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Set Get for Easy Diff Score
    public static void SetEasyScore(int easyScore)
    {
        PlayerPrefs.SetInt(PrefSystem.easyScoreEc, easyScore);
    }

    public static int GetEasyScore()
    {
        return PlayerPrefs.GetInt(PrefSystem.easyScoreEc);
    }
    //Set Get for Medium Diff Score
    public static void SetMediumScore(int mediumScore)
    {
        PlayerPrefs.SetInt(PrefSystem.mediumScoreEc, mediumScore);
    }

    public static int GetMediumScore()
    {
        return PlayerPrefs.GetInt(PrefSystem.mediumScoreEc);
    }
    //Set Get for Hard Diff Score
    public static void SetHardScore(int hardScore)
    {
        PlayerPrefs.SetInt(PrefSystem.hardScoreEc, hardScore);
    }

    public static int GetHardScore()
    {
        return PlayerPrefs.GetInt(PrefSystem.hardScoreEc);
    }

    //Music Prefs

}
