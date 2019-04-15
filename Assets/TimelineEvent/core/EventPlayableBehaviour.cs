using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
//[System.Serializable]
public sealed class EventPlayableBehaviour : PlayableBehaviour
{
    public EventPlayableAssetBase asset;
    public TimelineEventBase owner;

    public float normalizedTime = 0;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData) {
        // playerData はTrackでbindしたobject。
        // このプロジェクトはbindしていないので Null となる。

        if (asset.enableProcessEvent && owner != null) {
            EventTrack track = (EventTrack)info.output.GetReferenceObject();
            normalizedTime = (float)(playable.GetTime() / playable.GetDuration());
            Process(track.name, normalizedTime);
        }
    }

    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        //Debug.Log("OnGraphStart: ");
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        //Debug.Log("OnGraphStop: ");
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //var resolver = playable.GetGraph().GetResolver();
        // track 
        if (owner != null) {
            EventTrack track = (EventTrack)info.output.GetReferenceObject();

            normalizedTime = 0;
            Process(track.name, normalizedTime);
            owner.OnEnter(track.name, asset);
        }
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (owner != null) {
            EventTrack track = (EventTrack)info.output.GetReferenceObject();

            normalizedTime = 1;
            Process(track.name, normalizedTime);
            owner.OnExit(track.name, asset);
        }
    }

    void Process(string trackName, float normalizedTime_) {
        if (asset.enableProcessEvent && owner != null) {
            owner.OnProcess(trackName, asset, normalizedTime_);
        }
    }

    // Called each frame while the state is set to Play
    //public override void PrepareFrame(Playable playable, FrameData info)
    //{

    //}
}
