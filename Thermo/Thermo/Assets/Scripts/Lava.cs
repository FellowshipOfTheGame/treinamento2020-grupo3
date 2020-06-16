using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
	//public PlayerMovement movement;
	
    void OnTriggerEnter2D(Collider2D collider)
	{
        //Debug.Log("O jogo deve finalizar_1");

		if (collider.tag == "Player")
		{
            //Debug.Log("O jogo deve finalizar_2");

			//movement.enabled = false;
			
			Debug.Log("GAME OVER");
			SceneManager.LoadScene("GameOver");

			//FindObjectOfType<GameManager>().EndGame();
		}
	}
}