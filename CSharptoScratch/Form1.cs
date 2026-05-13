namespace CSharptoScratch
{
    public partial class Form1 : Form
    {
        List<Sprite> sprites = new List<Sprite>();
        public Form1()
        {
            InitializeComponent();
            Sprite stage = new Sprite();
            stage.name = "stage";
            sprites.Add(stage);
            listBoxSprites.Items.Add("stage");
        }

        private void buttonAddSprite_Click(object sender, EventArgs e)
        {
            string text = textBoxName.Text;
            bool isDuplicate = false;
            if (!text.Equals(""))
            {
                for (int i = 0; i < sprites.Count; i++)
                {
                    if (text == sprites[i].name) isDuplicate = true;
                }

                if (!isDuplicate)
                {
                    Sprite sprite = new Sprite();
                    sprite.name = text;
                    sprites.Add(sprite);
                    listBoxSprites.Items.Add(sprite.name);
                    textBoxName.Clear();
                }
            }
        }

        private void listBoxSprites_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
