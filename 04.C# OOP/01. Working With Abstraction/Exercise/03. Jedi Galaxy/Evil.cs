﻿namespace JediGalaxy
{
    public class Evil
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public void UpdateCoordinates(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
