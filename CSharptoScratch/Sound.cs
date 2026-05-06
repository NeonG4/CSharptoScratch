using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class Sound
    {
        float volume = 100;
        public void PlayUntilDone(string sound) { }
        public void Start(string sound) { }
        public static void StopAllSounds() { }
        public void ChangePitch(float pitch) { }
        public void ChangePan(float pan) { }
        public void ChangeVolume(float volume) { } 
        public void SetPitch(float pitch) { }
        public void SetPan(float pan) { }
        public void SetVolume(float volume) { }
        public void ClearSoundEffects() { }
        public float GetVolume() { return volume; }
    }
}
