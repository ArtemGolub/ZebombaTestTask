//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class AudioMatcher {

    static Entitas.IMatcher<AudioEntity> _matcherSelfDestructTimer;

    public static Entitas.IMatcher<AudioEntity> SelfDestructTimer {
        get {
            if (_matcherSelfDestructTimer == null) {
                var matcher = (Entitas.Matcher<AudioEntity>)Entitas.Matcher<AudioEntity>.AllOf(AudioComponentsLookup.SelfDestructTimer);
                matcher.componentNames = AudioComponentsLookup.componentNames;
                _matcherSelfDestructTimer = matcher;
            }

            return _matcherSelfDestructTimer;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class AudioEntity {

    public Code.Audios.Audio.SelfDestructTimer selfDestructTimer { get { return (Code.Audios.Audio.SelfDestructTimer)GetComponent(AudioComponentsLookup.SelfDestructTimer); } }
    public float SelfDestructTimer { get { return selfDestructTimer.Value; } }
    public bool hasSelfDestructTimer { get { return HasComponent(AudioComponentsLookup.SelfDestructTimer); } }

    public AudioEntity AddSelfDestructTimer(float newValue) {
        var index = AudioComponentsLookup.SelfDestructTimer;
        var component = (Code.Audios.Audio.SelfDestructTimer)CreateComponent(index, typeof(Code.Audios.Audio.SelfDestructTimer));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public AudioEntity ReplaceSelfDestructTimer(float newValue) {
        var index = AudioComponentsLookup.SelfDestructTimer;
        var component = (Code.Audios.Audio.SelfDestructTimer)CreateComponent(index, typeof(Code.Audios.Audio.SelfDestructTimer));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public AudioEntity RemoveSelfDestructTimer() {
        RemoveComponent(AudioComponentsLookup.SelfDestructTimer);
        return this;
    }
}
