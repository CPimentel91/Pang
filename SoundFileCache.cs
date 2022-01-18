using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;


namespace PangTutorial
{
    class SoundFileCache
    {
        public SoundFileCache()
        {

        }

        public Sound GetSound(string soundName)
        {
            var soundIter = _sounds[soundName];

            if(soundIter == _sounds.Last().Value)
            {
                SoundBuffer soundBuffer = new SoundBuffer(soundName);
                if (soundBuffer == null)
                {
                    Console.WriteLine("from getsound SoundFileCache, sound buffer failed to load from file :)");
                }


                _sounds.Add(soundName, soundBuffer);
                Sound sound = new Sound();
                sound.SoundBuffer = soundBuffer;
                return sound;
            }
            else
            {
                Sound sound = new Sound();
                sound.SoundBuffer = soundIter;
                return sound;
            }


        }

        public Music GetMusic(string soundName)
        {
            Music songIter = _music[soundName];

            if (songIter == _music.Last().Value)
            {
                Music song = new Music(soundName);
                if (song == null)
                {
                    Console.WriteLine("from getmusic SoundFileCache, sound buffer failed to load from file :)");
                }
                else
                {
                    _music.Add(soundName, song);
                    return songIter;
                }

            }
            else
            {
                return songIter;
            }

            return songIter;
        }


        private Dictionary<string, SoundBuffer> _sounds;
        private Dictionary<string, Music> _music;
    }
}
