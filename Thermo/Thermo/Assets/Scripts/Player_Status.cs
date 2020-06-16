using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{

    public GameObject solido;
    public GameObject liquido;
    public GameObject vapor;

    public bool gas = false;
    
    void Update()
    {
        if( Input.GetKey("z") )
		{
			
            solido.SetActive(true);
            vapor.SetActive(false);
            liquido.SetActive(false);

            gas = false;
		}

        if( Input.GetKey("x") )
		{
			
            solido.SetActive(false);
            liquido.SetActive(true);
            vapor.SetActive(false);

            gas = false;
		}

        if( Input.GetKey("c") )
		{
			        
            solido.SetActive(false);
            liquido.SetActive(false);
            vapor.SetActive(true);

            gas = true;
		}
    }
}
