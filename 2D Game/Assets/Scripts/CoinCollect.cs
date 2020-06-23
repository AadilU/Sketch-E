using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI t = new TextMeshProUGUI();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinCount++;
        if (collision.transform.tag == "Coin")
        {
            t.text = coinCount.ToString();
            Destroy(collision.gameObject);
        }
    }
}
