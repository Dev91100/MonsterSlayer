using UnityEngine;

// This script controls the sounds emitted by the player and other objects

// This script is attached to Knight_SoundManager

/* 
    Alexander Zotov, 2017 : How to add sound or audio effects SFX to Unity 2D arcade game | Very simple Unity 2D Tutorial
    Available from: https://www.youtube.com/watch?v=8pFlnyfRfRc
*/

public class Knight_SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, swordSound, barrelBreak, potBreak, coinCollect; // Variables storing the different sounds
    static AudioSource audioSrc;

    void Start()
    {
        // Assigns audio clips located in the resources folder to the audio source
        jumpSound = Resources.Load<AudioClip>("Knight_Jump2");
        swordSound = Resources.Load<AudioClip>("Knight_Sword1");
        barrelBreak = Resources.Load<AudioClip>("Knight_Barrel");
        potBreak = Resources.Load<AudioClip>("Knight_Pot");
        coinCollect = Resources.Load<AudioClip>("Power_Coin");

        // Add a reference to the audio source component
        audioSrc = GetComponent<AudioSource>();

    }

    // This function check which audio to play in different cases

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Knight_Jump2":
                audioSrc.PlayOneShot(jumpSound);
                break;

            case "Knight_Sword1":
                audioSrc.PlayOneShot(swordSound);
                break;
            case "Knight_Barrel":
                audioSrc.PlayOneShot(barrelBreak);
                break;
            case "Knight_Pot":
                audioSrc.PlayOneShot(potBreak);
                break;
            case "Power_Coin":
                audioSrc.PlayOneShot(coinCollect);
                break;
        }

    }

}
