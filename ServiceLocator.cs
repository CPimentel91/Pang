using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangTutorial
{
    class ServiceLocator
    {
        public static IAudioProvider GetAudio()
        {
            return _audioProvider;
        }

        public static void RegisterServiceLocator(IAudioProvider provider)
        {
            _audioProvider = provider;
        }

        private static IAudioProvider _audioProvider = null;
    }
}
