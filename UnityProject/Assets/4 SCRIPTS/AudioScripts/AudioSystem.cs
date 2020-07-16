using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class AudioSystem : MonoBehaviour
{
    //Констанкты для настройки скрипта
    const bool loop = true; //Постоянное повторение музыки
    const int channels = 3; //Количество каналов звуков, сейчас два, для музыки и звуков

    public AudioMass Mass;
    private AudioSource[] audiosources;
    // 0 - MusicSource
    // 1 - soundSource
    public static bool enabled1 = true;
    private AudioSource musicNOW;
    public static int PrevMusic = -1;
    public static int ThisMusic = -1;
    public static int indexMusicNow = -1;

    private void Awake()
    {
        //Не уничтожать при переходе со сцены на сцену
        DontDestroyOnLoad(gameObject);
        //На всяк объект будет находится на нулевых координатах
        transform.position = new Vector3(0, 0, 0);
        //Создание каналов звуков
        for (int i = 0; i < channels; i++)
            gameObject.AddComponent(typeof(AudioSource));
        audiosources = GetComponents<AudioSource>();
    }
    public bool CallMusic(int index, float volume = 0.5f) // вызов музыки из аудиоклипов
    {
        if(indexMusicNow != index && enabled1)
        {
            PrevMusic = index;
            if (indexMusicNow < 0)
                PrevMusic = index;
            ThisMusic = index;
            AudioSource musicNOW = audiosources[0];
            musicNOW.clip = Mass.Audiomass[index];
            musicNOW.playOnAwake = false;
            musicNOW.loop = true;
            musicNOW.Play(0);
            musicNOW.volume = volume;
            indexMusicNow = index;
            return true;
        }
        return false;
    }
    public void StopMusic() // вызов музыки из аудиоклипов
    {
        try
        {
            AudioSource musicNOW = audiosources[0];
            musicNOW.Stop();
            indexMusicNow = -1;
        }
        catch { }

    }
    public void CallSound(int index, float volume = 0.7f)
    {
        if (enabled1)
        {
            AudioSource soundNOW = audiosources[1];
            soundNOW.PlayOneShot(Mass.Soundmass[index]);
            soundNOW.volume = volume;
        }
    }

    public void CallVoice(int index, float volume = 0.6f)
    {
        AudioSource soundNOW = audiosources[2];
        soundNOW.PlayOneShot(Mass.Voicemass[index]);
        soundNOW.volume = volume;
    }
    public void ChangeVolume(float newVolume, int Source, bool Smooth = false)
    {
        AudioSource musicNOW = audiosources[Source];
      if (Smooth)
            {
                StartCoroutine(timer(newVolume, Source));
            }
      else
            {
                musicNOW.volume = newVolume;
            }
    }
    IEnumerator timer(float nv,int s)
    {
        Debug.Log("im i in");
        AudioSource musicNOW = audiosources[s];
        if (musicNOW.volume < nv)
        {
            for (float i = musicNOW.volume; i < nv; i = i+0.01f)
            {
                yield return new WaitForSeconds(0.01f);
                musicNOW.volume = i;
            }
        }
        else
        {
            for (float i = musicNOW.volume; i > nv; i = i-0.01f)
            {
                yield return new WaitForSeconds(0.01f);
                musicNOW.volume = i;
            }
        }
    }
}
