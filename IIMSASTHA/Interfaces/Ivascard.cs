using IIMSASTHA.Models;

namespace IIMSASTHA.Interfaces
{
    public interface Ivascard
    {
        List<Vascard> GetAllVascard();

        Vascard GetVascardById();

        Vascard AddVascard(Vascard vcard);

        Vascard UpdateVascard(Vascard uvcard);

        Vascard Details(int id);

        void DeleteVascard(int id);
    }
}
