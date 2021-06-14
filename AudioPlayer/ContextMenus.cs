using System;
using System.Windows.Forms;
using AudioPlayer;
using AudioPlayer.Properties;
using WMPLib;

namespace AudioPlayer
{
	class ContextMenus
	{
		bool isAboutLoaded = false;
		Action _playPauseAudio;

		public ContextMenuStrip Create(Action playPauseAudio)
		{
			_playPauseAudio = playPauseAudio;
			// Add the default menu options.
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item;
			ToolStripSeparator sep;

			item = new ToolStripMenuItem();
			item.Text = "Play";
			item.Click += new EventHandler(Play_Click);
			item.Image = Resources.play_48;
			menu.Items.Add(item);

			item = new ToolStripMenuItem();
			item.Text = "Pause";
			item.Click += new EventHandler(Pause_Click);
			item.Image = Resources.pause_48;
			menu.Items.Add(item);

			// About.
			item = new ToolStripMenuItem();
			item.Text = "About";
			item.Click += new EventHandler(About_Click);
			item.Image = Resources.About;
			menu.Items.Add(item);

			// Separator.
			sep = new ToolStripSeparator();
			menu.Items.Add(sep);

			// Exit.
			item = new ToolStripMenuItem();
			item.Text = "Exit";
			item.Click += new System.EventHandler(Exit_Click);
			item.Image = Resources.Exit;
			menu.Items.Add(item);

			return menu;
		}


        void Play_Click(object sender, EventArgs e)
		{

            try
            {
                _playPauseAudio();

            }
            catch (Exception ex)
            {
            }
        }
		void Pause_Click(object sender, EventArgs e)
		{

            try
            {
                _playPauseAudio();

            }
            catch (Exception ex)
            {
            }
        }

		void About_Click(object sender, EventArgs e)
		{
			if (!isAboutLoaded)
			{
				isAboutLoaded = true;
				new AboutBox().ShowDialog();
				isAboutLoaded = false;
			}
		}

		void Exit_Click(object sender, EventArgs e)
		{
			// Quit without further ado.
			Application.Exit();
		}
	}
}