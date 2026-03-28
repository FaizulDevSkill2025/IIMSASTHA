using IIMSASTHA.Data;
using IIMSASTHA.Interfaces;
using IIMSASTHA.Models;

namespace IIMSASTHA.Repository
{
    public class VCardRepository : Ivascard
    {
        private readonly ApplicationDbContext _context;

        public VCardRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<Vascard> GetAllVascard()
        {
            throw new NotImplementedException();
        }

        public Vascard GetVascardById()
        {
            throw new NotImplementedException();
        }

        public Vascard Details(int id)
        {
            throw new NotImplementedException();
        }

        public Vascard AddVascard(Vascard vcard)
        {
            throw new NotImplementedException();
        }

        public Vascard UpdateVascard(Vascard uvcard)
        {
            throw new NotImplementedException();
        }

        public void DeleteVascard(int id)
        {
            throw new NotImplementedException();
        }        
    }
}
