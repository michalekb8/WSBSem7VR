using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager __audioInstance;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        if (__audioInstance == null)
        {
            __audioInstance = this;
            DontDestroyOnLoad(gameObject);

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
