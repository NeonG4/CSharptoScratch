using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class ScratchValue
    {
        public float valfloat;
        public string valstring;
        public bool isFloat;
        public ScratchValue(float val)
        {
            valfloat = val;
            valstring = val.ToString();
            isFloat = true;
        }

        public ScratchValue(string val) { valstring = val; isFloat = false; }
        public static ScratchValue Join(ScratchValue val1, ScratchValue val2)
        {
            return new ScratchValue(val1.valstring + val2.valstring);
        }
        public static ScratchValue operator +(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat + val2.valfloat);
            else return Join(val1, val2);
        }
        public static ScratchValue operator -(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat - val2.valfloat);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator *(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat * val2.valfloat);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator /(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat / val2.valfloat);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator %(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat % val2.valfloat);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator >(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat > val2.valfloat ? 1 : 0);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator <(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat < val2.valfloat ? 1 : 0);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator ==(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat == val2.valfloat ? 1 : 0);
            else return new ScratchValue(val1.valstring == val2.valstring ? 1 : 0);
        }
        public static ScratchValue operator !=(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat != val2.valfloat ? 1 : 0);
            else return new ScratchValue(val1.valstring != val2.valstring ? 1 : 0);
        }
        public static ScratchValue operator >=(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat >= val2.valfloat ? 1 : 0);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator <=(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val1.valfloat <= val2.valfloat ? 1 : 0);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator !(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue(val.valfloat == 0 ? 1 : 0);
            else throw new InvalidCastException("Boolean problems...");
        }
        public static ScratchValue operator &(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue((val1.valfloat != 0 && val2.valfloat != 0) ? 1 : 0);
            else throw new InvalidCastException("Boolean problems...");
        }
        public static ScratchValue operator |(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue((val1.valfloat != 0 || val2.valfloat != 0) ? 1 : 0);
            else throw new InvalidCastException("Boolean problems...");
        }
        /// <summary>
        /// The letter of the string val2 at the index of val1 (1-based index)
        /// </summary>
        /// <param name="val1">The index (1-based)</param>
        /// <param name="val2">The string</param>
        /// <returns>The letter at the specified index</returns>
        /// <exception cref="InvalidCastException"></exception>
        public static ScratchValue LetterOf(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue(val2.valstring[(int)val1.valfloat - 1].ToString());
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue LengthOf(ScratchValue val)
        {
            return new ScratchValue(val.valstring.Length);
        }
        public static ScratchValue Contains(ScratchValue val1, ScratchValue val2)
        {
            return new ScratchValue(val1.valstring.Contains(val2.valstring) ? 1 : 0);
        }
        public static ScratchValue Round(ScratchValue val1, ScratchValue val2)
        {
            if (val1.isFloat && val2.isFloat) return new ScratchValue((float)Math.Round(val1.valfloat, (int)val2.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Abs(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue(Math.Abs(val.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Sqrt(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Sqrt(val.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Sin(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Sin(val.valfloat * Math.PI / 180));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Cos(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Cos(val.valfloat * Math.PI / 180));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Tan(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Tan(val.valfloat * Math.PI / 180));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Acos(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)(Math.Acos(val.valfloat) * 180 / Math.PI));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Asin(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)(Math.Asin(val.valfloat) * 180 / Math.PI));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Atan(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)(Math.Atan(val.valfloat) * 180 / Math.PI));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Floor(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Floor(val.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Ceiling(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Ceiling(val.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Ln(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Log(val.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Log10(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Log10(val.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue PowerE(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Pow(2.71828183, val.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue Power10(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue((float)Math.Pow(10, val.valfloat));
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator +(ScratchValue val, float add)
        {
            if (val.isFloat) return new ScratchValue(val.valfloat + add);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator -(ScratchValue val, float sub)
        {
            if (val.isFloat) return new ScratchValue(val.valfloat - sub);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator *(ScratchValue val, float mul)
        {
            if (val.isFloat) return new ScratchValue(val.valfloat * mul);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator /(ScratchValue val, float div)
        {
            if (val.isFloat) return new ScratchValue(val.valfloat / div);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator %(ScratchValue val, float mod)
        {
            if (val.isFloat) return new ScratchValue(val.valfloat % mod);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
        public static ScratchValue operator ++(ScratchValue val)
        {
            if (val.isFloat) return new ScratchValue(val.valfloat + 1);
            else throw new InvalidCastException("Scratch Typing Issue (sorry folks)");
        }
    }
}