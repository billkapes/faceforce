using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public Light light;

    // create instance
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

    
    void Start()
    {
        //FadeIn();
        light.intensity = 25;

        light.DOIntensity(1, 1);

        TurnManager.Instance.currentTurn = TurnManager.TurnState.Player;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }   
    }

    private void FadeIn()
    {
        var color = Color.black;
        color.a = 1f;
        panel.GetComponent<Image>().color = color;

        panel.GetComponent<Image>().DOFade(0, 1);
    }

    public void FoundGoal()
    {
        light.DOIntensity(25, 1);
        //panel.GetComponent<Image>().DOFade(1, 1);
    }

    

    void EnterScene()
    {

    }

    void ExitScene()
    {

    }
}
