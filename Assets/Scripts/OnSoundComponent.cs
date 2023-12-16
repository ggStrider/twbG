using UnityEngine;

namespace twbG.Sounds
{
    public class OnSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField, Range(0,1)] private float _volume;

        public void OnSound()
        {
            _audioSource.volume = _volume;
            _audioSource.clip = _audioClip;

            _audioSource.Play();
        }
    }
}