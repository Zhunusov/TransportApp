using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.BLL.DTO;

namespace TransportApp.BLL.Interfaces
{
    public interface ICargoService
    {
        IEnumerable<CargoViewDTO> GetCargoes();
        IEnumerable<CargoViewDTO> GetCargoes(string countryArr, string countryDest, 
            string regArr, string regDest, string cityArr, string cityDest,
            DateTime? dateStart, DateTime? dateFin, decimal weightMin, decimal weightMax,
            int capMin, int capMax);
        void Dispose();
    }
}
