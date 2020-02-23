using UnityEngine;

public class Knight_SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, swordSound, barrelBreak, potBreak;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Knight_Jump2");
        swordSound = Resources.Load<AudioClip>("Knight_Sword1");
        barrelBreak = Resources.Load<AudioClip>("Knight_Barrel");
        potBreak = Resources.Load<AudioClip>("Knight_Pot");
        audioSrc = GetComponent<AudioSource>();

    }

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
        }

    }

}
