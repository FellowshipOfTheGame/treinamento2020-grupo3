using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
     

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private bool solido = true;

    public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmission;

    public ParticleSystem impactEffect;
    private bool wasOnGround;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        footEmission = footsteps.emission;
    }

    void FixedUpdate(){
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update(){

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if(Input.GetKey("x")||Input.GetKey("c")){
            
            solido = false;            
        }

        if(Input.GetKey("z")){
            
            solido = true;            
        }

        if(solido==true){

        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w")){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w") && isJumping == true){

            if(jumpTimeCounter >0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else{
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp("w"))
            {
            isJumping = false;
        }

        }

        //show footstep effect
        if(Input.GetAxisRaw("Horizontal")!=0 && isGrounded)
        {
            footEmission.rateOverTime = 35f;
        }else
        {
            footEmission.rateOverTime = 0f;
        }

        //show impact effect
        if(!wasOnGround && isGrounded)
        {
            impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = footsteps.transform.position;
            impactEffect.Play();
        }
        wasOnGround = isGrounded;


    }

}