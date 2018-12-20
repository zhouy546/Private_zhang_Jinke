using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangager : MonoBehaviour {
    public AudioSource audioSource;
    public AudioSource BGM;
    public List<AudioClip> audioClips = new List<AudioClip>();


    public static SoundMangager instance;


    bool isMute;
    // Use this for initialization


    private void OnEnable()
    {
        DealWithUDPMessage.ToIntro += Select;
        DealWithUDPMessage.ToDefaultScene += Select;
        DealWithUDPMessage.ToLogoWell += Select;
        DealWithUDPMessage.ToScreenProtect += Select;
        DealWithUDPMessage.ToStrategy += Select;

        DealWithUDPMessage.ToYeWuMoXing += Select;
        DealWithUDPMessage.ToCo += Select;
        DealWithUDPMessage.ToMatching += Select;
        DealWithUDPMessage.ToChinaMap += Select;
        DealWithUDPMessage.ToMainVideo += Select;

        DealWithUDPMessage.ToMainVideo += StopBGM;

    }

    private void OnDisable()
    {
        DealWithUDPMessage.ToIntro -= Select;
        DealWithUDPMessage.ToDefaultScene -= Select;
        DealWithUDPMessage.ToLogoWell -= Select;
        DealWithUDPMessage.ToScreenProtect -= Select;
        DealWithUDPMessage.ToStrategy -= Select;

        DealWithUDPMessage.ToYeWuMoXing -= Select;
        DealWithUDPMessage.ToCo -= Select;
        DealWithUDPMessage.ToMatching -= Select;
        DealWithUDPMessage.ToChinaMap -= Select;
        DealWithUDPMessage.ToMainVideo -= Select;

        DealWithUDPMessage.ToMainVideo -= StopBGM;
    }


    public void initialization() {
        if (instance == null) {
            instance = this;
        }

        ValueSheet.NameAudio_keyValuePairs.Add("Through", audioClips[0]);
        ValueSheet.NameAudio_keyValuePairs.Add("Select", audioClips[1]);
        ValueSheet.NameAudio_keyValuePairs.Add("BGM", audioClips[2]);
        SetUpbgmVolume(ValueSheet.BGMVolume);

        PlayBGM();
    }




    public void SetUpbgmVolume(float Volume) {
        BGM.volume = Volume;
    }



  

    public void GoThrough() {
        //audioSource.loop = true;
        audioSource.clip = ValueSheet.NameAudio_keyValuePairs["Through"];
        audioSource.Play();
    }

    public void Recycle()
    {
        //audioSource.loop = true;
        audioSource.clip = ValueSheet.NameAudio_keyValuePairs["Recycle"];
        audioSource.Play();
    }


    public void StopSound() {
        audioSource.loop = false;
        audioSource.Stop();
    }

    public void Select()
    {
        audioSource.clip = ValueSheet.NameAudio_keyValuePairs["Select"];
        audioSource.PlayOneShot(ValueSheet.NameAudio_keyValuePairs["Select"]);
    }

    public void PlayBGM() {


            BGM.clip = ValueSheet.NameAudio_keyValuePairs["BGM"];
        //BGM.PlayOneShot(ValueSheet.NameAudio_keyValuePairs[bgmStr]);
        Debug.Log("playBGM");
            BGM.Play();
            BGM.loop = true;

    }

    public void StopBGM()
    {
        BGM.Stop();
    }
}
