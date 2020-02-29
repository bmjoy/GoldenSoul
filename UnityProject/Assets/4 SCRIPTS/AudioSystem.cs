using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class AudioSystem : MonoBehaviour
{
    //Констанкты для настройки скрипта
    const bool loop = true; //Постоянное повторение музыки
    const int channels = 2; //Количество каналов звуков, сейчас два, для музыки и звуков


    [SerializeField] private AudioClip[] audioclips;
    private AudioSource[] audiosources;
    // 0 - MusicSource
    // 1 - soundSource
    private AudioSource musicNOW;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            CallMusic(1);

        if (Input.GetKeyDown(KeyCode.F))
            ChangeVolume(0.1f,0,true);
    }

    private void Awake()
    {
        //Не уничтожать при переходе со сцены на сцену
        DontDestroyOnLoad(this.gameObject);
        //На всяк объект будет находится на нулевых координатах
        this.transform.position = new Vector3(0, 0, 0);
        //Создание каналов звуков
        for (int i = 0; i < channels; i++)
            gameObject.AddComponent(typeof(AudioSource));
        audiosources = GetComponents<AudioSource>();
    }
    private void CallMusic(int index) // вызов музыки из аудиоклипов
    {
        AudioSource musicNOW = audiosources[0];
        musicNOW.clip = audioclips[index];
        musicNOW.playOnAwake = false;
        musicNOW.loop = true;
        musicNOW.Play(0);
    }
    public void CallSound(int index)
    {
        AudioSource soundNOW = audiosources[1];
        soundNOW.PlayOneShot(audioclips[index]);
    }


    private void ChangeVolume(float newVolume, int Source, bool Smooth = false)
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
