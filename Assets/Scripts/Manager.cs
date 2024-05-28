
using Network;
using UI;
using UnityEngine;
using VideoPlayer;

public class Manager : MonoBehaviour
{
    [SerializeField] private VideoLoader _videoLoader;
    [SerializeField] private VideoPlayerManager _videoPlayerManager;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private GameEventScriptableObject playerPositionGameEvent;
    [SerializeField] private Transform playerPosition;

    private void Awake()
    {
        string[] urls = _videoLoader.Execute();
        _uiManager.Init(urls);
        _videoPlayerManager.Init(this);
        BindAction();
    }

    private void Start() {
        playerPositionGameEvent.TriggerEvent(playerPosition);
    }

    private void Update()
    {
        _videoPlayerManager.Update();
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
        _uiManager.videoPlayerUi.BindVolume(_videoPlayerManager.UpdateVolume);
        _uiManager.videoFolderUi.BindPlayVideoButton(_videoPlayerManager.LoadClip);
    }

    private void BindVideoPlayerManager() {
        _videoPlayerManager.BindPlayBackTimeLineUi(_uiManager.videoPlayerUi.UpdatePlayBackTimeLine);
        _videoPlayerManager.BindTimeStampUi(_uiManager.videoPlayerUi.UpdateTimeStamp);
    }
}
