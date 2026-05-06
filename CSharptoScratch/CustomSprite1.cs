using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal partial class Sprite: ISpriteClass, IGreenFlagClass
    {
        public void CustomMethod()
        {

        }
        public void CustomBlock()
        {
            looks.Hide();
            motion.Move(10);
        }
        public void GreenFlag()
        {
            CustomBlock();
        }
    }
}
