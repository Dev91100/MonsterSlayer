using UnityEngine;
using UnityEngine.UI;

// Start is called before the first frame update

//Displays the number of coins

/*
  Alexander Zotov, 2017 : How to create a simple coin counter in your Unity game? Easy Unity 2D tutorial.
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

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
    }
}
