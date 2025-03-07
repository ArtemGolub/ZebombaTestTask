using UnityEngine;
using UnityEngine.UI;

namespace Code.Meta.UI.HUD.LoadingWindow
{
    public class LoadingWindowView
    {
        private readonly Image _progressSlider;
        public LoadingWindowView(Image progressSlider)
        {
            _progressSlider = progressSlider;
        }

        public void SetProgress(float progress)
        {
            _progressSlider.fillAmount = progress;
            Debug.Log(_progressSlider.fillAmount);
        }
        
    }
}