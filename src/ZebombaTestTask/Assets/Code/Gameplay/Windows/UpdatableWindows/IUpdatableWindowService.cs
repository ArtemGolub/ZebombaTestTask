namespace Code.Gameplay.Windows.UpdatableWindows
{
    public interface IUpdatableWindowService
    {
        void Open(UpdatableWindowId staticWindowId);
        void Close(UpdatableWindowId staticWindowId);
        void CloseAll();
    }
}