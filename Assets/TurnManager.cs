using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    PlayerMovement thePlayer;
    EnemyMovement theEnemy;

    public enum TurnState
    {
        Idle, Player, Waiting, Enemy
    }
    
    public TurnState currentTurn;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static TurnManager Instance { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Player").GetComponent<PlayerMovement>();
        theEnemy = GameObject.Find("enemy").GetComponent<EnemyMovement>();
        currentTurn = TurnState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentTurn)
        {
            case TurnState.Idle:
                
                break;
            case TurnState.Player:
                thePlayer.myTurn = true;
                currentTurn = TurnState.Waiting;
                break;
            case TurnState.Waiting:
                break;
            case TurnState.Enemy:
                theEnemy.myTurn = true;
                currentTurn = TurnState.Waiting;
                break;
            default:
                break;
        }
    }

    public void PlayerDone()
    {
        currentTurn = TurnState.Enemy;
    }

    public void EnemyDone()
    {
        currentTurn = TurnState.Player;
    }
}
