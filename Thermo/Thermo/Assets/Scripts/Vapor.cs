using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vapor : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 movement;

    public bool gas = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if( Input.GetKey("z") )
		gas = false;
		
        if( Input.GetKey("x") )
		gas = false;
		
        if( Input.GetKey("c") )
		gas = true;
		
        

        if(gas == true)
        {
        movement = new Vector2(0,3);
        moveCharacter(movement);
        
        }     
        
    }

    void moveCharacter(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
}
