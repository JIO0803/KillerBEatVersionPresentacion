using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reviveHamster : MonoBehaviour
{
    public void ResetCounter()
    {
        PlayerPrefs.DeleteKey("LifeCounter");

        HamsterInteraction.lifeCounter = 5;
    }
}
