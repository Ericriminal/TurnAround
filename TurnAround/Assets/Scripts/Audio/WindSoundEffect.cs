using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSoundEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody player;
    float combinedSpeed;
    private AudioSource src;
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        combinedSpeed = Mathf.Abs(player.velocity.x + player.velocity.y + player.velocity.z);
        combinedSpeed /= 3f;
        Debug.Log(combinedSpeed);
        combinedSpeed -= 4f;
        if (combinedSpeed > 10f)
            combinedSpeed = 10f;
        if (combinedSpeed < 0f)
            src.volume = 0f;    
        else
            src.volume = combinedSpeed * 0.5f / 10f;    
    }
}
