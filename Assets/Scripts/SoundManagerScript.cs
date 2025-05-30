using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip coinSound, portalSound, gameOverSound, checkPointSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        coinSound = Resources.Load<AudioClip>("coin");
        portalSound = Resources.Load<AudioClip>("woosh");
        gameOverSound = Resources.Load<AudioClip>("gameover");
        checkPointSound = Resources.Load<AudioClip>("checkpoint");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "portal":
                audioSrc.PlayOneShot(portalSound);
                break;
            case "gameover":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "checkpoint":
                audioSrc.PlayOneShot(checkPointSound);
                break;
        }
    }
}
