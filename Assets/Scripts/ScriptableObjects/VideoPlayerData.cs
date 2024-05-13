
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "VideoPlayerData", menuName = "VideoPlayer/videoPlayerData")]
    public class VideoPlayerData : ScriptableObject
    {
        public float onExposure;
        public float offExposure;
        public float fadeTime;
    }
}
