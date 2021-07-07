using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PmPlayerController : MonoBehaviour
{
    public void PotionChooser(int ID)
    {
        PmController.instance.OnSelectingPotion(ID);
    }
}
