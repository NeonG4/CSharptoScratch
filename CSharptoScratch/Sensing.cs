using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class Sensing
    {
        public bool Touching(string obj) { return false; }
        public bool TouchingColor(string color) { return false; }
        public bool ColorTouchingColor(string color1, string color2) { return false; }
        public float DistanceTo(string obj) { return 0; }
        public void AskAndWait(string question) { }
        public string Answer() { return ""; }
        public bool KeyPressed(Key key) { return false; }
        public bool MouseDown() { return false; }
        public float MouseX() { return 0; }
        public float MouseY() { return 0; }
        public void SetDragMode(DragMode mode) { } 
        public float Loudness() { return 0; }
        public static float Timer() { return 0; }
        public static void ResetTimer() { }
        public static float VarOfType(string obj, string var) { return 0; }
        public static float GetCurrent(TimeSpan timespan) { return 0; }
        public static float GetDaysSince2000() { return 0; }
        public bool IsConnected() { return false; }
        public static string Username() { return ""; }

    }
    enum TimeSpan
    {
        year, 
        month, 
        date, 
        dayofweek,
        hour,
        minute,
        second
    }
    enum Key
    {
        up,
        down,
        left,
        right,
        space,
        any,
        a, b, c, d, e,
        f, g, h, i, j,
        k, l, m, n, o,
        p, q, r, s, t,
        u, v, w, x, y,
        z,
    }
    enum DragMode
    {
        draggable,
        notdraggable,
    }
}
