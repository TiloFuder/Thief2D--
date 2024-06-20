using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilScript : StimAndResponse
{
    public GameObject Flame;
    private bool isonfire = false;
    public OilScript() { }
    
    // Start is called before the first frame update
    void Start()
    {
        if (stims.Contains(Stimulant.Fire))
        {
            isonfire = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        if (!stims.Contains(Stimulant.Fire)) 
        {
            stims.Add(Stimulant.Fire);
            isonfire = true;
        }
    }
    protected override void waterResponse()
    {
        isonfire = false;
        stims.Remove(Stimulant.Fire);
    }
}
