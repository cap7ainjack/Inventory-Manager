namespace InventoryManager.Services
{
    using InventoryManager.Data.Interfaces;
    using InventoryManager.Data;

    public abstract class Service
    {
        protected IInventoryManagerData Data;

        public Service()
        {
            this.Data = new InventoryManagerData();
        }

        public Service(IInventoryManagerData data)
        {
            this.Data = data;
        }

    }
}
