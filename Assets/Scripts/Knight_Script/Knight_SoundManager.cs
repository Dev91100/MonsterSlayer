using UnityEngine;

public class Knight_SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, swordSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Knight_Jump2");
        swordSound = Resources.Load<AudioClip>("Knight_Sword1");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

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
        }

    }

}
