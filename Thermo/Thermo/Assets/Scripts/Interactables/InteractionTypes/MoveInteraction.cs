using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInteraction : MonoBehaviour
{
    public Rigidbody2D rgBody;
    public int UnitsToMoveX;
    public int UnitsToMoveY;
    private float speedX;
    private float speedY;
    public float speed;
    public bool returnMove;
    private Vector2 VectorSpeed;
    private Vector2 _startPos;
    private Vector2 _endPos;

    public bool isGoing;
    public bool isComing;


    // Start is called before the first frame update
    void Start()
    {
        speedX = 0;
        speedY = 0;
        if (UnitsToMoveX != 0)
            speedX = speed;
        if (UnitsToMoveY != 0)
            speedY = speed;


        _startPos = transform.position;
        _endPos = new Vector2(transform.position.x + UnitsToMoveX, transform.position.y + UnitsToMoveY);
        VectorSpeed = new Vector2(speedX, speedY);

    }

    // Update is called once per frame
    void Update()
    {
        if (isGoing)
        {
            if (rgBody.position.x <= _endPos.x && rgBody.position.y <= _endPos.y)
            {
                rgBody.MovePosition(rgBody.position + VectorSpeed * Time.fixedDeltaTime);
            }
            else
            {
                isGoing = false;
                if(returnMove)
                isComing = true;
            }
        }
        if (isComing)
        {
            if (rgBody.position.x >= _startPos.x && rgBody.position.y >= _startPos.y)
            {
                rgBody.MovePosition(rgBody.position - VectorSpeed * Time.fixedDeltaTime);
            }
            else
                isComing = false;
        }
    }

    public void InteractIn()
    {
        if (!isComing && !isGoing)
        {
            isGoing = true;
        }
    }
}
