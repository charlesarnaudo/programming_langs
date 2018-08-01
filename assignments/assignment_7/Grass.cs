using System;
using System.Collections.Generic;
using comp3350_a7;
namespace comp3350_a7
{
    public class Grass : IEntity
    {
        protected Pasture pasture;
        private int ttg = 45;
        private int curr_ttg = 45;
        public bool isAlive = true;

        public Grass(Pasture pasture)
        {
            this.pasture = pasture;
        }

        char IEntity.GetSymbol()
        {
            return('g');
        }

        bool IEntity.IsCompatible(IEntity otherEntity)
        {
            if (otherEntity.GetSymbol().Equals('C') || otherEntity.GetSymbol().Equals('T')) {
                return (true);
            } else {
                return (false);
            }
        }

        void IEntity.Tick()
        {
            if (isAlive) {
                if (curr_ttg == 0) {
                    grow();
                } else {
                    curr_ttg--;
                }
            }
        }

        void grow() {
            Random random = new Random();

            if (this != null) {
                ISet<Point> neighbors = pasture.GetFreeNeighbors(this);
                int num = random.Next(0, neighbors.Count);
                int count = 0;

                foreach(Point p in neighbors) {
                    count++;
                    if (count == num) {
                        pasture.AddEntity(new Grass(pasture), p);
                    }
                }
                curr_ttg = ttg;
            }
        }

        public void kill() {
            isAlive = false;
        }
    }
}
