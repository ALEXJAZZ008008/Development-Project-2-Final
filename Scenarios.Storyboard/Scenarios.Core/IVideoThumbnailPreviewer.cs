using System.Windows.Controls;

namespace Scenarios.Core
{
    public interface IVideoThumbnailPreviewer
    {
        string GetThumbnailPathFor(string videoFilePath);
    }
}
