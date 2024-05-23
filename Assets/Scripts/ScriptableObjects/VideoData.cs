using UnityEngine;
using UnityEngine.Video;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "VideoData", menuName = "Video/videoData")]
    public class VideoData : ScriptableObject {
        public string videoName;
        public VideoClip clip;
        public string url;
        public Texture thumbnailTexture;
    }
}