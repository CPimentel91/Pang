using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;

namespace PangTutorial
{
    abstract class IAudioProvider
    {
        public abstract void PlaySound(string filename);
        public abstract void PlaySong(string filename, bool looping);
        public abstract void StopAllSounds();

        public abstract bool IsSoundPlaying();
        public abstract bool IsSongPlaying();
    }
}
