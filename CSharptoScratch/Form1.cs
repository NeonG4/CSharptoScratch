namespace CSharptoScratch
{
    public partial class Form1 : Form
    {
        List<Sprite> sprites = new List<Sprite>();
        ParsedScratchProject project = new ParsedScratchProject();
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
            if (listBoxSprites.SelectedIndex == -1)
            {
                groupBoxCode.Enabled = false;
                richTextBoxCode.Clear();
            }
            else
            {
                groupBoxCode.Enabled = true;
                labelCurrentSprite.Text = sprites[listBoxSprites.SelectedIndex].name;
                richTextBoxCode.Text = CSParser.BuildCSharpCode(sprites[listBoxSprites.SelectedIndex].name, project);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CSParser.UpdateParsedProject(project, richTextBoxCode.Text);
            listBoxSprites.SelectedIndex = -1;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            richTextBoxCode.Clear();
            listBoxSprites.SelectedIndex = -1;
            labelCurrentSprite.Text = "-";
        }
    }
}
