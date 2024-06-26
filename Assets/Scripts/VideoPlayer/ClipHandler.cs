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
        [SerializeField] private Material skyboxMat;
        [SerializeField] private Material videoMat;

        private RenderTexture videoRenderTexture;

        private MonoBehaviour _mono;
        private static readonly int Exposure = Shader.PropertyToID("_Exposure");

        public void Init(MonoBehaviour mono)
        {
            _mono = mono;

            ChangeSkybox(skyboxMat, 1);
        }

        public IEnumerator TransitionToNextClipCoroutine(VideoClip clip, UnityEngine.Video.VideoPlayer player)
        {
            // fades the current skybox to black
            _mono.StartCoroutine(FadeSkyBox(videoPlayerData.fadeTime, false));

            LoadClip(clip, player);
            yield return new WaitForSeconds(videoPlayerData.fadeTime);

            LoadMaterial();
            ChangeSkybox(videoMat, 0);

            // once everything is set, fades back to the current skybox
            _mono.StartCoroutine(FadeSkyBox(videoPlayerData.fadeTime, true));
            yield return new WaitForSeconds(videoPlayerData.fadeTime);
        }

        void LoadClip(VideoClip clip, UnityEngine.Video.VideoPlayer player)
        {
            // loads the video clip in the video player
            player.clip = clip;

            ChangeRenderTextureResolution(clip);

            // sets the target texture to the videoRenderTexture
            player.targetTexture = videoRenderTexture;
        }

        void LoadMaterial()
        {
            videoMat.SetTexture("_MainTex", videoRenderTexture);
        }

        void ChangeRenderTextureResolution(VideoClip clip)
        {
            videoRenderTexture = new RenderTexture((int)clip.width, (int)clip.height, 1);
        }

        void ChangeSkybox(Material newSkybox, float exposure)
        {
            RenderSettings.skybox = newSkybox;
            RenderSettings.skybox.SetFloat(Exposure, exposure);
            DynamicGI.UpdateEnvironment();
        }

        IEnumerator FadeSkyBox(float timer, bool desiredState)
        {
            float elapsedTime = 0f;
            float exposure = 0f;

            while (elapsedTime <= timer)
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

            if (exposure < 1f && desiredState) {
                RenderSettings.skybox.SetFloat(Exposure, 1f);
                DynamicGI.UpdateEnvironment();
            }
        }
    }
}
