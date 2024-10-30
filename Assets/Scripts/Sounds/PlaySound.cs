using UnityEngine;

namespace Sounds
{
    public class PlaySound : MonoBehaviour
    {
        [SerializeField] private PlayType _playType;
        [SerializeField] private AudioClip[] _audioClips;
        
        [SerializeField] private AudioSource _audioSource;

        [SerializeField, Range(0, 1)] private float _volume;

        private uint _clipIndex;

        private enum PlayType
        {
            FirstInArray,
            Sequence,
            Random
        };

        public void Play()
        {
            if (_audioSource == null || _audioClips.Length == 0)
            {
                Debug.LogWarning($"Audio source: {_audioSource}, clips length: {_audioClips.Length}");
                return;
            }

            var clipToPlay = GetClip();
            _audioSource.PlayOneShot(clipToPlay, _volume);
        }

        private AudioClip GetClip()
        {
            AudioClip clip;

            switch (_playType)
            {
                case PlayType.FirstInArray:
                    clip = _audioClips[0];
                    break;
                
                case PlayType.Sequence:
                    clip = _audioClips[_clipIndex];
                    _clipIndex = (uint)Mathf.Repeat(_clipIndex + 1, _audioClips.Length - 1);
                    break;
                
                case PlayType.Random:
                    var random = Random.Range(0, _audioClips.Length - 1);
                    clip = _audioClips[random];
                    break;
                
                default:
                    Debug.Log("Something went wrong!");
                    clip = _audioClips[0];
                    break;
            }

            return clip;
        }
    }
}