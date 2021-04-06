using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject essencePrefab = default;

    List<GameObject> essences = new List<GameObject>();

    Countdown countdown;

    Vector2 essencePosition;

    // Start is called before the first frame update
    void Start()
    {
        countdown = gameObject.AddComponent<Countdown>();
        countdown.TotalTime = 5;
        countdown.RunCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.Finished)
        {
            SpawnEssence();
            countdown.RunCountdown();
        }
    }

    /// <summary>
    /// Spawning set of essences 
    /// </summary>
    void SpawnEssence()
    {
        essencePosition = new Vector2(-3 * ScreenSizeManager.instance.Witdh / 4, ScreenSizeManager.instance.Height);
        for (int i = 0; i < 4; i++)
        {
            GameObject essence = Instantiate(essencePrefab, essencePosition, Quaternion.identity);
            essences.Add(essence);
            essence.GetComponent<Essence>().Falling = true;
            EssencePositions(i);
        }
    }

    /// <summary>
    /// Changing essence horizontal position 
    /// </summary>
    /// <param name="horizontal"></param>
    void EssencePositions(int horizontal)
    {
        switch (horizontal)
        {
            case 0:
                essencePosition.x = -ScreenSizeManager.instance.Witdh / 4;
                break;
            case 1:
                essencePosition.x = ScreenSizeManager.instance.Witdh / 4;
                break;
            case 2:
                essencePosition.x = 3 * ScreenSizeManager.instance.Witdh / 4;
                break;
            case 3:
                essencePosition.x = -3 * ScreenSizeManager.instance.Witdh / 4;
                break;
            default:
                break;
        }
    }
}
