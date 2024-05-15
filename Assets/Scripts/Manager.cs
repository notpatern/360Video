
using UI;
using UnityEngine;
using UnityEngine.Events;
using VideoPlayer;

public class Manager : MonoBehaviour
{
    [SerializeField] private VideoPlayerManager _videoPlayerManager;
    [SerializeField] private UiManager _uiManager;

    private void Awake()
    {
        _videoPlayerManager.Init(this);
        BindAction();
    }

    private void Update()
    {
        
    }

    private void BindAction()
    {
        BindUi();
        BindVideoPlayerManager();
    }

    private void BindUi() {
        _uiManager.videoPlayerUi.BindPauseButton(_videoPlayerManager.UpdatePlayBackState);
        _uiManager.videoPlayerUi.BindPlayBackSpeedSelector(_videoPlayerManager.ChangePlayBackSpeed);
        _uiManager.videoPlayerUi.BindVideoTimeLine(_videoPlayerManager.ChangeTimeLine);
    }

    private void BindVideoPlayerManager() {
        _videoPlayerManager.BindPlayBackTimeLineUi(_uiManager.videoPlayerUi.UpdatePlayBackTimeLine);
    }
}
