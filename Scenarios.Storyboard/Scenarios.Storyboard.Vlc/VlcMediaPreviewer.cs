using Scenarios.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.Vlc
{
    public class VlcMediaPreviewer : IVideoPreviewer, IVideoThumbnailPreviewer, IDisposable
    {
        private Process _vlcVideoPlayerProcess;
        private string _vlcPath = "";
        private string _thumbnailPath = "";
        
        public VlcMediaPreviewer(string vlcPath,
            string vlcDownloadPath,
            string thumbnailPath)
        {
            try
            {
                _vlcPath = Path.GetFullPath(vlcPath);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to Load VLCMediaPreviewer" + 
                                Environment.NewLine +
                                exc.Message);
            }


            try
            {
                _thumbnailPath = Path.GetFullPath(thumbnailPath);

            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to Load Thumbnail Path" +
                                Environment.NewLine +
                                exc.Message);
            }
        }

        public string GetThumbnailPathFor(string videoFilePath)
        {
            string thumbnail = null;

            if (_thumbnailPath != null)
            {
                string outputName = Path.GetFileNameWithoutExtension(videoFilePath);
                string getSnapshotArgs =
                    $@"--qt-start-minimized --dummy-quiet -I dummy --rate=1 {videoFilePath} --video-filter=scene --vout=dummy --aout=dummy --scene-replace --start-time=10 --stop-time=11  --scene-format=png --scene-ratio=24 --scene-prefix={outputName} --scene-path={_thumbnailPath} vlc://quit";
                //--stop-time = 11
                //vlc://quit
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    Arguments = getSnapshotArgs,
                    FileName = _vlcPath,
                    UseShellExecute = true
                };

                _vlcVideoPlayerProcess =
                    Process.Start(processStartInfo);

                try
                {
                    _vlcVideoPlayerProcess.WaitForExit();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_vlcVideoPlayerProcess != null &&
                        !_vlcVideoPlayerProcess.HasExited)
                    {
                        _vlcVideoPlayerProcess.Kill();
                    }
                }

                if (_vlcVideoPlayerProcess != null &&
                    !_vlcVideoPlayerProcess.HasExited)
                {
                    _vlcVideoPlayerProcess.Kill();
                }

                thumbnail =
                    Directory.GetFiles(_thumbnailPath).FirstOrDefault(s => s.Contains($"{outputName}.png"));
            }

            return thumbnail;
        }

        public void LaunchVideoPreview(string videoFilePath)
        {
            string args = videoFilePath + " --play-and-exit --file-caching=10000";

            if (_vlcVideoPlayerProcess == null ||
                _vlcVideoPlayerProcess.HasExited)
            {
                _vlcVideoPlayerProcess =
                    Process.Start(_vlcPath,
                                  args);
            }
        }

        public void Dispose()
        {
            if (_vlcVideoPlayerProcess != null && 
                !_vlcVideoPlayerProcess.HasExited)
            {
                _vlcVideoPlayerProcess.Kill();
            }
        }

        private void DownloadVlc()
        {

        }
    }
}
