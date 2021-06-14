
# Simple Audio Stream Player
Author: David Horth
Date: 6/14/2021
Release: 1.0

## Purpose

The motivation behind this simple tray icon was to create an easy way to play an audio stream on my windows devices.  A bit of background, most of the TV’s in our house have a PC attached.  I also have a server that is streaming music 24 x 7.  My goal was a quick an easy way to play and pause music on any PC in the house.  So I created this simple app that uses Windows Media Player COM object to play the audio stream coming from the server.

## Configuration

On my server I am running [Rocket Broadcaster](https://www.rocketbroadcaster.com/) to capture audio playing on the server and stream it out as an IceCast 2 audio stream.  This works great, just play your favorite audio provider on the server (music, audio books, conferencing, etc).  Then any client (Windows, Linux, MacOS, Android, etc) can play that stream in the standard web browser.  Adjust the source on the server and all the clients automatically pick up the new source.  What I wanted was a quick way to play and pause the source without having to navigate a web page.  Using a tray icon, and a global hot-key my windows box can now quickly play and pause the audio.

Look at Constants.cs to configure AudioPlayer to your requirements.  I have my server stream defined, and Ctrl+Alt+P as the hot key.

## Application

DotNet 5.0 windows forms/WPF application.

I use windows forms for the about box and context menu.  I need to add WPF support to get full access to System.Windows.Input and KeyGestureConverter class.

On startup the application will add a tray icon to the windows system tray.

### Operations

- Left click on the tray icon, toggles between Play and Pause
- Right click context menu
-- Play
-- Pause
-- Exit
-  Global hotkey Ctrl+Alt+P toggles between Play and Pause

## Possible Enhancements

- Right now I am using Windows Media Player (WMP) to play the audio stream.  So far this has been very reliable, however WMP uses a small cache.  So when you go room to room each PC may be at a different part of the stream.  Ideally, these devices would be synced so there would not be any noticeable difference.  For now I can live with WMP, but if there is any interest I will work on a solution to sync the devices.

- Add a settings form to configure the audio stream and the hot key