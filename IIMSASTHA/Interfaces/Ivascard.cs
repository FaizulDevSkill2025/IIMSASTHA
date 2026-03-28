using IIMSASTHA.Models;

namespace IIMSASTHA.Interfaces
{
    public interface Ivascard
    {
        List<Vascard> GetAllVascard();

        Vascard GetVascardById(int id);

        Vascard AddVascard(Vascard vcard);

        Vascard UpdateVascard(Vascard uvcard);

        Vascard Details(int id);

        void DeleteVascard(int id);
    }
}
