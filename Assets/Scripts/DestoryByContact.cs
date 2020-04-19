using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{
    private GameController gameController;

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("Game Controller");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'Game Controller' Script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Pickup") || other.CompareTag("Boss") || other.gameObject.CompareTag("Enemy Shield"))
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.gameObject.CompareTag("Player Controller"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver ();
            gameController.DefeatMusic();
        }

        gameController.AddScore(scoreValue);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
