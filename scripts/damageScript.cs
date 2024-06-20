using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    public float Health;
    public float MaxHealth;

    //damage type resistance
    public bool isUnkillable = false;
    public bool fireImmunity = false;
    public bool explosionImmunity = false;
    public bool isGhost= false;
    [Range(0f, 100f)] public int normalDamageResistance;

    private void Start()
    {
        Health = MaxHealth;
    }
    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void applyDamage(float damage, string type)
    {
        if (!isUnkillable)
        {
          if (type == "Fire" && !fireImmunity)
            {
                Health -= damage;
            }
          else if (type == "Explosive" && !explosionImmunity)
            {
                Health -= damage;
            }
          else if (type == null && !isGhost)
            {
                Health -= damage * ((100 - normalDamageResistance) / 100);
            }
        }
        
    }
    public void healDamage(float healing)
    {
        Health += healing;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
}
