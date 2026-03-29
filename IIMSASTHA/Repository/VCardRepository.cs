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
            List<Vascard> vscrd = _context.vascards.ToList();
            return vscrd;
        }

        public Vascard GetVascardById(int id)
        {
            Vascard vcard = _context.vascards.FirstOrDefault(v=>v.VascardId == id);
            return vcard;
        }

        public Vascard Details(int id)
        {
            Vascard vcard = _context.vascards.FirstOrDefault(v => v.VascardId == id);
            return vcard;
        }

        public Vascard AddVascard(Vascard vcard)
        {
            _context.vascards.Add(vcard);
            _context.SaveChanges();
            return vcard;
        }

        public Vascard UpdateVascard(Vascard uvcard)
        {
            Vascard vscard = _context.vascards.FirstOrDefault(v=> v.VascardId == uvcard.VascardId);
            vscard.VascardId = uvcard.VascardId;
            vscard.Code = uvcard.Code;
            vscard.ImageUrl = uvcard.ImageUrl;
            vscard.SigImageUrl = uvcard.SigImageUrl;
            vscard.Name = uvcard.Name;
            vscard.Designation = uvcard.Designation;
            vscard.Blood = uvcard.Blood;
            vscard.JoiningDate = uvcard.JoiningDate;
            vscard.Status = uvcard.Status;
            _context.SaveChanges(true);
            return uvcard;
        }

        public void DeleteVascard(int id)
        {
            Vascard delvascard = _context.vascards.FirstOrDefault(v=> v.VascardId == id);
            
            if (delvascard !=null)
            {
                _context.vascards.Remove(delvascard);
                _context.SaveChanges();
            }
        }        
    }
}
