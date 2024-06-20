using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamearrow : StimAndResponse
{
    private bool isonfire = false;
    public GameObject Flame;
    public GameObject sparkle;
    public flamearrow() { }

    private void Update()
    {
        if (stims.Contains(Stimulant.Fire))
        {
            isonfire = true;
        }
        else if (!stims.Contains(Stimulant.Fire))
        {
            isonfire = false;
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
        if (!stims.Contains(Stimulant.Fire))
            stims.Add(Stimulant.Fire);
    }
    protected override void waterResponse()
    {
        stims.Remove(Stimulant.Fire);
    }
}
