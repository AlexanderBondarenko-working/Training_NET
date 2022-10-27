using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Task01_1
{
    public class VideoMaterial : TrainingMaterial, IVersionable
    {
        private Version _version;

        public Uri VideoContent { get; private set; }
        public Uri SplashScreen { get; private set; }
        public VIDEO_FORMAT VideoFormat { get; private set; }

        public VideoMaterial(string videoContentURI, VIDEO_FORMAT videoFormat, string splashScreenURI)
        {
            VideoContent = new Uri(videoContentURI);
            VideoFormat = videoFormat;
            SplashScreen = new Uri(splashScreenURI);
        }

        public override string ToString()
        {
            return "VideoMaterial: " + VideoContent + "" + SplashScreen + "" + VideoFormat;
        }

        public Version GetVersion()
        {
            _version ??= new Version();
            return _version;
        }

        public void SetVersion(string version)
        {
            _version = new Version(version);
        }

        public override object Clone()
        {
            var videoMaterial = new VideoMaterial(VideoContent.AbsoluteUri, VideoFormat, SplashScreen.AbsoluteUri)
            {
                _version = _version.Clone() as Version
            };
            return videoMaterial;
        }
    }
}
