using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardenedScript : MonoBehaviour
{
    #region Singleton
    public static HardenedScript instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Sahnede fazladan HardScript olamaz.");
        }
    }
    #endregion
    public float HardenedLevel(float baseValue, float easyValue, float normalValue, float hardValue)
    {
        if (PlayerPrefs.HasKey("Easy Mode"))
        {
            baseValue = easyValue;
        }
        else if (PlayerPrefs.HasKey("Normal Mode"))
        {
            baseValue = normalValue;
        }
        else if (PlayerPrefs.HasKey("Hard Mode"))
        {
            baseValue = hardValue;
        }
        return baseValue;
    }
}
