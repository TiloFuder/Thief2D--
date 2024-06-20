using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thiefScript : MonoBehaviour
{
    public float moveSpeed;
    public logicScript Logic;
    public Rigidbody2D myBody;

    // detects input
    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveLeft = false;
    private bool moveRight = false;

    // all 4 directional vectors
    private Vector2 moveDirUp;
    private Vector2 movedirdown;
    private Vector2 moveDirleft;
    private Vector2 moveDirRight;
   
    // all sprites for the thief
    public Sprite thiefUp;
    public Sprite thiefDown;
    public Sprite thiefLeft;
    public Sprite thiefRight;

    public SpriteRenderer thiefSprite;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       //moveUp
       if (Input.GetKey(KeyCode.W))
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
        }


        //moveDown
        if (Input.GetKey(KeyCode.S))
        {
            
            moveDown = true;
        }
        else
        {
            moveDown = false;
        }

        //moveLeft
        if (Input.GetKey(KeyCode.A))
        {
            
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        //moveRight

        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }
    }

    private void FixedUpdate()
    {
        //this line defines characterspeed
        if (moveUp || moveDown || moveLeft || moveRight)
        {
            myBody.velocity = (moveDirUp + movedirdown + moveDirleft + moveDirRight) * moveSpeed;
        }
        
        
        
        if (moveUp == true)
        {
            moveDirUp = Vector2.up;
            thiefSprite.sprite = thiefUp;
        }
        else
        {
            moveDirUp = Vector2.zero;
        }
        if (moveDown == true)
        {
            movedirdown = Vector2.down;
            thiefSprite.sprite = thiefDown;
        }
        else
        {
            movedirdown = Vector2.zero;
        }
        if (moveLeft == true)
        {
            moveDirleft = Vector2.left;
            thiefSprite.sprite = thiefLeft;
        }
        else
        {
            moveDirleft = Vector2.zero;
        }
        if(moveRight == true)
        {
            moveDirRight = Vector2.right;
            thiefSprite.sprite = thiefRight;
        }
        else
        {
            moveDirRight= Vector2.zero;
        }
    }
}
