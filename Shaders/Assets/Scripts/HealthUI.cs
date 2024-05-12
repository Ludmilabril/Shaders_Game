using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HealthUI : MonoBehaviour
{
    public List<Image> HealthList;
    public GameObject PrefabHealth;
    
    public playersHealth health;

    public int ActualIndex;

    public Sprite FullHealth;
    public Sprite EmptyHealth;

    private void Awake()
    {
        health.ChangeHealth.AddListener(ChangeHealth);
    }

    private void ChangeHealth(int actualHealth)
    {
        if(!HealthList.Any())
        {
            GenerateHealth(actualHealth);

        }
        else
        {
            changeHealth(actualHealth);
        }
    }

    private void changeHealth(int actualHealth)
    {
        if (actualHealth <= ActualIndex)
        {
            removeHealth(actualHealth);

        }
        else
        {
            AddHealth(actualHealth);
        }
    
    }

    private void AddHealth(int actualHealth)
    {
        for (int i = ActualIndex; i < actualHealth; i++)
        {
            ActualIndex = i;
            HealthList[ActualIndex].sprite = FullHealth;
        }
    }

    private void removeHealth(int actualHealth)
    {
        for (int i = ActualIndex; i >= actualHealth; i--) 
        {
            ActualIndex = i;
            HealthList[ActualIndex].sprite = EmptyHealth;
        }
    }

    private void GenerateHealth(int actualMaxHealth)
    {
        for(int i = 0; i < actualMaxHealth; i++)
        {
            GameObject Health = Instantiate(PrefabHealth, transform);
            HealthList.Add(Health.GetComponent<Image>());
        }

        ActualIndex = actualMaxHealth - 1;
    }
}
