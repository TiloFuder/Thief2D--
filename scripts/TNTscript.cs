using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTscript : StimAndResponse
{
    public TNTscript() { }
    public GameObject explosion;
    private float timer;
    public float fuse;
    private bool isActive = false;
    public GameObject flame;
    private void Explode()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (isActive)
        {
            flame.SetActive(true);
            if (timer < fuse)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Explode();
            }
        }
        else
        {
            timer = 0;
            flame.SetActive (false);
        }
    }

    protected override void fireResponse()
    {
        isActive = true; 
    }
    protected override void waterResponse()
    {
        isActive = false;
    }
    protected override void explosionResponse()
    {
        isActive = true;
        timer = fuse / 5;
    }
}
