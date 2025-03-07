namespace Code.Meta.UI.HUD.PauseWindow.PauseButton.Services
{
    public interface IGamePauseButtonService
    {
        GamePauseButtonController SetGamePauseButton(GamePauseButtonController gamePauseButtonController);
        GamePauseButtonController GetGamePauseButton();
    }
}