using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraEffect : MonoBehaviour {
    public PostProcessingBehaviour postProcessingBehaviour;
    public AnimationCurve ChromaticAberrationCurve;
    public AnimationCurve BloomCurve;
    // Use this for initialization
    private void OnEnable()
    {
        OverriderCameraMove.CameraMove += onMove;

    }

    private void OnDisable()
    {
        OverriderCameraMove.CameraMove -= onMove;
    }

    public void Start()
    {
        initialization();
    }


    public void initialization() {


       
    }

    private void onMove()
    {

        TweenChromaticAberration(1f, ChromaticAberrationCurve);
        TweenBloomAberration(1f, BloomCurve);
    }


    private void TweenChromaticAberration(float time,AnimationCurve curve) {
        ChromaticAberrationModel chromaticAberrationModel = postProcessingBehaviour.profile.chromaticAberration;
        ChromaticAberrationModel.Settings chromaticAberrationModelSetting = postProcessingBehaviour.profile.chromaticAberration.settings;
        

        LeanTween.value(0, 1, time).setEase(curve).setOnUpdate(delegate (float val) {

            chromaticAberrationModelSetting.intensity = val;

            chromaticAberrationModel.settings = chromaticAberrationModelSetting;
        });
    }

    private void TweenBloomAberration(float time, AnimationCurve curve)
    {
        BloomModel bloomModel = postProcessingBehaviour.profile.bloom;
        BloomModel.Settings bloomModelSetting = postProcessingBehaviour.profile.bloom.settings;


        LeanTween.value(0, 1, time).setEase(curve).setOnUpdate(delegate (float val) {

            bloomModelSetting.bloom.intensity = val;

            bloomModel.settings = bloomModelSetting;
        });
    }
}
