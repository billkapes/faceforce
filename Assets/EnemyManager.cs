using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyMovement[] theEnemies;

    

    // Start is called before the first frame update
    void Start()
    {
        theEnemies = GameObject.FindObjectsOfType<EnemyMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveEnemies()
    {
        foreach (var enemy in theEnemies)
        {
            enemy.myTurn = true;
            
        }

        TurnManager.Instance.currentTurn = TurnManager.TurnState.Player;
    }

    
}
