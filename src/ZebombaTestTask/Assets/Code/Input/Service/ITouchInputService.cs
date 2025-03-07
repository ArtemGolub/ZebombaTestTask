using UnityEngine;

namespace Code.Input.Service
{
    public interface ITouchInputService
    {
        bool HasTouchInput();
        Vector2 GetTouchDirection();
    }
}