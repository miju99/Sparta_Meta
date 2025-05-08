using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource _audioSource;
    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance)
    {
        if(_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }

        CancelInvoke();
        _audioSource.clip = clip;
        _audioSource.volume = soundEffectVolume;
        _audioSource.Play();
        _audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);

        Invoke("Disable", clip.length + 2); //메서드 이름을 넣으면 지연 실행 가능
    }

    public void Disable()
    {
        _audioSource?.Stop();
        Destroy(this.gameObject);
    }
}
