using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScript : MonoBehaviour
{
    public int Damage = 5;
    public string Type = "Fire";
    public List<GameObject> objectTouching;

   



    private void Update()
    {
       if(objectTouching != null)
        {
            applydamage();
        }
        
    }
    
        
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!objectTouching.Contains(collision.gameObject))
        {
            objectTouching.Add(collision.gameObject);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        objectTouching.Remove(collision.gameObject);
    }
    void applydamage()
    {
        foreach(GameObject collision in objectTouching) 
        {

            damageScript damageScript = collision.gameObject.GetComponent<damageScript>();
           if (damageScript != null)
            {
                damageScript.applyDamage(Damage * Time.deltaTime, Type);
            }
               
        }
    }
}
