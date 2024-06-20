using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stimulant
{
    Fire,
    water,
    explosive
  
};
public class StimAndResponse : MonoBehaviour
{
    public List<Stimulant> stims;
    public Dictionary<Stimulant, Action> globalStims;
    public List<GameObject> objectsTouching;

     public StimAndResponse()
    {
        globalStims = new Dictionary<Stimulant, Action>
        {
            { Stimulant.Fire, fireResponse },
            { Stimulant.water, waterResponse },
            {Stimulant.explosive, explosionResponse },
             
        };
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!objectsTouching.Contains(other.gameObject))
        {
            objectsTouching.Add(other.gameObject);
        }
        ApplyStims(other.gameObject);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        objectsTouching.Remove(other.gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!objectsTouching.Contains(other.gameObject))
        {
            objectsTouching.Add(other.gameObject);
        }
        ApplyStims(other.gameObject);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        objectsTouching.Remove(other.gameObject);
    }
    public void ApplyStims(GameObject other) 
    { 
        StimAndResponse STR = other.gameObject.GetComponent<StimAndResponse>();
        if (STR != null)
        {
            foreach (Stimulant stim in STR.stims)
            {
                if (globalStims.ContainsKey(stim)) 
                {
                    globalStims[stim]();
                }
                
            }
        }
    }
    virtual protected void fireResponse() { }
    virtual protected void waterResponse () { }
    virtual protected void explosionResponse() { }
   
}
