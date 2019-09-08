using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject panel;
    public Text title;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton() {
        GetComponent<Animator>().SetTrigger("StartButton");
        GetComponent<AudioSource>().Play();
        Invoke("LoadScene", 1f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);

    }

}
