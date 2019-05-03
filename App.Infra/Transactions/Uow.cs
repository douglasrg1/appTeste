using App.Infra.Context;

namespace App.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly AppDataContext _context;
        public Uow(AppDataContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            
        }
    }
}