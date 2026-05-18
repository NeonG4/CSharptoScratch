using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class Looks
    {

        public ListDict costumes = new ListDict();
        public PictureBox picture { get; set; }

        public ScratchValue costumeNumber = new ScratchValue(1);
        public ScratchValue costumeName = new ScratchValue("costume1");
        public ScratchValue size = new ScratchValue(100);
        public bool visible = true;

        private float hueShift = 0; // between 0 and 1
        private float fishEye = 0; // between 0 and 1
        private float whirl = 0; // between 0 and 1
        private float pixelate = 0; // between 0 and 1
        private float mosaic = 0; // between 0 and 1
        private float brightness = 0; // between -1 and 1
        private float ghost = 0; // between 0 and 1
        public void Say(ScratchValue text) { }
        public void Say(ScratchValue text, ScratchValue time) { }
        public void Think(ScratchValue text) { }
        public void Think(ScratchValue text, ScratchValue time) { }
        public void SwitchCostume(ScratchValue costume) 
        {
            if (costume.isFloat)
            {
                if (costume.valfloat < 1 || costume.valfloat > costumes.Count())
                {
                    throw new Exception("Costume number out of range.");
                }
                costumeNumber = costume;
                costumeName = new ScratchValue(costumes.GetKey((int)costume.valfloat - 1));
            }
            else
            {
                if (!costumes.ContainsKey(costume.valstring))
                {
                    throw new Exception("Costume not found.");
                }
                costumeName = costume;
                costumeNumber = new ScratchValue(costumes.GetIndex(costume.valstring) + 1);
            }
            picture.Image = costumes[costume.valstring];
        }
        public void NextCostume() 
        {
            costumeNumber++; 
            if (costumeNumber.valfloat > costumes.Count())
            {
                costumeNumber = new ScratchValue(1);
            }
            costumeName = new ScratchValue(costumes.GetKey((int)costumeNumber.valfloat - 1));

            picture.Image = costumes[costumeName.valstring];
        }
        public void ChangeSize(ScratchValue percent) 
        { 
            this.size += percent; 
            picture.Size = new Size((int)(costumes[costumeName.valstring].Width * (size.valfloat / 100f)), (int)(costumes[costumeName.valstring].Height * (size.valfloat / 100f)));
        }
        public void SetSize(ScratchValue percent) 
        { 
            this.size = percent; 
            picture.Size = new Size((int)(costumes[costumeName.valstring].Width * (size.valfloat / 100f)), (int)(costumes[costumeName.valstring].Height * (size.valfloat / 100f)));
        }
        public void ChangeEffect(Effect effect, ScratchValue value)
        {
            if (!value.isFloat)
            {
                throw new Exception("Value must be a number.");
            }
            switch (effect)
            {
                case (Effect.Color):
                {
                    hueShift += value.valfloat / 200f;
                    break;       
                }
                case (Effect.Fisheye):
                {
                    fishEye += value.valfloat / 100f;
                    break;
                }
                case (Effect.Whirl):
                {
                    whirl += value.valfloat / 100f;
                    break;
                }
                case (Effect.Pixelate):
                {
                    pixelate += value.valfloat / 100f;
                    break;
                }
                case (Effect.Mosaic):
                {
                    mosaic += value.valfloat / 100f;
                    break;
                }
                case (Effect.Brightness):
                {
                    brightness += value.valfloat / 100f;
                    break;
                }
                case (Effect.Ghost):
                {
                    ghost += value.valfloat / 100f;
                    break;
                }
            }
        }
        public void SetEffect(Effect effect, ScratchValue value) 
        {
            if (!value.isFloat)
            {
                throw new Exception("Value must be a number.");
            }
            switch (effect)
            {
                case (Effect.Color):
                    {
                        hueShift = value.valfloat / 200f;
                        break;
                    }
                case (Effect.Fisheye):
                    {
                        fishEye = value.valfloat / 100f;
                        break;
                    }
                case (Effect.Whirl):
                    {
                        whirl = value.valfloat / 100f;
                        break;
                    }
                case (Effect.Pixelate):
                    {
                        pixelate = value.valfloat / 100f;
                        break;
                    }
                case (Effect.Mosaic):
                    {
                        mosaic = value.valfloat / 100f;
                        break;
                    }
                case (Effect.Brightness):
                    {
                        brightness = value.valfloat / 100f;
                        break;
                    }
                case (Effect.Ghost):
                    {
                        ghost = value.valfloat / 100f;
                        break;
                    }
            }
        }
        public void ClearEffects() 
        {
            hueShift = 0;
            fishEye = 0;
            whirl = 0;
            pixelate = 0;
            mosaic = 0;
            brightness = 0;
            ghost = 0;
        }
        public void Show() { visible = true; }
        public void Hide() { visible = false; }
        /// <summary>
        /// This is not an opcode. This is for the runtime to set the location of the sprite's PictureBox. It is not intended to be used by the user.
        /// </summary>
        /// <param name="location"></param>
        public void SetLocation(Point location)
        {
            picture.Location = location;
        }
        public void GoToLayer(Layer layer) { }
        public void GoToLayer(Layer layer, int number) { }
        public void Initialize(string costumeName, float x, float y)
        {
            this.costumeName = new ScratchValue(costumeName);
            this.costumeNumber = new ScratchValue(1);
            picture = new TransparentPictureBox();
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Enabled = true;
            picture.Visible = true;
            picture.Size = costumes[costumeName].Size;
            picture.Image = costumes[costumeName];
            picture.Location = new Point((int)x, (int)y);
        }
    }
    internal enum Layer
    {
        front,
        back,
        forward,
        backward
    }
    internal enum Effect
    {
        Color,
        Fisheye,
        Whirl,
        Pixelate,
        Mosaic,
        Brightness,
        Ghost
    }
}
