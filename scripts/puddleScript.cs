using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    public List<GameObject> objectTouching;
    public logicScript Logic;
    [Range(0f, 100f)] public float SlipFactor;

    private void Start()
    {
        Logic = GameObject.FindWithTag("Logic").GetComponent<logicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!objectTouching.Contains(collision.gameObject))
        {
            objectTouching.Add(collision.gameObject);
        }

        Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            if(!Logic.defaultdrags.ContainsKey(collision.gameObject))
            {
                Logic.defaultdrags.Add(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>().drag);
            }
            
        }
       
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach (GameObject obj in objectTouching)
        {
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().drag = Logic.defaultdrags[obj] / (SlipFactor);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject obj in objectTouching)
        {
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().drag = Logic.defaultdrags[obj];
                objectTouching.Remove(collision.gameObject);
            }
        }
    }

}
