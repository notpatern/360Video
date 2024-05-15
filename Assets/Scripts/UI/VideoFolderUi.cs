using Content;
using System;
using UnityEngine;
using UnityEngine.Video;

namespace UI {
    [Serializable]
    public class VideoFolderUi {
        [SerializeField] Canvas canvas;
        [SerializeField] Transform spawnPoint;
        [SerializeField] GameObject videoCardPrefab;

        // testing
        [SerializeField] VideoClip[] videoClips;

        [HideInInspector] public VideoClip selectedClip;

        VideoCard[] videoCards;

        public void Init() {
            InitButtons();
        }

        private void InitButtons() {

            videoCards = new VideoCard[videoClips.Length];

            for (int i = 0; i < videoClips.Length; i++) { 
                videoCards[i] = new VideoCard(videoClips[i], "video " + i.ToString(), spawnPoint, videoCardPrefab, SelectCard);
            }
        }

        private void SelectCard(VideoClip clip) {
            selectedClip = clip;
            Debug.Log(clip.name);
        }
    }
}