using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class Motion
    {

        public ScratchValue xposition = new ScratchValue(0);
        public ScratchValue yposition = new ScratchValue(0);
        public ScratchValue direction = new ScratchValue(90);
        ScratchValue glideTime;
        ScratchValue totalTime;
        ScratchValue glidePositionXDelta;
        ScratchValue glidePositionYDelta;
        bool gliding = false;
        RotationStyle rotationStyle = RotationStyle.allAround;

        public void Tick(float tps)
        {
            if (gliding)
            {
                xposition += glidePositionXDelta;
                yposition += glidePositionYDelta;
                glideTime += tps;
                if ((glideTime >= totalTime).valfloat == 1)
                {
                    gliding = false;
                }
            }
        }
        public void Move(ScratchValue steps) 
        {
            if (steps.isFloat)
            {
                xposition.valfloat += (float)(Math.Cos((direction.valfloat - 90) * Math.PI / 180) * steps.valfloat);
                yposition.valfloat += (float)(Math.Sin((direction.valfloat - 90)* Math.PI / 180) * steps.valfloat);
            }
            else
            {
                throw new Exception("NaN... (It's a string)");
            }
        }
        public void TurnCCW(ScratchValue steps) 
        {
            if (steps.isFloat)
            {
                direction.valfloat += steps.valfloat;
                direction.valfloat %= 360;

            }
            else
            {
                throw new Exception("NaN... (It's a string)");
            }
        }
        public void TurnCW(ScratchValue steps) 
        {
            if (steps.isFloat)
            {
                direction.valfloat -= steps.valfloat;
                direction.valfloat %= 360;
            }
            else
            {
                throw new Exception("NaN... (It's a string)");
            }
        }
        public void PointInDirection(ScratchValue direction) 
        {
            if (direction.isFloat)
            {
                this.direction.valfloat = direction.valfloat;
                this.direction.valfloat %= 360;

            }
            else
            {
                throw new Exception("NaN... (It's a string)");
            }
        }
        public void GoTo(ScratchValue x, ScratchValue y) 
        {
            if (x.isFloat && y.isFloat)
            {
                xposition.valfloat = x.valfloat;
                yposition.valfloat = y.valfloat;
            }
            else
            {
                throw new Exception("NaN... (It's a string)");
            }
        }
        public void Glide(ScratchValue time, ScratchValue x, ScratchValue y) 
        {
            if (time.isFloat && x.isFloat && y.isFloat)
            {
                totalTime = time;
                glideTime = new ScratchValue(0);
                glidePositionXDelta = (x - xposition) / time;
                glidePositionYDelta = (y - yposition) / time;
            }
            else
            {
                throw new Exception("NaN... (It's a string)");
            }
        }
        public void Point(ScratchValue dir) 
        {
            direction = dir;
        }
        public void Change(Axis axis, ScratchValue steps) 
        { 
            if (axis == Axis.x)
            {
                xposition += steps;
            }
            else
            {
                yposition += steps;
            }
        }
        public void IfOnEdgeBounce() 
        {
            // TODO: Implement
            // use a sprite bounding box, and check if the bounding box overlaps the edge of the screen. If it does, reflect the direction across the normal of the edge.
        }
        public void SetRotationStyle(RotationStyle style) 
        {
            rotationStyle = style;
        }

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
