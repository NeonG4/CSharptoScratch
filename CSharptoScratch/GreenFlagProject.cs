namespace CSharptoScratch
{
    public interface IGreenFlagProject
    {
        public abstract void WhenGreenFlagClicked();
    }
    internal class GreenFlagProject : IGreenFlagProject
    {
        required internal Sprite[] sprites { get; set; }
        required internal Sprite stage { get; set; }
        public GreenFlagProject(Sprite[] sprites, Sprite stage)
        {
            sprites = new Sprite[10];
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = new Sprite();
            }
        }
        public void WhenGreenFlagClicked()
        {
            sprites[0].motion.Move(10);
            sprites[0].sound.PlayUntilDone("meow");
        }
    }
}
