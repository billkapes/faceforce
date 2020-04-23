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
    public Camera mainCam;

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
        FadeIn();

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
        mainCam.DOOrthoSize(15f, 1).From().SetEase(Ease.OutQuint);
        greenLight.intensity = 1;
        greenLight.DOIntensity(0, 1);
        panel.GetComponent<Image>().DOColor(new Color(1f, 0f, 0f, 1f), 2).From();


    }

    public void FoundGoal()
    {
        FadeOut();
        
    }

    private void FadeOut()
    {
        mainCam.DOOrthoSize(15f, 1).SetEase(Ease.InQuint);
        mainLight.intensity = 0;
        greenLight.DOIntensity(25, 1).OnComplete(ExitScene).SetEase(Ease.InOutBack);
        DOTween.ToAlpha(() => panel.GetComponent<Image>().color, x => panel.GetComponent<Image>().color = x, 1, 2);
        panel.GetComponent<Image>().DOColor(new Color(1f, 0f, 0f, 1f), 2);
    }



    void ExitScene()
    {
        SceneManager.LoadScene(1);
    }
}
