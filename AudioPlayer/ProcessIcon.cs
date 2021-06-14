using System;
using System.Windows.Forms;
using AudioPlayer.Properties;
using WMPLib;

namespace AudioPlayer
{

    class ProcessIcon : IDisposable
    {
        private NotifyIcon _notifyIcon;
        private WindowsMediaPlayer _player;

        public ProcessIcon()
        {

            _notifyIcon = new NotifyIcon();
            GlobalHotKey.RegisterHotKey(Constants.HotKey, PlayPauseAudio);
            _player = new WindowsMediaPlayer { URL = Constants.AudioSource };
        }


        public void Display()
        {

            _notifyIcon.MouseClick += new MouseEventHandler(MouseClick);
            _notifyIcon.Icon = Resources.SystemTrayIcon;
            _notifyIcon.Text = "Play/Pause an audio stream using windows media player";
            _notifyIcon.Visible = true;

            // Attach a context menu.
            _notifyIcon.ContextMenuStrip = new ContextMenus().Create(PlayPauseAudio);
        }

        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();
            }
            if (_player != null)
                _player.close();
        }

        ~ProcessIcon()
        {
            Dispose(false);
        }
        void MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                PlayPauseAudio();
            }
        }

        public void PlayPauseAudio()
        {

            try
            {
                if (_player.playState == WMPPlayState.wmppsPlaying)
                    _player.controls.pause();
                else
                    _player.controls.play();

            }
            catch (Exception ex)
            {
            }
        }
    }
}