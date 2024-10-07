using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGame : MonoBehaviour
{
    public GameObject musicBad;
    public AudioClip[] musicGame;
    public AudioSource musicSource;
    public int massIndex;

    private void Start()
    {
        massIndex = Random.Range(0, 1);
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicGame[massIndex];
        musicSource.loop = true;
        if (MusicManager.isActiveCheck == 1)
        {
            MusicManager.isPlayingMusic = true;
        }
        else if (MusicManager.isActiveCheck == -1)
        {
            MusicManager.isPlayingMusic = false;
        }
        ToggleMusic();
    }

    public void ToggleMusic()
    {
        if (MusicManager.isPlayingMusic)
        {
            if (musicSource.time == musicSource.clip.length)
            {
                musicSource.time = 0;
            }
            musicSource.Play();
            musicBad.SetActive(false);
            MusicManager.isActiveCheck = 1;
            MusicManager.isPlayingMusic = false;
        }
        else
        {
            musicSource.Pause();
            musicBad.SetActive(true);
            MusicManager.isActiveCheck = -1;
            MusicManager.isPlayingMusic = true;
        }
    }
}
