using System;
using System.Collections.Generic;
using comp3350_a7;

namespace comp3350_a7
{
    public class Tiger : IEntity
    {
        protected Pasture pasture;
        private int ttl, curr_ttl, ttm, curr_ttm, ttr, curr_ttr;
        private bool isAlive = true;

        public Tiger(Pasture pasture, int ttl, int ttm, int ttr)
        {
            this.pasture = pasture;
            this.ttl = ttl;
            this.ttm = ttm;
            this.ttr = ttr;
            this.curr_ttl = ttl;
            this.curr_ttm = ttm;
            this.curr_ttr = ttr;

        }

        char IEntity.GetSymbol()
        {
            return('T');
        }

        bool IEntity.IsCompatible(IEntity otherEntity)
        {
            if (otherEntity.GetSymbol().Equals('g') || otherEntity.GetSymbol().Equals('C'))
                return(true);
            return(false);
        }

        void IEntity.Tick()
        {
            if (isAlive) {
                if (curr_ttm == 0) {
                    move();
                } else if (curr_ttr == 0) {
                    grow();
                } else {
                    eat(pasture.GetPosition(this));
                    curr_ttm--;
                    curr_ttr--;
                }

                if (curr_ttl == 0) {
                    pasture.RemoveEntity(this);
                }
            }
        }

        void move() {
            Random random = new Random();

            ISet<Point> neighbors = pasture.GetFreeNeighbors(this);
            int num = random.Next(0, neighbors.Count);
            int count = 0;

            foreach(Point p in neighbors) {
                count++;
                if (count == num) {
                    pasture.MoveEntity(this, p);
                    eat(p);
                }
            }
            curr_ttm = ttm;
        }

        void eat(Point p) {
            IList<IEntity> things = pasture.GetEntitiesAt(p);
            foreach (IEntity i in things) {
                if ('C'.Equals(i.GetSymbol())) {
                    pasture.RemoveEntity(i);
                    i.kill();
                    curr_ttl = ttl;
                    return;
                }
            }
            curr_ttl--;
        }

        void grow() {
            Random random = new Random();

            ISet<Point> neighbors = pasture.GetFreeNeighbors(this);
            int num = random.Next(0, neighbors.Count);
            int count = 0;

            foreach(Point p in neighbors) {
                count++;
                if (count == num) {
                    pasture.AddEntity(new Tiger(pasture, ttl, ttm, ttr), p);
                }
            }
            curr_ttr = ttr;
        }

        public void kill() {
            isAlive = false;
        }
    }
}
