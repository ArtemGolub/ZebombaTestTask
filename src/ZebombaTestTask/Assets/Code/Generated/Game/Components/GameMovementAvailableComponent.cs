//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMovementAvailable;

    public static Entitas.IMatcher<GameEntity> MovementAvailable {
        get {
            if (_matcherMovementAvailable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovementAvailable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMovementAvailable = matcher;
            }

            return _matcherMovementAvailable;
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

    static readonly Code.Gameplay.Movement.MovementAvailable movementAvailableComponent = new Code.Gameplay.Movement.MovementAvailable();

    public bool isMovementAvailable {
        get { return HasComponent(GameComponentsLookup.MovementAvailable); }
        set {
            if (value != isMovementAvailable) {
                var index = GameComponentsLookup.MovementAvailable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : movementAvailableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
