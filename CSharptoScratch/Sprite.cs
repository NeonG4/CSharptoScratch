using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class Sprite
    {
        public Motion motion = new Motion();
        public Looks looks = new Looks();
        public Sound sound = new Sound();
        public Sensing sensing = new Sensing();
        public Pen pen = new Pen();
    }
}
