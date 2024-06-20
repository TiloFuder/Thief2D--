using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodCrateScript : StimAndResponse
{
  
    public GameObject Flame;
    private bool isonfire = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public woodCrateScript() { }
   

    // Update is called once per frame
    void Update()
    {
        if (stims.Contains(Stimulant.Fire))
        {
            isonfire = true;
        }
        else if (!stims.Contains(Stimulant.Fire))
        {
            isonfire= false;
        }
        
        if (isonfire)
        {

            Flame.SetActive(true);
            
        }
        else 
        {
            Flame.SetActive(false);
        }

        
    }

    override protected void fireResponse()
    {
        if(!stims.Contains(Stimulant.Fire))
        stims.Add(Stimulant.Fire);
    }
    protected override void waterResponse()
    {
        stims.Remove(Stimulant.Fire);
    }
}
