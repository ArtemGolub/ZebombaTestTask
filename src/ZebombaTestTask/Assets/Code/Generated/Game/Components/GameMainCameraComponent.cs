//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMainCamera;

    public static Entitas.IMatcher<GameEntity> MainCamera {
        get {
            if (_matcherMainCamera == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MainCamera);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMainCamera = matcher;
            }

            return _matcherMainCamera;
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

    static readonly Code.Gameplay.Cameras.MainCamera mainCameraComponent = new Code.Gameplay.Cameras.MainCamera();

    public bool isMainCamera {
        get { return HasComponent(GameComponentsLookup.MainCamera); }
        set {
            if (value != isMainCamera) {
                var index = GameComponentsLookup.MainCamera;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : mainCameraComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
