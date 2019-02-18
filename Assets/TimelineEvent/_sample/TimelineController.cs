using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEditor;


public class TimelineController : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] TimelineAsset[] timelines;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void PlayTimeline() {
        playableDirector.Play();
    }
    void StopTimeline() {
        playableDirector.Stop();
    }
    void PauseTimeline() {
        playableDirector.Pause();
    }
    void ResumeTimeline() {
        playableDirector.Resume();
    }

    void SelectTimeline(int id) {
        TimelineAsset timelineAsset = timelines[id];

        playableDirector.playableAsset = timelineAsset;

        playableDirector.Play();
    }

    [SerializeField] Rect drawRect = new Rect(10, 10, 100, 100);
    [SerializeField] GUISkin skin;
    void OnGUI() {
        GUI.skin = skin;
        GUILayout.BeginArea(drawRect);
        GUILayout.Label(((float)(playableDirector.time / playableDirector.duration)).ToString());
        GUILayout.Label("time: " + playableDirector.time);
        //playableDirector.time = GUILayout.HorizontalSlider((float)playableDirector.time, 0, (float)playableDirector.duration);
        GUILayout.HorizontalSlider((float)playableDirector.time, 0, (float)playableDirector.duration);

        for (int i = 0; i < timelines.Length; i++) {
            if (GUILayout.Button("SelectTimeline: "+i)) {
                SelectTimeline(i);
            }
        }

        if (GUILayout.Button("PlayTimeline")) {
            PlayTimeline();
        }
        if (GUILayout.Button("PauseTimeline")) {
            PauseTimeline();
        }
        if (GUILayout.Button("ResumeTimeline")) {
            ResumeTimeline();
        }
        if (GUILayout.Button("StopTimeline")) {
            StopTimeline();
        }
        GUILayout.EndArea();
    }
}
