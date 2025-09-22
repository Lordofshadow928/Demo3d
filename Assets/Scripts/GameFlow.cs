using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public void OnPlayerDied()
    {
        Time.timeScale = 0f;
        Debug.Log("Player Died! Game Over!");
    }
}
