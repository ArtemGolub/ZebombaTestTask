//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class AudioMatcher {

    static Entitas.IMatcher<AudioEntity> _matcherMusicSource;

    public static Entitas.IMatcher<AudioEntity> MusicSource {
        get {
            if (_matcherMusicSource == null) {
                var matcher = (Entitas.Matcher<AudioEntity>)Entitas.Matcher<AudioEntity>.AllOf(AudioComponentsLookup.MusicSource);
                matcher.componentNames = AudioComponentsLookup.componentNames;
                _matcherMusicSource = matcher;
            }

            return _matcherMusicSource;
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

    public Code.Audios.Audio.MusicSource musicSource { get { return (Code.Audios.Audio.MusicSource)GetComponent(AudioComponentsLookup.MusicSource); } }
    public UnityEngine.AudioSource MusicSource { get { return musicSource.Value; } }
    public bool hasMusicSource { get { return HasComponent(AudioComponentsLookup.MusicSource); } }

    public AudioEntity AddMusicSource(UnityEngine.AudioSource newValue) {
        var index = AudioComponentsLookup.MusicSource;
        var component = (Code.Audios.Audio.MusicSource)CreateComponent(index, typeof(Code.Audios.Audio.MusicSource));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public AudioEntity ReplaceMusicSource(UnityEngine.AudioSource newValue) {
        var index = AudioComponentsLookup.MusicSource;
        var component = (Code.Audios.Audio.MusicSource)CreateComponent(index, typeof(Code.Audios.Audio.MusicSource));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public AudioEntity RemoveMusicSource() {
        RemoveComponent(AudioComponentsLookup.MusicSource);
        return this;
    }
}
