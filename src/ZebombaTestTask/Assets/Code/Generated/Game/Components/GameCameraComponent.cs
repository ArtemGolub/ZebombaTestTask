//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCamera;

    public static Entitas.IMatcher<GameEntity> Camera {
        get {
            if (_matcherCamera == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Camera);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCamera = matcher;
            }

            return _matcherCamera;
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
public partial class GameEntity {

    public Code.Gameplay.Cameras.CameraComponent camera { get { return (Code.Gameplay.Cameras.CameraComponent)GetComponent(GameComponentsLookup.Camera); } }
    public UnityEngine.Camera Camera { get { return camera.Value; } }
    public bool hasCamera { get { return HasComponent(GameComponentsLookup.Camera); } }

    public GameEntity AddCamera(UnityEngine.Camera newValue) {
        var index = GameComponentsLookup.Camera;
        var component = (Code.Gameplay.Cameras.CameraComponent)CreateComponent(index, typeof(Code.Gameplay.Cameras.CameraComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCamera(UnityEngine.Camera newValue) {
        var index = GameComponentsLookup.Camera;
        var component = (Code.Gameplay.Cameras.CameraComponent)CreateComponent(index, typeof(Code.Gameplay.Cameras.CameraComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCamera() {
        RemoveComponent(GameComponentsLookup.Camera);
        return this;
    }
}
