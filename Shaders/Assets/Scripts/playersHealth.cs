using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class playersHealth : MonoBehaviour
{
    public int ActualHealth;
    public int MaxHealth;
    public UnityEvent<int> ChangeHealth;

    void Start()
    {
        ActualHealth = MaxHealth;
        ChangeHealth.Invoke(ActualHealth);
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Lava")
        {
            Damage(1);
        }
    }
    void Damage(int AmountDamage)
    {
        int TempHealth = ActualHealth - AmountDamage;

        if (TempHealth < 0)
        {
            ActualHealth = 0;
        }
        else
        {
            ActualHealth = TempHealth;
        }

        ChangeHealth.Invoke(ActualHealth);

        if (ActualHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    void recoverHealth(int AmountHealth)
    {
        int TempHealth = ActualHealth + AmountHealth;

        if (TempHealth >MaxHealth) 
        { 
            ActualHealth = MaxHealth;
        }
        else
        {
            ActualHealth = TempHealth;
        }
        ChangeHealth.Invoke(ActualHealth);
    }

}
