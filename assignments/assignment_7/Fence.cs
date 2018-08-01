using System;
namespace comp3350_a7
{
    public class Fence : IEntity
    {
        protected Pasture pasture;

        public Fence(Pasture pasture)
        {
            this.pasture = pasture;
        }

        char IEntity.GetSymbol()
        {
            return('F');
        }

        bool IEntity.IsCompatible(IEntity otherEntity)
        {
            return false;
        }

        void IEntity.Tick()
        {
        }

        public void kill() {

        }
    }
}
