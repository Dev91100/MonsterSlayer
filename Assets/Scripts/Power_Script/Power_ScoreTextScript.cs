using UnityEngine;
using UnityEngine.UI;

// This script controls the coin counter

// This script is attached to Power_CoinCounterText

/*
  Alexander Zotov, 2017 : How to create a simple coin counter in your Unity game? Easy Unity 2D tutorial [online].
  Avaliable from : https://www.youtube.com/watch?v=-EIXQHxoicg
 */

public class Power_ScoreTextScript : MonoBehaviour
{
    Text text;
    public static int coinAmount;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = coinAmount.ToString();
    }
}
