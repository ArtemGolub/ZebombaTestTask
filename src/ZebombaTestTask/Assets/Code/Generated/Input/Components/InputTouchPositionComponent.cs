//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherTouchPosition;

    public static Entitas.IMatcher<InputEntity> TouchPosition {
        get {
            if (_matcherTouchPosition == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.TouchPosition);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherTouchPosition = matcher;
            }

            return _matcherTouchPosition;
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
public partial class InputEntity {

    public Code.Input.TouchPosition touchPosition { get { return (Code.Input.TouchPosition)GetComponent(InputComponentsLookup.TouchPosition); } }
    public UnityEngine.Vector2 TouchPosition { get { return touchPosition.Value; } }
    public bool hasTouchPosition { get { return HasComponent(InputComponentsLookup.TouchPosition); } }

    public InputEntity AddTouchPosition(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.TouchPosition;
        var component = (Code.Input.TouchPosition)CreateComponent(index, typeof(Code.Input.TouchPosition));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public InputEntity ReplaceTouchPosition(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.TouchPosition;
        var component = (Code.Input.TouchPosition)CreateComponent(index, typeof(Code.Input.TouchPosition));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public InputEntity RemoveTouchPosition() {
        RemoveComponent(InputComponentsLookup.TouchPosition);
        return this;
    }
}
