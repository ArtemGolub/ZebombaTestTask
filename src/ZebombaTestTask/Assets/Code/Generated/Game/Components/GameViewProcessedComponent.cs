//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherViewProcessed;

    public static Entitas.IMatcher<GameEntity> ViewProcessed {
        get {
            if (_matcherViewProcessed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewProcessed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewProcessed = matcher;
            }

            return _matcherViewProcessed;
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

    static readonly Code.Common.ViewProcessed viewProcessedComponent = new Code.Common.ViewProcessed();

    public bool isViewProcessed {
        get { return HasComponent(GameComponentsLookup.ViewProcessed); }
        set {
            if (value != isViewProcessed) {
                var index = GameComponentsLookup.ViewProcessed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : viewProcessedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
