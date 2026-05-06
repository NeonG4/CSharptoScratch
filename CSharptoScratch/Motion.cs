using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class Motion
    {
        float xpos = 0, ypos = 0, direction = 0;
        public void Move(float steps) { }
        public void TurnCCW(float steps) { }
        public void TurnCW(float steps) { }
        public void PointInDirection(float direction) { }
        public void GoTo(float x, float y) { }
        public void Glide(float time, float x, float y) { }
        public void Point(float dir) { }
        public void Point(float x, float y) { }
        public void Change(Axis axis, float steps) { }
        public void IfOnEdgeBounce() { }
        public void SetRotationStyle(RotationStyle style) { }
        public float GetXPosition() { return xpos; }
        public float GetYPosition() { return ypos; }
        public float GetDirection() { return direction; }

    }
    internal enum RotationStyle
    {
        allAround,
        leftRight,
        dontRotate,
    }
    internal enum Axis
    {
        x,
        y,
    }
}
