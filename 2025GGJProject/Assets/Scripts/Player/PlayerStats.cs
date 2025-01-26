using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [SerializeField] int health;
    [SerializeField] int maxHealth = 8;
    [SerializeField] private int zPower;

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

    public int ZPower
    {
        get { return zPower; }
        private set
        {
            if (value < 0) { zPower = 0; }
            if (value > 100) { zPower = 100; }
        }
    }
    public int Health

    {
        get { return health; }

        private set 
        { 
            if (health < 0) { health = 0; }
            if (health > maxHealth) { health = maxHealth; }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        zPower = 0;
    }


    public void AddHealth(int bonusHealth)
    {
        health += bonusHealth;
        if (health > maxHealth) {health = maxHealth; }
    }

    public void SubtractHealth(int damage)
    {
        health -= damage;
        if (health < 0) { health = 0; }
        if (health <= 0) {gameObject.SetActive(false); }
    }


    public void AddZ(int value)
    {
        zPower += value;

        if (zPower < 0) {zPower = 0; }
        if (zPower > 100) {zPower = 100; }
    }

    public void ResetZ()
    {
        zPower = 0;
    }

}
