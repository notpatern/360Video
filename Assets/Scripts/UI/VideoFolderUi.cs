using Content;
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
        [SerializeField] VideoClip[] videoClips;
        [SerializeField] Texture[] thumbnails;

        [HideInInspector] public VideoClip selectedClip;

        VideoCard[] videoCards;


        // MAKE CARD DATA FOR PREFAB WITH TEXTURE VIDEO CLIP AND NAME


        public void Init() {
            InitButtons();
        }

        private void InitButtons() {

            videoCards = new VideoCard[videoClips.Length];

            for (int i = 0; i < videoClips.Length; i++) { 
                videoCards[i] = new VideoCard(videoClips[i], thumbnails[i], "video " + i.ToString(), cardSpawnPoint, videoCardPrefab, SelectCard);
            }

            playVideoButton = UnityEngine.Object.Instantiate(playVideoButtonPrefab, playVideoSpawnPoint).GetComponent<Button>();
        }

        private void SelectCard(VideoClip clip) {
            selectedClip = clip;
        }

        public void BindPlayVideoButton(UnityAction<VideoClip> action) {

            loadVideoEvent.AddListener(action);

            playVideoButton.onClick.AddListener(() => {
                loadVideoEvent.Invoke(selectedClip);
            });
        }
    }
}