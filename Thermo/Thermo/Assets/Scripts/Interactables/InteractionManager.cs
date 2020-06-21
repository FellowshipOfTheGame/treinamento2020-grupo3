using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public bool isButton;
    public bool paraAgua;
    public bool paraSolido;
    public bool paraVapor;
    private MoveInteraction move;
    public GameObject state1;
    public GameObject state2;
    public GameObject interacted;

    void Start()
    {
        move = interacted.GetComponent <MoveInteraction>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name=="Água" && paraAgua || col.name == "Sólido" && paraSolido || col.name == "Vapor" && paraVapor)
                EnterInteraction();
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Água" && paraAgua || col.name == "Sólido" && paraSolido || col.name == "Vapor" && paraVapor)
            ExitInteraction();
    }

    void EnterInteraction()
    {
        if (isButton)
        {
            state1.SetActive(false);
            state2.SetActive(true);
        }

        if (move != null)
        {
            move.InteractIn();
        }
    }

    void ExitInteraction()
    {
        if (isButton)
        {
            state1.SetActive(true);
            state2.SetActive(false);
        }
    }
}
