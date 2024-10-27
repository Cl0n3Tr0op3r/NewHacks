using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool hasWon; // Set this variable to true when the player wins

    public void CheckEndGame()
    {
        if (hasWon)
        {
            SceneManager.LoadScene("Winner");
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

