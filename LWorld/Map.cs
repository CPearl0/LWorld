using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWorld
{
    internal class Map
    {
        public enum Block { Space, Wall, Dest }

        // The size of the map
        protected int width, height;
        public int Width => width;
        public int Height => height;

        // The seed of the map
        protected int seed;
        public int Seed => seed;

        protected Block[,] map;
        public Block this[int x, int y] => map[x, y];
        public Map(int width, int height, int seed = 0)
        {
            this.width = width;
            this.height = height;
            if (width < 16 || height < 16)
                throw new Exception("地图尺寸过小!");
            map = new Block[width, height];
            if (seed == 0)
            {
                Random r = new();
                this.seed = r.Next();
            }
            else this.seed = seed;
        }

        protected Random? random = null;
        public virtual void GenerateWorld()
        {
            if (random != null)
            {
                Debug.WriteLine("重复生成世界.");
                return;
            }
            random = new(seed);

            for (int x = 0; x < width; ++x)
                map[x, 0] = map[x, height - 1] = Block.Wall;
            for (int y = 0; y < height; ++y)
                map[0, y] = map[width - 1, y] = Block.Wall;
        }
    }
}
