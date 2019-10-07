using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public GameObject panel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        var color = Color.black;
        color.a = 1f;
        panel.GetComponent<Image>().color = color;

        panel.GetComponent<Image>().DOFade(0, 1);
        TurnManager.Instance.currentTurn = TurnManager.TurnState.Player;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }   
    }

    public void FoundGoal()
    {
        panel.GetComponent<Image>().DOFade(1, 1);
    }

    

    void EnterScene()
    {

    }

    void ExitScene()
    {

    }
}
