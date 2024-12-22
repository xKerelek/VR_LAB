using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public RawImage gameOverPanel;
    public Text restartText;
    private bool isGameOver;

    void Start()
    {
        gameOverPanel.enabled = false;
        isGameOver = false;
    }

    void OnCollisionEnter(Collision theObject)
    {
        if (theObject.gameObject.name == "coconut")
        {
            Debug.Log("Wilk zosta³ trafiony kokosem!");
            GetComponent<Animator>().SetTrigger("hit");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Wilk zjad³ gracza!");
            isGameOver = true;
            gameOverPanel.enabled = true;
            restartText.SendMessage("ShowHint", "Kliknij spacjê aby rozpocz¹æ od nowa lub kliknij myszk¹ na ekran");
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadMenu();
            }
            if (Input.GetMouseButtonDown(0))
            {
                LoadMenu();
            }
        }
    }

    void LoadMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
    }
}
