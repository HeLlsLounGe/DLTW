using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CashText;
    [SerializeField] float money = 0f;
    bool mask = false;
    bool worm = false;
    bool apple = false;
    bool water = false;
    float waterCount = 0;
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
}
