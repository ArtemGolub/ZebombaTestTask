using UnityEngine;

namespace Code.Input.Service
{
    public interface IInputService
    {
        bool HasTouchInput();
        float GetVerticalAxis();
        float GetHorizontalAxis();
        bool HasAxisInput();
    
        bool GetLeftMouseButtonDown();
        Vector2 GetScreenMousePosition();
        Vector2 GetWorldMousePosition();
        bool GetLeftMouseButtonUp();

    }
}