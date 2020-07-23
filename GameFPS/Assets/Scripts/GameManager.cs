using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : Singleton<GameManager> {

    float currentTime = 0f;
    float startTime = 150f;

    [SerializeField] Text countdownText;

    public int totalEnemy = 5;
    public Text enemyCounterUI;

    public Text gameOver;



    protected GameManager() { }

    private int mHealth = 100;

    private bool GameOver = false;

    public event EventHandler GameOverEvent;


    private void OnGameOver()
    {
        if (GameOverEvent != null)
            GameOverEvent(this, EventArgs.Empty);
    }

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            GameOver = true;
            currentTime = 0;
            OnGameOver();
        }
    }

    public void RemoveEnemy ()
    {
        totalEnemy -= 1;
        enemyCounterUI.text = totalEnemy + "";
    }

    public void SetDamage(int damage)
    {
        mHealth -= damage;

        if(mHealth < 0)
        {
            GameOver = true;
            mHealth = 0;
            OnGameOver();

            //add player dead logic.
        }
    }

    public int Health
    {
        get { return mHealth; }
    }

    public bool IsGameOver
    {
        get { return GameOver; }
    }

    public bool IsWon
    {
        get
        {
            if (mHealth <= 0)
                return false;

            return true;
        }
    }
}
