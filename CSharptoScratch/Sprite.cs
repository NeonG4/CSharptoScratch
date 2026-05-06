using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal interface IGreenFlagClass
    {
        public abstract void GreenFlag();
    }
    internal interface ISpriteClass
    {
        public Motion motion { get; }
        public Looks looks { get; }
        public Sound sound { get; }
        public Sensing sensing { get; }
        public Pen pen { get; }
    }
    internal partial class Sprite : ISpriteClass
    {
        public string name { get; set; }
        public Motion motion { get; private set; }
        public Looks looks { get; private set; }
        public Sound sound { get; private set; }
        public Sensing sensing { get; private set; }
        public Pen pen { get; private set; }
        public Sprite()
        {
            motion = new Motion();
            looks = new Looks();
            sound = new Sound();
            sensing = new Sensing();
            pen = new Pen();
        }
    }
}
