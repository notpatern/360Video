using UnityEngine;
using UnityEngine.Video;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "VideoData", menuName = "Video/videoData")]
    public class VideoData : ScriptableObject {
        public string videoName;
        public VideoClip clip;
        public Texture thumbnailTexture;
    }
}