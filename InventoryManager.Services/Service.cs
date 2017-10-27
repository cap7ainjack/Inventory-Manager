namespace InventoryManager.Services
{
    using InventoryManager.Data;

    public abstract class Service
    {
        public Service()
        {
            this.Context = new InventoryManagerContext();
        }

        protected InventoryManagerContext Context { get; }
    }
}
