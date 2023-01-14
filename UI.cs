using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;



namespace Wordle
{
    public partial class UI : Form
    {
        public int charSpot = 0;
        public int currRow = 0;
        public int n;
        public int wordNr = 573;
        bool firstTime = true;

        #region
        public string[] word = { "abuse", "adult", "agent", "anger", "apple", "award", "basis", "beach", "birth", "block", "blood", "board", "brain", "bread", "break", "brown", "buyer", "cause", "chain", "chair", "chest", "chief", "child", "china", "claim", "class", "clock", "coach", "coast", "court", "cover", "cream", "crime", "cross", "crowd", "crown", "cycle", "dance", "death", "depth", "doubt", "draft", "drama", "dream", "dress", "drink", "drive", "earth", "enemy", "entry", "error", "event", "faith", "fault", "field", "fight", "final", "floor", "focus", "force", "frame", "frank", "front", "fruit", "glass", "grant", "grass", "green", "group", "guide", "heart", "henry", "horse", "hotel", "house", "image", "index", "input", "issue", "japan", "jones", "judge", "knife", "laura", "layer", "level", "lewis", "light", "limit", "lunch", "major", "march", "match", "metal", "model", "money", "month", "motor", "mouth", "music", "night", "noise", "north", "novel", "nurse", "offer", "order", "other", "owner", "panel", "paper", "party", "peace", "peter", "phase", "phone", "piece", "pilot", "pitch", "place", "plane", "plant", "plate", "point", "pound", "power", "press", "price", "pride", "prize", "proof", "queen", "radio", "range", "ratio", "reply", "right", "river", "round", "route", "rugby", "scale", "scene", "scope", "score", "sense", "shape", "share", "sheep", "sheet", "shift", "shirt", "shock", "sight", "simon", "skill", "sleep", "smile", "smith", "smoke", "sound", "south", "space", "speed", "spite", "sport", "squad", "staff", "stage", "start", "state", "steam", "steel", "stock", "stone", "store", "study", "stuff", "style", "sugar", "table", "taste", "terry", "theme", "thing", "title", "total", "touch", "tower", "track", "trade", "train", "trend", "trial", "trust", "truth", "uncle", "union", "unity", "value", "video", "visit", "voice", "waste", "watch", "water", "while", "white", "whole", "woman", "world", "youth", "admit", "adopt", "agree", "allow", "alter", "apply", "argue", "arise", "avoid", "begin", "blame", "break", "bring", "build", "burst", "carry", "catch", "cause", "check", "claim", "clean", "clear", "climb", "close", "count", "cover", "cross", "dance", "doubt", "drink", "drive", "enjoy", "enter", "exist", "fight", "focus", "force", "guess", "imply", "issue", "judge", "laugh", "learn", "leave", "let’s", "limit", "marry", "match", "occur", "offer", "order", "phone", "place", "point", "press", "prove", "raise", "reach", "refer", "relax", "serve", "shall", "share", "shift", "shoot", "sleep", "solve", "sound", "speak", "spend", "split", "stand", "start", "state", "stick", "study", "teach", "thank", "think", "throw", "touch", "train", "treat", "trust", "visit", "voice", "waste", "watch", "worry", "would", "write", "above", "acute", "alive", "alone", "angry", "aware", "awful", "basic", "black", "blind", "brave", "brief", "broad", "brown", "cheap", "chief", "civil", "clean", "clear", "close", "crazy", "daily", "dirty", "early", "empty", "equal", "exact", "extra", "faint", "false", "fifth", "final", "first", "fresh", "front", "funny", "giant", "grand", "great", "green", "gross", "happy", "harsh", "heavy", "human", "ideal", "inner", "joint", "large", "legal", "level", "light", "local", "loose", "lucky", "magic", "major", "minor", "moral", "naked", "nasty", "naval", "other", "outer", "plain", "prime", "prior", "proud", "quick", "quiet", "rapid", "ready", "right", "roman", "rough", "round", "royal", "rural", "sharp", "sheer", "short", "silly", "sixth", "small", "smart", "solid", "sorry", "spare", "steep", "still", "super", "sweet", "thick", "third", "tight", "total", "tough", "upper", "upset", "urban", "usual", "vague", "valid", "vital", "white", "whole", "wrong", "young", "aback", "abaft", "aboon", "about", "above", "accel", "adown", "afoot", "afore", "afoul", "after", "again", "agape", "agogo", "agone", "ahead", "ahull", "alife", "alike", "aline", "aloft", "alone", "along", "aloof", "aloud", "amiss", "amply", "amuck", "apace", "apart", "aptly", "arear", "aside", "askew", "awful", "badly", "bally", "below", "canny", "cheap", "clean", "clear", "coyly", "daily", "dimly", "dirty", "ditto", "drily", "dryly", "dully", "early", "extra", "false", "fatly", "feyly", "first", "fitly", "forte", "forth", "fresh", "fully", "funny", "gaily", "gayly", "godly", "great", "haply", "heavy", "hella", "hence", "hotly", "icily", "infra", "intl.", "jildi", "jolly", "laxly", "lento", "light", "lowly", "madly", "maybe", "never", "newly", "nobly", "oddly", "often", "other", "ought", "party", "piano", "plain", "plonk", "plumb", "prior", "queer", "quick", "quite", "ramen", "rapid", "redly", "right", "rough", "round", "sadly", "secus", "selly", "sharp", "sheer", "shily", "short", "shyly", "silly", "since", "sleek", "slyly", "small", "sound", "spang", "srsly", "stark", "still", "stone", "stour", "super", "tally", "tanto", "there", "thick", "tight", "today", "tomoz", "truly", "twice", "under", "utter", "verry", "wanly", "wetly", "where", "wrong", "wryly", "abaft", "aboon", "about", "above", "adown", "afore", "after", "along", "aloof", "among", "below", "circa", "cross", "furth", "minus", "neath", "round", "since", "spite", "under", "until" };
        #endregion
        //initialize
        public UI()
        {
            InitializeComponent();
        }
        //load
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        //user input
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {   //allow only A->Z
            if (e.KeyValue <= 90 && e.KeyValue >= 65)
            {
                //check where and then enter the letter
                switch (charSpot)
                {
                    case 0:
                        button27.Focus();
                        button26.Text = e.KeyData.ToString();
                        charSpot = 1;
                        break;
                    case 1:
                        button28.Focus();
                        button27.Text = e.KeyData.ToString();
                        charSpot = 2;
                        break;
                    case 2:
                        button29.Focus();
                        button28.Text = e.KeyData.ToString();
                        charSpot = 3;
                        break;
                    case 3:
                        button30.Focus();
                        button29.Text = e.KeyData.ToString();
                        charSpot = 4;
                        break;
                    case 4:
                        button30.Focus();
                        button30.Text = e.KeyData.ToString();
                        charSpot = 5;
                        break;
                    default:
                        break;
                }
            }
            Button[] row6 = { button26, button27, button28, button29, button30 };

            //backspace last letter
            if (e.KeyCode == Keys.Back)
            {
                switch (charSpot)
                {
                    case 0:
                        row6[charSpot].Focus();
                        row6[charSpot].Text = " ";
                        charSpot = 0;
                        break;
                    case 1:
                        row6[charSpot - 1].Focus();
                        row6[charSpot - 1].Text = " ";
                        charSpot = 0;
                        break;
                    case 2:
                        row6[charSpot - 1].Focus();
                        row6[charSpot - 1].Text = " ";
                        charSpot = 1;
                        break;
                    case 3:
                        row6[charSpot - 1].Focus();
                        row6[charSpot - 1].Text = " ";
                        charSpot = 2;
                        break;
                    case 4:
                        row6[charSpot - 1].Focus();
                        row6[charSpot - 1].Text = " ";
                        charSpot = 3;
                        break;
                    case 5:
                        row6[charSpot - 1].Focus();
                        row6[charSpot - 1].Text = " ";
                        charSpot = 4;
                        break;
                    default:
                        break;
                }
            }
        }

        //enter key checks
        private void button30_Click(object sender, EventArgs e)
        {
            //create arrays for each row
            Button[] row1 = { button1, button2, button3, button4, button5 };
            Button[] row2 = { button6, button7, button8, button9, button10 };
            Button[] row3 = { button11, button12, button13, button14, button15 };
            Button[] row4 = { button16, button17, button18, button19, button20 };
            Button[] row5 = { button21, button22, button23, button24, button25 };
            Button[][] rows = { row1, row2, row3, row4, row5 };
            Button[] row6 = { button26, button27, button28, button29, button30 };

            //create array for the letters in the word
            string let1 = word[n].ToUpper().Substring(0, 1);
            string let2 = word[n].ToUpper().Substring(1, 1);
            string let3 = word[n].ToUpper().Substring(2, 1);
            string let4 = word[n].ToUpper().Substring(3, 1);
            string let5 = word[n].ToUpper().Substring(4, 1);
            string[] lett = { let1, let2, let3, let4, let5 };

            //check if entered word exists in library
            int wordExist = 0;
            string chosenWord = row6[0].Text.ToLower() + row6[1].Text.ToLower() + row6[2].Text.ToLower() + row6[3].Text.ToLower() + row6[4].Text.ToLower();
            for (int i = 0; i < wordNr; i++)
                if (chosenWord == word[i]) wordExist++;

            if (charSpot < 5)
            {
                MessageBox.Show("Please enter 5 letters.");
                //MessageBox.Show(chosenWord + " " + word[n]);
            }
            else
            {
                //pick random word
                if (firstTime)
                {
                    Random r = new Random();
                    n = r.Next(0, wordNr);
                    firstTime = false;
                }
                //Place letters and move to next row
                for (int i = 0; i < 5; i++)
                {
                    rows[currRow][i].Text = row6[i].Text;
                    row6[i].Text = "";
                }
                //Yellow = check if letter exists in word
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        if (rows[currRow][i].Text == lett[j]) rows[currRow][i].BackColor = Color.Yellow;
                //Green = check if letter is on that collumn
                for (int i = 0; i < 5; i++)
                    if (rows[currRow][i].Text == lett[i]) rows[currRow][i].BackColor = Color.LightGreen;

                if (currRow < 5) currRow++;
                charSpot = 0;

                if (rows[currRow - 1][0].BackColor == Color.LightGreen && rows[currRow - 1][1].BackColor == Color.LightGreen && rows[currRow - 1][2].BackColor == Color.LightGreen && rows[currRow - 1][3].BackColor == Color.LightGreen && rows[currRow - 1][4].BackColor == Color.LightGreen)
                {
                    MessageBox.Show("You won!");
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                        {
                            rows[i][j].BackColor = Color.WhiteSmoke;
                            rows[i][j].Text = "";
                        }
                    currRow = 0;
                    firstTime = true;
                }
                if (currRow == 5)
                {
                    MessageBox.Show("You lost. The word was " + word[n]);
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                        {
                            rows[i][j].BackColor = Color.WhiteSmoke;
                            rows[i][j].Text = "";
                        }
                    currRow = 0;
                    firstTime = true;
                }
            }
        }
        //help button
        private void button31_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" You have to guess a 5 letter word. \n Yellow means the letter is in the word. \n Green means the letter is on the specified collumn.");
        }
    }
}
