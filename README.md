# TimelineEvent

![Sample](img.png)

~~~cs
public class EventExtraPlayableAsset : EventPlayableAssetBase
{
    public enum ContentType
    {
        A, B, C
    }

    public int additionalValue = 2;
    public ContentType contentType = ContentType.A;

    public override string GetEditorDisplayName() {
        return "Mod: " + clipName + "_" +contentType + "_" + additionalValue;
    }
}
~~~

~~~cs
public class TimelineEventSample : TimelineEventBase
{
    [SerializeField] Text debugText;

    public override void OnEnter(string track, EventPlayableAssetBase asset) {
        string str = "";
        str += "OnEnter: " + asset._name;
        if (asset is EventExtraPlayableAsset) {
            str += "_Type: " + ((EventExtraPlayableAsset)asset).contentType;
        }
        debugText.text = track + " / " + str;
    }

    public override void OnExit(string track, EventPlayableAssetBase asset) {
        string str = "";
        str += "OnExit: " + asset._name;
        debugText.text = track + " / " + str;
    }
}

~~~

#### 参考

 * 【Unity】Timelineで敵の”出現タイミング”や”動き”を制御してみる  
 http://tsubakit1.hateblo.jp/entry/2017/12/04/115255 

 * 【Unity】新・Timelineで字幕を作る  
 http://tsubakit1.hateblo.jp/entry/2018/08/26/173345

 * 【Unity2018.2.14f1で更新中】Timelineの基本機能とCinema Directorとの違い  
https://www.crossroad-tech.com/entry/Unity2017_2_0_timeline#4-4-Control-Track

 * UnityのTimelineTrackを実装する  
https://qiita.com/ousttrue/items/ac2f0b3847e76a36b1f0

 * そろそろUnity2017のTimelineの基礎を押さえておこう  
https://www.shibuya24.info/entry/timeline_basis

 * Timeline の拡張 ― 実践ガイド  
https://blogs.unity3d.com/jp/2018/09/05/extending-timeline-a-practical-guide/

 * UnityのTimelineをいくらか理解する  
https://framesynthesis.jp/blog/2018/06/18/

 * はじめてのScriptPlayable  
 https://labs.gree.jp/blog/2017/08/16547/

 * 【Unity】TimelineでOnBehaviourPlayのタイミングでTrackの情報を使って初期化したい  
http://tsubakit1.hateblo.jp/entry/2018/08/27/233000

 * Timelineを使ってみる  
http://aizu-vr.hatenablog.com/entry/2018/05/05/Timeline%E3%82%92%E4%BD%BF%E3%81%A3%E3%81%A6%E3%81%BF%E3%82%8B

 * Unity2017のTimelineをやってみた  
https://blog.applibot.co.jp/2017/06/16/unity2017timeline/

 * [Unite2018] スクリプトによるTimelineがっつり拡張入門  
http://turgure.hatenablog.com/entry/2018/06/26/091954
