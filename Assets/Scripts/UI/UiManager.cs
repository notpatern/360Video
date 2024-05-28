using System;
using UnityEngine;

namespace UI {
    [Serializable]
    public class UiManager {
        public VideoPlayerUi videoPlayerUi;
        public VideoFolderUi videoFolderUi;

        public void Init(string[] urls) {
            videoFolderUi.Init(urls);
        }
    }
}