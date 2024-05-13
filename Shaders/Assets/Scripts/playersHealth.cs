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
    public GameObject Poti;

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
        if (collision.gameObject.tag == "Plant")
        {
            Damage(1);
        }
        if (collision.gameObject.tag == "Cristals")
        {
            Damage(1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "potion")
        {
            recoverHealth(1);
            Destroy(Poti);
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
