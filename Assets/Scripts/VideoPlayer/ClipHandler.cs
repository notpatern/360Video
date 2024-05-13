using System;
using System.Collections;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Video;

namespace VideoPlayer
{
    [Serializable]
    public class ClipHandler
    {
        [SerializeField] private VideoPlayerData videoPlayerData;
        [SerializeField] private Material skybox;
        [SerializeField] private Material video;

        private MonoBehaviour _mono;
        [HideInInspector] public VideoClip nextVideoClip;
        private static readonly int Exposure = Shader.PropertyToID("_Exposure");

        public void Init(MonoBehaviour mono)
        {
            _mono = mono;
            
            RenderSettings.skybox = skybox;
            DynamicGI.UpdateEnvironment();
        }

        private void TransitionToNextClip()
        {
            _mono.StartCoroutine(FadeSkyBox(videoPlayerData.fadeTime, false));
            // load clip and dim up the skybox
            _mono.StartCoroutine(FadeSkyBox(videoPlayerData.fadeTime, true));
        }

        IEnumerator FadeSkyBox(float timer, bool desiredState)
        {
            float elapsedTime = 0f;
            float exposure = 0;

            while (elapsedTime < timer)
            {
                if (desiredState)
                {
                    exposure = Mathf.Lerp(videoPlayerData.offExposure, videoPlayerData.onExposure, elapsedTime);
                }
                else
                {
                    exposure = Mathf.Lerp(videoPlayerData.onExposure, videoPlayerData.offExposure, elapsedTime);
                }
                
                RenderSettings.skybox.SetFloat(Exposure, exposure);
                DynamicGI.UpdateEnvironment();

                elapsedTime += Time.deltaTime;

                yield return null;
            }
        }
    }
}
