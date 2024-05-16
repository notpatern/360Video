using System;
using UnityEngine;

namespace Network {
    [Serializable]
    public class VideoLoader {
        [SerializeField] string ftpUrl;
        [SerializeField] string ftpUsername;
        [SerializeField] string ftpPassword;
        [SerializeField] string ftpPathToLoad;
    }
}