using System;

namespace Code.Infrastructure.AssetManagement
{
    public interface IAssetDownloadReporter: IProgress<float>
    {
        float Progress { get; }
        event Action ProgressUpdated;
        void Reset();
    }
}