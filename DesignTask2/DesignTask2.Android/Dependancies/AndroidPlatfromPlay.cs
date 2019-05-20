using System;
using Android.Media;
using DesignTask2.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(DesignTask2.Droid.Dependancy.AndroidPlatfromPlay))]
namespace DesignTask2.Droid.Dependancy
{
    public class AndroidPlatfromPlay : IPlatformPlay
    {
        public AndroidPlatfromPlay()
        {
                
        }
        public MediaPlayer _mediaPlayer;
        public bool PlayMusicFile()
        {
            try
            {
                _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.musicPo);
                _mediaPlayer.Start();
                _mediaPlayer.Wait();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            
        }

        public bool PauseMusicFile()
        {
            
            _mediaPlayer.Stop();
            return true;
        }
    }
}