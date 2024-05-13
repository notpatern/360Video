
using UnityEngine;
using UnityEngine.Events;
using VideoPlayer;

public class Manager : MonoBehaviour
{
    [SerializeField] private VideoPlayerManager _videoPlayerManager;

    private UnityEvent _transitionToNextVideo = new UnityEvent();

    private void Awake()
    {
        _videoPlayerManager.Init(this);
        BindAction();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void BindAction()
    {
        
    }

    public void BindTransitionToNextClip()
    {
        
    }
}
