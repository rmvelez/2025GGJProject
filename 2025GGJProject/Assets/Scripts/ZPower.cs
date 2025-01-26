using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ZPowerManager : MonoBehaviour
{
    public static ZPowerManager instance;

    [SerializeField] private int zPower;
    public int ZPower
    {
        get { return zPower; }
        private set 
        {
            if (value < 0) { zPower = 0;}
            if (value > 100) { zPower = 100; }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null && instance != this)
        {
            Destroy(instance);
        }
    }


    public void AddZPower(int value)
    {
        zPower += value;
    }

    public void ResetZPower()
    {
        zPower = 0;
    }
}
