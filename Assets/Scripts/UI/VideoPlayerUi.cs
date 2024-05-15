using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI {
    [Serializable]
    public class VideoPlayerUi {
        [SerializeField] Button pauseButton;
        [SerializeField] TMP_Dropdown playBackSpeedSelector;
        [SerializeField] Slider videoTimeLine;
        [SerializeField] Slider volume;

        public void BindPauseButton(UnityAction action) {
            pauseButton.onClick.AddListener(action);
        }

        public void BindPlayBackSpeedSelector(UnityAction<int> action) {
            playBackSpeedSelector.onValueChanged.AddListener(action);
        }

        public void BindVideoTimeLine(UnityAction<float> action) {
            videoTimeLine.onValueChanged.AddListener(action);
        }

        public void BindVolume(UnityAction<float> action) {
            volume.onValueChanged.AddListener(action);
        }

        public void UpdatePlayBackTimeLine(float value) {
            videoTimeLine.SetValueWithoutNotify(value);
        }
    }
}