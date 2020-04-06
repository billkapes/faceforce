using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public Light mainLight, greenLight;

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

        greenLight.intensity = 1;
        greenLight.DOIntensity(0, 1);
        panel.GetComponent<Image>().DOColor(new Color(1f, 0f, 0f, 1f), 2).From();

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
        mainLight.intensity = 0;
        greenLight.DOIntensity(25, 1).OnComplete(ExitScene).SetEase(Ease.InOutBack);
        DOTween.ToAlpha(() => panel.GetComponent<Image>().color, x => panel.GetComponent<Image>().color = x, 1, 2);
        panel.GetComponent<Image>().DOColor(new Color(1f, 0f, 0f, 1f), 2);
        //panel.GetComponent<Image>().DOFade(1, 1);
    }

    

    void EnterScene()
    {

    }

    void ExitScene()
    {
        SceneManager.LoadScene(1);
    }
}
