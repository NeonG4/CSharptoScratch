using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class Pen
    {
        public void EraseAll() { }
        public void Stamp() { }
        public void PenUp() { }
        public void PenDown() { }
        public void SetPenColor(string hexadecimal) { }
        public void SetPenColor(int r, int g, int b) { }
        public void SetPenColor(float r, float g, float b) { }
        public void ChangePen(PenProperty property, float value) { }
        public void SetPen(PenProperty property, float value) { }
        public void ChangePenSize(float size) { }
        public void SetPenSize(float size) { }  
    }
    public enum PenProperty
    {
        color,
        saturation,
        brightness,
        transparency,
    }
}
