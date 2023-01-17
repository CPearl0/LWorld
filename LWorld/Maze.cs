using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWorld
{
    internal class Maze : Map
    {
        public Maze(int width, int height, int seed = 0) : base(width, height, seed) { }
        public override void GenerateWorld()
        {
            base.GenerateWorld();
            int dstx = 3 * width / 4 + random.Next(width - 3 * width / 4 - 2);
            int dsty = 3 * height / 4 + random.Next(height - 3 * height / 4 - 2);
            MazeGenerator generator = new(width - 2, height - 2, random, (0, 0), (dstx, dsty));
            generator.Generate();
            for (int i = 1; i < width - 1; ++i)
                for (int j = 1; j < height - 1; ++j)
                    map[i, j] = generator[i - 1, j - 1] ? Block.Space : Block.Wall;
            map[dstx + 1, dsty + 1] = Block.Dest;
        }
        public class MazeGenerator
        {
            private int width, height;
            private Random random;
            private (int, int) src, dst;
            private struct Block
            {
                public (int, int) parent = (-1, -1);
                public bool isSpace = false;
                public Block() { }
            }
            private Block[,] blocks;
            public MazeGenerator(int width, int height, Random random, (int, int) src, (int, int) dst)
            {
                this.width = width;
                this.height = height;
                this.random = random;
                this.src = src;
                this.dst = dst;
                this.blocks = new Block[width, height];
                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                        blocks[i, j] = new Block();
                blocks[src.Item1, src.Item2].isSpace = blocks[dst.Item1, dst.Item2].isSpace = true;
            }
            public void Generate()
            {
                int x, y;
                while (!isJoint(src, dst))
                {
                    do
                    {
                        x = random.Next(width);
                        y = random.Next(height);
                    } while (blocks[x, y].isSpace);
                    List<(int, int)> around = new();
                    if (x > 0) around.Add((x - 1, y));
                    if (x < width - 1) around.Add((x + 1, y));
                    if (y > 0) around.Add((x, y - 1));
                    if (y < height - 1) around.Add((x, y + 1));

                    var firstroot = FindRoot(around[0]);
                    bool bAdd = false;
                    foreach (var pos in around)
                        if (FindRoot(pos) == firstroot)
                        {
                            if (bAdd)
                            {
                                bAdd = false;
                                break;
                            }
                            else
                                bAdd = true;
                        }
                    if (!bAdd) continue;

                    blocks[x, y].isSpace = true;
                    var join = (int nx, int ny) =>
                    {
                        if (blocks[nx, ny].isSpace)
                            Join((x, y), (nx, ny));
                    };
                    foreach (var pos in around)
                        join(pos.Item1, pos.Item2);
                }
                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                        if (!isJoint(src, (i, j)))
                            blocks[i, j].isSpace = false;
            }
            public bool this[int x, int y] => blocks[x, y].isSpace;
            private (int, int) FindRoot((int, int)p)
            {
                var par = blocks[p.Item1, p.Item2].parent;
                if (par == (-1, -1))
                    return p;
                else
                    return blocks[p.Item1, p.Item2].parent = FindRoot(par);
            }
            private void Join((int, int)p1, (int, int)p2)
            {
                if (isJoint(p1, p2)) return;
                var p1root = FindRoot(p1);
                blocks[p1root.Item1, p1root.Item2].parent = p2;
            }
            private bool isJoint((int, int) p1, (int, int) p2) => FindRoot(p1) == FindRoot(p2);
        }
    }
}
