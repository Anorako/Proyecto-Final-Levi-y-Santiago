using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerMoveForce playerMoveForce;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveForce = GameObject.Find("Player").GetComponent<PlayerMoveForce>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMoveForce.gameOver == true)
        {
            
        }
    }
}
