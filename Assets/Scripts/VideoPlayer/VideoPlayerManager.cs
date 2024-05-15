
using OpenCover.Framework.Model;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace VideoPlayer
{
    [Serializable]
    public class VideoPlayerManager
    {
        [SerializeField] private UnityEngine.Video.VideoPlayer videoPlayer;
        [SerializeField] private ClipHandler clipHandler;
        [SerializeField] private float[] speedValues;

        private UnityAction<float> OnTimeChange;

        bool _isPlaying = false;

        private MonoBehaviour _mono;
        public void Init(MonoBehaviour mono)
        {
            _mono = mono;
            clipHandler.Init(mono);
        }

        public void BindPlayBackTimeLineUi(UnityAction<float> action) {
            OnTimeChange += action;
        }

        public void LoadClip(VideoClip clip) {
            _mono.StartCoroutine(clipHandler.TransitionToNextClipCoroutine(clip, videoPlayer));
        }

        public void ChangePlayBackSpeed(int speed) {
            videoPlayer.playbackSpeed = speedValues[speed];
        }

        public void ChangeTimeLine(float time) {
            Debug.Log(time);
        }

        public void UpdatePlayBackState() {
            if (_isPlaying) {
                Pause();
                _isPlaying = false;
                return;
            }

            Play();
            _isPlaying = true;
        }

        private void Play()
        {
            videoPlayer.Play();
        }

        private void Pause()
        {
            videoPlayer.Pause();
        }

        public void Update() {
            UpdateVideoUiTimeLine();
        }

        private void UpdateVideoUiTimeLine() {
            if (videoPlayer.isPlaying && OnTimeChange != null) {
                float currentTime = (float)(videoPlayer.clockTime / videoPlayer.clip.length);
                OnTimeChange(currentTime);
            }
        }
    }
}
