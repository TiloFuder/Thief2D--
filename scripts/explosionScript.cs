using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class explosionScript : StimAndResponse
{
    [Range(0f, 50f)] public float explosionRadius;
    [Range(0f, 1000f)] public float explosionStrenght;
    public CircleCollider2D radius;
    public timerscript timer;
    public List<GameObject> objects;
    public int Damage = 50;
   

    // player is somehow not affected by explosion ???


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (radius.radius < explosionRadius)
        {
            radius.radius += explosionRadius / timer.lifespan * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!objects.Contains(collision.gameObject))
        {
            objects.Add(collision.gameObject);
            float distance = Vector3.Distance(gameObject.transform.position, collision.transform.position);
            Vector3 direction = collision.transform.position - gameObject.transform.position;
            Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
            if (body != null)
            {

                body.AddForce(direction * (1 / distance) * explosionStrenght * 100, ForceMode2D.Force);
                body.AddTorque((1 / distance) * explosionStrenght * 100);
                Debug.Log(collision.gameObject + "has been caught in explosion");

            }
            damageScript damageScript = collision.gameObject.GetComponent<damageScript>();
            if (damageScript != null)
            {
                damageScript.applyDamage(Damage, "Explosive");
            }
        }

       
        
        
    }
   
}
