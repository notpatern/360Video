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
        [SerializeField] TMP_Text timeStamp;

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

        public void UpdateTimeStamp(double time, double fullTime) {
            TimeSpan timeValues = TimeSpan.FromSeconds(time);

            TimeSpan fullTimeValues = TimeSpan.FromSeconds(fullTime);

            string timeStampContent = timeValues.ToString("mm\\:ss") + "/" + fullTimeValues.ToString("mm\\:ss");

            timeStamp.text = timeStampContent;
        }

        public void UpdatePlayBackTimeLine(double time, double fullTime) {

            float timeValue = (float)(time / fullTime);

            videoTimeLine.SetValueWithoutNotify(timeValue);
        }
    }
}