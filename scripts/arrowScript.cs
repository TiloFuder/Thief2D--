using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public BowScript Bow;
    public Rigidbody2D body;
    public float speed;
    private float timer;
    public float lifespan;

    void Start()
    {
        Bow = GameObject.FindWithTag("Player").GetComponent<BowScript>();
        transform.eulerAngles = new Vector3(0, 0, Bow.rotation1);
       body.AddForce(-1 * Bow.test3 * speed);
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
