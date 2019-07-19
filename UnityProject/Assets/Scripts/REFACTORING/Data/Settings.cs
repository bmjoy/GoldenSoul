using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GS.Utils;

namespace GS.Data {
    public class Settings: Singleton < Settings > {
        public float sensetivityValue, musicVolumeValue, effectsVolumeValue;

        protected override void Awake() {
            base.Awake();

            sensetivityValue = PlayerPrefs.GetFloat("sensitivity", 10);
            musicVolumeValue  = PlayerPrefs.GetFloat("musicVolume", 1);
            effectsVolumeValue = PlayerPrefs.GetFloat("effectsVolume", 1);
        }

        public void SaveSensetivity(float sensitivity) {
            PlayerPrefs.SetFloat("sensitivity", sensitivity);
            sensetivityValue = sensitivity;
        }

        public void SaveMusicVolume(float musicVolume) {
            PlayerPrefs.SetFloat("musicVolume", musicVolume);
            musicVolumeValue = musicVolume;
        }

        public void SaveEffectsVolume(float effectsVolume) {
            PlayerPrefs.SetFloat("effectsVolume", effectsVolume);
            effectsVolumeValue = effectsVolume;
        }
    }
}