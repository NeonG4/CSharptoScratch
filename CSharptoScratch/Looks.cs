using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class Looks
    {
        int costumeNumber = 1;
        string costumeName = "costume1";
        static int backdropNumber = 1;
        static string backdropName = "backdrop1";
        float size = 100;
        public void Say(string text) { }
        public void Say(string text, float time) { }
        public void Think(string text) { }
        public void Think(string text, float time) { }
        public void SwitchCostume(string costume) { }
        public void NextCostume() { }
        public static void SwitchBackdrop(string backdrop) { }
        public static void NextBackdrop() { } 
        public void ChangeSize(float percent) { }
        public void SetSize(float percent) { }
        public void ChangeEffect(Effect effect, float value) { }
        public void SetEffect(Effect effect, float value) { }
        public void ClearEffects() { }
        public void Show() { }
        public void Hide() { }
        public void GoToLayer(Layer layer) { }
        public void GoToLayer(Layer layer, int number) { }
        public int GetCostumeNumber() { return costumeNumber; }
        public string GetCostumeName() { return costumeName; }
        public static int GetBackdropNumber() { return backdropNumber; }
        public static string GetBackdropName() { return backdropName; }
        public float GetSize() { return size; } 
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
