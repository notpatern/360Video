
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace VideoPlayer
{
    [Serializable]
    public class VideoPlayerManager
    {
        [SerializeField] private UnityEngine.Video.VideoPlayer videoPlayer;
        [SerializeField] private ClipHandler clipHandler;

        private MonoBehaviour _mono;
        public void Init(MonoBehaviour mono)
        {
            _mono = mono;
            clipHandler.Init(mono);
        }

        public void Play()
        {
            videoPlayer.Play();
        }

        public void Pause()
        {
            videoPlayer.Pause();
        }
    }
}
