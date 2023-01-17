using System.Diagnostics;

namespace LWorld
{
    public partial class MainForm : Form
    {
        // 118 * 74
        private const int width = 118, height = 74;
        private Map world = new Maze(width, height);
        private (int, int) pos = (1, 1);
        private bool[,] Mask = new bool[width, height];
        private Stopwatch watch = new();
        private bool winned = false;
        public MainForm()
        {
            InitializeComponent();
            for (int i = 1; i < width - 1; ++i)
                for (int j = 1; j < height - 1; ++j)
                    Mask[i, j] = true;
            Mask[1, 1] = Mask[1, 2] = Mask[2, 1] = Mask[2, 2] = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            world.GenerateWorld();
        }

        public const int BLOCK_LENGTH = 10;
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brushWall = new(Color.Gray), brushSpace = new(Color.White),
                brushDest = new(Color.Red), brushPlayer = new(Color.Blue),
                brushMask = new(Color.Black);
            Rectangle r = new(0, 0, BLOCK_LENGTH, BLOCK_LENGTH);
            var choosebrush = (int i, int j) =>
            {
                if (world[i, j] == Map.Block.Dest) return brushDest;
                if (Mask[i, j]) return brushMask;
                return world[i, j] switch
                {
                    Map.Block.Space => brushSpace,
                    Map.Block.Wall => brushWall,
                    _ => throw new Exception()
                };
            };
            int offx = labelMap.Location.X, offy = labelMap.Location.Y;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    r.X = i * BLOCK_LENGTH + offx;
                    r.Y = j * BLOCK_LENGTH + offy;
                    g.FillRectangle(choosebrush(i, j), r);
                }
            r.X = pos.Item1 * BLOCK_LENGTH + offx;
            r.Y = pos.Item2 * BLOCK_LENGTH + offy;
            g.FillEllipse(brushPlayer, r);
        }

        private void NewGame(int seed = 0)
        {
            world = new Maze(width, height, seed);
            world.GenerateWorld();

            for (int i = 1; i < width - 1; ++i)
                for (int j = 1; j < height - 1; ++j)
                    Mask[i, j] = true;
            Mask[1, 1] = Mask[1, 2] = Mask[2, 1] = Mask[2, 2] = false;

            pos = (1, 1);
            winned = false;
            watch.Reset();
            Invalidate();
        }
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(world.Seed);
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!watch.IsRunning && !winned)
                watch.Start();
            (int, int) offset;
            switch (e.KeyChar)
            {
                case 'w':
                    offset = (0, -1);
                    break;
                case 's':
                    offset = (0, 1);
                    break;
                case 'a':
                    offset = (-1, 0);
                    break;
                case 'd':
                    offset = (1, 0);
                    break;
                default: return;
            }
            var aim = world[pos.Item1 + offset.Item1, pos.Item2 + offset.Item2];
            if (aim != Map.Block.Wall)
            {
                int offx = labelMap.Location.X, offy = labelMap.Location.Y;
                Rectangle r1 = new(pos.Item1 * BLOCK_LENGTH + offx, pos.Item2 * BLOCK_LENGTH + offy, BLOCK_LENGTH, BLOCK_LENGTH);
                pos.Item1 += offset.Item1;
                pos.Item2 += offset.Item2;
                for (int i = -1; i <= 1; ++i)
                    for (int j = -1; j <= 1; ++j)
                        Mask[pos.Item1 + i, pos.Item2 + j] = false;
                Rectangle r2 = new((pos.Item1 - 1) * BLOCK_LENGTH + offx, (pos.Item2 - 1) * BLOCK_LENGTH + offy, BLOCK_LENGTH * 3, BLOCK_LENGTH * 3);
                Region region = new(r1);
                region.Union(r2);
                Invalidate(region);
            }
            if (aim == Map.Block.Dest && !winned)
            {
                watch.Stop();
                winned = true;
                MessageBox.Show(string.Format("你在{0:hh\\:mm\\:ss}内通关了!", watch.Elapsed), "恭喜!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}