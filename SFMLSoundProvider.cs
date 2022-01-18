using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;

namespace PangTutorial
{
    class SFMLSoundProvider : IAudioProvider 
    {
        public SFMLSoundProvider()
        {
            //_sound.Volume = 100.0f;
        }

        override public void PlaySound(string filename)
        {
            int availChannel = -1;
            
            for (int i = 0; i < Max_Sound_Channels; i++)
            {
                if (_currentSounds[i].Status != SoundStatus.Playing)
                {
                    availChannel = i;
                    break;
                }
            }

            if (availChannel != -1)
            {
                _currentSounds[availChannel] = _soundFileCache.GetSound(filename);
                _currentSounds[availChannel].Play();
            }
            else
            {
                Console.WriteLine("file not found we arent doing anything but the sound isnt going to play :)");
            }


        }

        override public  void PlaySong(string filename, bool looping)
        {
            Music currentSong = new Music(filename);
            
            if (currentSong == null)
            {
                return;
            }

            if (_currentSongName != "")
            {
                Music priorSong = _soundFileCache.GetMusic(_currentSongName);
                if (priorSong.Status != SoundStatus.Stopped)
                {
                    priorSong.Stop();
                }

            }
            else
            {
                Console.WriteLine("play song failed succesfully :)");
            }

            currentSong.Loop = looping;
            currentSong.Play();
        }

        override public void StopAllSounds()
        {
            for (int i = 0; i < Max_Sound_Channels; i++)
            {
                _currentSounds[i].Stop();
            }

            if (_currentSongName != string.Empty)
            {
                Music currentSong = _soundFileCache.GetMusic(_currentSongName);

                if (currentSong.Status == SoundStatus.Playing)
                {
                    currentSong.Stop();
                }
            }
        }

        override public bool IsSoundPlaying()
        {
            for (int i = 0; i < Max_Sound_Channels; i++)
            {
                if(_currentSounds[i].Status == SoundStatus.Playing)
                {
                    return true;
                }
               
            }
            return false;
        }

        override public bool IsSongPlaying()
        {
            Music currentSong = _soundFileCache.GetMusic(_currentSongName);
            if (_currentSongName != string.Empty)
            {
                return _soundFileCache.GetMusic(_currentSongName).Status == SoundStatus.Playing;
            }
            return false;
        }

        private static int Max_Sound_Channels = 5;
        SoundFileCache _soundFileCache;

        private SoundBuffer _soundBuffer = new SoundBuffer(@"D:\PICTURES\big ass\moan2.flac");
        string _currentSongName;
        private Sound[] _currentSounds = new Sound[Max_Sound_Channels];
    }
}
