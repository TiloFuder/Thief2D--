using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interractionscript : MonoBehaviour
{
   
  
    public List<GameObject> clickableObjects;

    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.layer == 6)
        {
            clickableObjects.Add(collision.gameObject);
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown (0) )
        {

            Activate();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        clickableObjects.Remove(collision.gameObject);
    }
    virtual protected void Activate() { }
}
