namespace CSharptoScratch
{
    public partial class Form1 : Form
    {
        List<Sprite> sprites = new List<Sprite>();
        public Form1()
        {
            InitializeComponent(); ;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            timerTick.Enabled = true;

            Sprite sprite = new Sprite();
            sprite.Initialize(0, 0, 90, new Bitmap("images\\Dinosaur.png"), "Dinosaur", "Sprite1");
            groupBoxStage.Controls.Add(sprite.looks.picture);
            sprite.motion.PointInDirection(new ScratchValue(Random.Shared.Next(360)));
            sprite.looks.SetSize(new ScratchValue(10));
            sprites.Add(sprite);
        }
        private void timerTick_Tick(object sender, EventArgs e)
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.motion.Tick(33.33f);
                sprite.looks.SetLocation(new Point((int)(sprite.motion.xposition.valfloat + groupBoxStage.Location.X), (int)(sprite.motion.yposition.valfloat + groupBoxStage.Location.Y)));

                sprite.motion.Move(new ScratchValue(1));
            }
        }
    }
}
