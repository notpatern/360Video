
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
        [SerializeField] private VideoClip clip;

        private UnityAction<double, double> OnTimeChange;

        bool _isPlaying = false;

        private MonoBehaviour _mono;
        public void Init(MonoBehaviour mono)
        {
            _mono = mono;
            clipHandler.Init(mono);
            videoPlayer.isLooping = true;
            SetVolume(0.25f);
            LoadClip(clip);
        }

        public void BindPlayBackTimeLineUi(UnityAction<double, double> action) {
            OnTimeChange += action;
        }

        public void BindTimeStampUi(UnityAction<double, double> action) {
            OnTimeChange += action;
        }

        public void UpdateVolume(float volume) {
            SetVolume(volume);
        }

        private void SetVolume(float volume) {
            videoPlayer.SetDirectAudioVolume(0, volume);
        }

        public void LoadClip(VideoClip clip) {
            _mono.StartCoroutine(clipHandler.TransitionToNextClipCoroutine(clip, videoPlayer));
            Play();
        }

        public void ChangePlayBackSpeed(int speed) {
            videoPlayer.playbackSpeed = speedValues[speed];
        }

        public void ChangeTimeLine(float time) {
            double newTimePosition = time * videoPlayer.clip.length;
            videoPlayer.time = newTimePosition;
        }

        public void UpdatePlayBackState() {
            if (videoPlayer.clip == null)
            {
                return;
            }

            if (_isPlaying) {
                Pause();
                return;
            }

            Play();
        }

        private void Play()
        {
            _isPlaying = true;
            videoPlayer.Play();
        }

        private void Pause()
        {
            _isPlaying = false;
            videoPlayer.Pause();
        }

        public void Update() {
            UpdateVideoUi();
        }

        private void UpdateVideoUi() {
            if (_isPlaying) {
                OnTimeChange(videoPlayer.clockTime, videoPlayer.clip.length);
            }
        }
    }
}
