using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


//TODO:
// 1 - detect click
// 2 - place a marker on the click coordinates
// 3 - track mouse movement
// 4 - draw a line for trajectory
// 5 - detect click release & place another marker
// 6 - calculate direction of the Vector between both clicks
// 7 - instantiate arrow from player position 








public class BowScript : MonoBehaviour
{
    // track mouse position
    private Vector3 mousePos;
    public Vector3 mousePos1;
    private Vector3 clickPos;
   
  

    // draws line
    public GameObject player;
    public LineRenderer Tracer;
    public Vector3 playerPos;
    private Vector3 test;
    public Vector3 test1;
    public Vector3 test2;
    public Vector3 test3;

    public GameObject arrow;
    public float rotation;
    public float rotation1;


   

    void Update()
    {
       mousePos = Input.mousePosition;
       playerPos = player.gameObject.transform.position;
       mousePos1 = Camera.main.ScreenToWorldPoint(mousePos);
       test = Camera.main.ScreenToWorldPoint(clickPos);
        test1 = mousePos1 - test;
        test2 = playerPos - test1;
        test3 = mousePos - clickPos;
        
        

        if (Input.GetMouseButton(1))
        {
            Tracer.gameObject.SetActive(true);
        }
        else
        {
            Tracer.gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            clickPos = mousePos;
        }
       if(Input.GetMouseButtonUp(1))
        {

            rotation = Vector3.Angle(Vector3.down, test1);
            Debug.Log(rotation1);
            Debug.Log(test2);
            if(test3.x > 0)
            {
                rotation1 =  rotation;
            }
            else
            {
                rotation1 = -1 * rotation;
            }
            Instantiate(arrow, transform.position, transform.rotation);
        }

        Vector3[] positions = new Vector3[2];
        positions[0] = playerPos;
        positions[1] = test2;
        Tracer.positionCount = positions.Length;
        Tracer.SetPositions(positions);
    }
}
