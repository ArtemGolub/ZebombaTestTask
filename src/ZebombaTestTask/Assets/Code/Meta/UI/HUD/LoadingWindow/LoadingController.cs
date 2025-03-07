using Code.Gameplay.Windows.UpdatableWindows;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD.LoadingWindow
{
    public class LoadingController: MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Image progressImage;
        
        private LoadingWindowView _view;
        private IAssetDownloadReporter _downloadReporter;

        [Inject]
        private void Construct(IAssetDownloadReporter downloadReporter)
        {
            _downloadReporter = downloadReporter;
        }
        private void Awake()
        {
            _view = new LoadingWindowView(progressImage);
            _downloadReporter.ProgressUpdated += DisplayDownloadProgress;
        }

        public void Show()
        {
            canvas.enabled = true;
        }

        public void Hide()
        {
            canvas.enabled = false;
        }
        
        private void OnDestroy()
        {
            _downloadReporter.ProgressUpdated -= DisplayDownloadProgress;
        }
        
        private void DisplayDownloadProgress()
        {
            _view.SetProgress(_downloadReporter.Progress);
        }
        
    }
}