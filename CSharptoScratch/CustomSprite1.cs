namespace CSharptoScratch
{
    internal partial class Sprite: ISpriteClass, IGreenFlagClass
    {
        public void CustomMethod()
        {
            looks.Say("Hello, Scratch!");
        }
        public void CustomBlock()
        {
            looks.Hide();
            motion.Move(10);
            pen.PenDown();
        }
        public void GreenFlag()
        {
            while (true)
            { 
                CustomBlock();
                motion.TurnCCW(15);
                looks.NextCostume();
                if (motion.GetXPosition() > 100)
                {
                    break;
                }
            }
        }
    }
}
