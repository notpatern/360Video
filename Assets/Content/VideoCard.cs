using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Content {
    public class VideoCard {
        GameObject _videoCardPrefab;
        GameObject _videoCardGameObject;
        VideoClip _video;
        Transform _transform;
        Button _button;
        TextMeshProUGUI _buttonText;
        Texture _thumbnail;
        string _text;

        UnityEvent<VideoClip> GetVideoClipAction = new UnityEvent<VideoClip>();

        public VideoCard(VideoClip video, Texture thumbnail, string text, Transform transform, GameObject videoCardPrefab, UnityAction<VideoClip> action) {

            _video = video;
            _transform = transform;
            _videoCardPrefab = videoCardPrefab;
            _text = text;
            _thumbnail = thumbnail;
            _videoCardGameObject = Object.Instantiate(_videoCardPrefab, _transform);
            Init();
            BindButton(action);
        }

        private void Init() {
            _button = _videoCardGameObject.GetComponent<Button>();
            _buttonText = _videoCardGameObject.GetComponentInChildren<TextMeshProUGUI>();
            _buttonText.text = _text;

            _button.GetComponentInChildren<RawImage>().texture = _thumbnail;
        }

        public VideoClip GetVideoClip() {
            return _video;
        }

        public void BindButton(UnityAction<VideoClip> action) {
            GetVideoClipAction.AddListener(action);

            _button.onClick.AddListener(() => {
                GetVideoClipAction.Invoke(GetVideoClip());
            });
        }

        public void Destroy() {
            Object.Destroy(_videoCardGameObject);
        }
    }
}