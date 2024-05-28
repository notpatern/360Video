using Content;
using ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

namespace UI {
    [Serializable]
    public class VideoFolderUi {
        [SerializeField] Canvas canvas;
        [SerializeField] Transform cardSpawnPoint;
        [SerializeField] Transform playVideoSpawnPoint;
        [SerializeField] GameObject videoCardPrefab;
        [SerializeField] GameObject playVideoButtonPrefab;

        Button playVideoButton;
        UnityEvent<VideoClip> loadVideoEvent = new UnityEvent<VideoClip>();

        // testing
        [SerializeField] VideoData[] videoData;

        [HideInInspector] public VideoClip selectedClip;

        VideoCard[] videoCards;

        public void Init(string[] urls) {
            InitButtons();
        }

        private void InitButtons() {

            videoCards = new VideoCard[videoData.Length];

            for (int i = 0; i < videoData.Length; i++) { 
                if (videoData[i].url != null) {
                    videoCards[i] = new VideoCard(videoData[i].url, videoData[i].thumbnailTexture, videoData[i].videoName, cardSpawnPoint, videoCardPrefab, SelectCard);
                }
                videoCards[i] = new VideoCard(videoData[i].clip, videoData[i].thumbnailTexture, videoData[i].videoName, cardSpawnPoint, videoCardPrefab, SelectCard);
            }

            playVideoButton = UnityEngine.Object.Instantiate(playVideoButtonPrefab, playVideoSpawnPoint).GetComponent<Button>();
        }

        private void SelectCard(VideoClip clip) {
            selectedClip = clip;
        }

        private void SelectCard(string clip) {

            // TODO: once the web server is setup, rework all of this

            // selectedClip = clip;
        }

        public void BindPlayVideoButton(UnityAction<VideoClip> action) {

            loadVideoEvent.AddListener(action);

            playVideoButton.onClick.AddListener(() => {
                loadVideoEvent.Invoke(selectedClip);
            });
        }
    }
}