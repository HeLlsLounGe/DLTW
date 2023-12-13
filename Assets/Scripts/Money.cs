using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CashText;
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float money = 0f;
    bool mask = false;
    bool worm = true;
    bool apple = false;
    bool water = false;
    bool startTimer = false;
    float waterCount = 0;
    float timer = 60;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            money += 1;
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {
        CashText.text = (":" + money);
        if (worm)
        {
            canvas.gameObject.SetActive(true);
        }
        if (startTimer)
        {
            Debug.Log("timer start");
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            TimerText.text = "" + timer;
            SceneManager.LoadScene("Game");
        }
    }
    public void BuyMask()
    {
        if (money >= 16 && mask == false)
        {
            money -= 16;
            mask = true;
        }
    }
    public void BuyWorm()
    {
        if (money >= 5 && worm == false)
        {
            money -= 5;
            worm = true;
        }
    }
    public void BuyApple()
    {
        if (money >= 2 && apple == false)
        {
            money -= 2;
            apple = true;
        }
    }
    public void BuyWater()
    {
        if (money >= 3 && water == false && waterCount<2)
        {
            money -= 3;
            water = true;
            waterCount++;
        }
    }
    public void WormB()
    {
        Debug.Log("button press");
        startTimer = true;
    }
}
