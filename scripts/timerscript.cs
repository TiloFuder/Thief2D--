using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerscript : MonoBehaviour
{
    private float timer;
    public float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < lifespan)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
