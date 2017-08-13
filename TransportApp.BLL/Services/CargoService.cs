using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.BLL.DTO;
using TransportApp.BLL.Interfaces;
using TransportApp.DAL.Interfaces;
using AutoMapper;
using TransportApp.DAL.Entities;

namespace TransportApp.BLL.Services
{
    public class CargoService :ICargoService
    {
        private IUnitOfWork Database { get; set; }
        public CargoService (IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<CargoViewDTO> GetCargoes()
        {
            List<CargoViewDTO> cargoesView = new List<CargoViewDTO>();
            var cargoes = Database.Cargoes.GetAll();
            if(cargoes.Count() > 0)
            {
                foreach(var cargo in cargoes)
                {
                    CargoViewDTO cView = new CargoViewDTO();
                    cView.UserIdNumber = cargo.UserId;
                    cView.CargoIdNumber = cargo.CargoId;
                    cView.CityArrivalId = cargo.CityArrivalId;
                    cView.CityShipmentId = cargo.CityShipmentId;
                    cView.IsCargoDeactivated = cargo.IsCargoDeactivated;

                    UserBizInformation u = Database.UserBizInfo.Get(cargo.UserId);
                    cView.UserBizName = u.BizName;

                    City cityArr = Database.Cities.Get(cargo.CityArrivalId);
                    City citySh = Database.Cities.Get(cargo.CityShipmentId);
                    Country countryArr = Database.Countries.Get(cityArr.CountryId);
                    Country countrySh = Database.Countries.Get(citySh.CountryId);
                    Region regionSh = Database.Regions.Get(citySh.RegionId);
                    Region regionArr = Database.Regions.Get(cityArr.RegionId);

                    cView.CityArrivalName = cityArr.CityName;
                    cView.CityShipmentName = citySh.CityName;
                    cView.CountryShipmentISOCode2 = countrySh.ISOCode2;
                    cView.CountryArrivalISOCode2 = countryArr.ISOCode2;
                    cView.RegionShipmentName = regionSh.RegionName;
                    cView.RegionArrivalName = regionArr.RegionName;                

                    CargoDate date = Database.CargoDates.Get(cargo.CargoId);
                    if(date != null)
                    {
                        cView.DateOfFormation = date.DateOfFormation;
                        cView.ShipmentDateStart = date.ShipmentDateStart;
                        cView.ShipmentDateFinished = date.ShipmentDateFinished;
                    }
                    CargoInfo info = Database.CargoInfoes.Get(cargo.CargoId);
                    if(info != null)
                    {
                        cView.AdditionalInfo = info.AdditionalInfo;
                        cView.ADR = info.ADR;
                        cView.CargoFrequency = info.CargoFrequency;
                        cView.Height = info.Height;
                        cView.Length = info.Length;
                        cView.Name = info.Name;
                        cView.RequiredCountOfTransport = info.RequiredCountOfTransport;
                        cView.SizeMax = info.SizeMax;
                        cView.SizeMin = info.SizeMin;
                        cView.WeightMax = info.WeightMax;
                        cView.WeightMin = info.WeightMin;
                        cView.Width = info.Width;                        
                    }

                    CargoPayment payments = Database.CargoPayments.Get(cargo.CargoId);
                    if (payments != null)
                    {
                        cView.CostUnit = payments.CostUnit;
                        cView.CurrencyId = payments.CurrencyId;
                        cView.IsCostKnown = payments.IsCostKnown;
                        cView.IsVATApplicable = payments.IsVATApplicable;
                        cView.PaymentMethod = payments.PaymentMethod;
                        cView.PrePayment = payments.PrePayment;
                        cView.SumOfPayment = payments.SumOfPayment;
                        cView.TimeOfPayment = payments.TimeOfPayment;

                        Currency cur = Database.Currencies.Get(payments.CurrencyId);
                        cView.CurrencySymbol = cur.ISOCode3;
                    }

                    var phones = Database.Phones.Find(f => f.UserId == cargo.UserId);
                    if (phones.Count() > 0)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Phone, PhoneDTO>());
                        cView.PhonesDTO = Mapper.Map<IEnumerable<Phone>, List<PhoneDTO>>(phones);                        
                    }
                    
                    cargoesView.Add(cView);
                }
                return cargoesView;
            }
            return null;
        }

        public IEnumerable<CargoViewDTO> GetCargoes(string countryArrM = null, string countryDestM = null,
            string regArrM = null, string regDestM = null, string cityArrM = null, string cityDestM = null,
            DateTime? dateStart = null, DateTime? dateFin = null, decimal weightMin = 0, decimal weightMax = 0,
            int capMin =0, int capMax = 0)
        {
            List<CargoViewDTO> cargoesView = new List<CargoViewDTO>();
            Region regionCargoArrM, regionCargoDestM = new Region();
            City cityCargoArrM, cityCargoDestM = new City();

            if (countryArrM != null && countryDestM!=null)
            {
                Country countryCargoArrM = Database.Countries.Find(c => c.CountryName == countryArrM).FirstOrDefault();
                Country countryCargoDestM = Database.Countries.Find(c => c.CountryName == countryDestM).FirstOrDefault();
               
                var cargoes = Database.Cargoes.GetAll();
                if (cargoes.Count() > 0)
                {
                    foreach (var cargo in cargoes)
                    {
                        CargoViewDTO cView = new CargoViewDTO();
                        cView.UserIdNumber = cargo.UserId;
                        cView.CargoIdNumber = cargo.CargoId;
                        cView.CityArrivalId = cargo.CityArrivalId;
                        cView.CityShipmentId = cargo.CityShipmentId;
                        cView.IsCargoDeactivated = cargo.IsCargoDeactivated;

                        UserBizInformation u = Database.UserBizInfo.Get(cargo.UserId);
                        cView.UserBizName = u.BizName;

                        City cityArr = Database.Cities.Get(cargo.CityArrivalId);
                        if (cityDestM != null)
                        {
                            cityCargoDestM = Database.Cities.Find(c => c.CityName == cityDestM).FirstOrDefault();
                            if (cityArr.CityId != cityCargoDestM.CityId)
                                continue;
                        }
                        City citySh = Database.Cities.Get(cargo.CityShipmentId);
                        if (cityArrM != null)
                        {
                            cityCargoArrM = Database.Cities.Find(c => c.CityName == cityArrM).FirstOrDefault();
                            if (citySh.CityId != cityCargoArrM.CityId)
                                continue;
                        }
                        Country countryArr = Database.Countries.Get(cityArr.CountryId);
                        if (countryArr.CountryId != countryCargoDestM.CountryId)
                            continue;

                        Country countrySh = Database.Countries.Get(citySh.CountryId);
                        if (countrySh.CountryId != countryCargoArrM.CountryId)
                            continue;

                        Region regionSh = Database.Regions.Get(citySh.RegionId);
                        if (regArrM != null)
                        {
                            regionCargoArrM = Database.Regions.Find(r => r.RegionName == regArrM).FirstOrDefault();
                            if (regionSh.RegionId != regionCargoArrM.RegionId)
                                continue;
                        }
                        Region regionArr = Database.Regions.Get(cityArr.RegionId);
                        if (regDestM != null)
                        {
                            regionCargoDestM = Database.Regions.Find(r => r.RegionName == regDestM).FirstOrDefault();
                            if (regionArr.RegionId != regionCargoDestM.RegionId)
                                continue;
                        }
                            

                        cView.CityArrivalName = cityArr.CityName;
                        cView.CityShipmentName = citySh.CityName;
                        cView.CountryShipmentISOCode2 = countrySh.ISOCode2;
                        cView.CountryArrivalISOCode2 = countryArr.ISOCode2;
                        cView.RegionShipmentName = regionSh.RegionName;
                        cView.RegionArrivalName = regionArr.RegionName;

                        CargoDate date = Database.CargoDates.Get(cargo.CargoId);
                        if (date != null)
                        {
                            cView.DateOfFormation = date.DateOfFormation;
                            cView.ShipmentDateStart = date.ShipmentDateStart;
                            cView.ShipmentDateFinished = date.ShipmentDateFinished;
                        }
                        if (Convert.ToDateTime(dateStart).Year>2000)
                        {
                            if (DateTime.Compare((DateTime)date.ShipmentDateStart, (DateTime)dateStart) < 0||
                                DateTime.Compare((DateTime)date.ShipmentDateFinished, (DateTime)dateStart) < 0)
                                continue;
                        }
                        if (Convert.ToDateTime(dateFin).Year>2000)
                        {
                            if (DateTime.Compare((DateTime)date.ShipmentDateFinished, (DateTime)dateFin) > 0)
                                continue;
                        }
                        CargoInfo info = Database.CargoInfoes.Get(cargo.CargoId);
                        if (info != null)
                        {
                            cView.AdditionalInfo = info.AdditionalInfo;
                            cView.ADR = info.ADR;
                            cView.CargoFrequency = info.CargoFrequency;
                            cView.Height = info.Height;
                            cView.Length = info.Length;
                            cView.Name = info.Name;
                            cView.RequiredCountOfTransport = info.RequiredCountOfTransport;
                            cView.SizeMax = info.SizeMax;
                            cView.SizeMin = info.SizeMin;
                            cView.WeightMax = info.WeightMax;
                            cView.WeightMin = info.WeightMin;
                            cView.Width = info.Width;
                        }
                        if (info.WeightMin < weightMin || info.SizeMin < capMin)
                            continue;
                        if (info.WeightMax > weightMax && weightMax != 0)
                            continue;
                        if (info.SizeMax > capMax && capMax != 0)
                            continue;

                        CargoPayment payments = Database.CargoPayments.Get(cargo.CargoId);
                        if (payments != null)
                        {
                            cView.CostUnit = payments.CostUnit;
                            cView.CurrencyId = payments.CurrencyId;
                            cView.IsCostKnown = payments.IsCostKnown;
                            cView.IsVATApplicable = payments.IsVATApplicable;
                            cView.PaymentMethod = payments.PaymentMethod;
                            cView.PrePayment = payments.PrePayment;
                            cView.SumOfPayment = payments.SumOfPayment;
                            cView.TimeOfPayment = payments.TimeOfPayment;

                            Currency cur = Database.Currencies.Get(payments.CurrencyId);
                            cView.CurrencySymbol = cur.ISOCode3;
                        }

                        var phones = Database.Phones.Find(f => f.UserId == cargo.UserId);
                        if (phones.Count() > 0)
                        {
                            Mapper.Initialize(cfg => cfg.CreateMap<Phone, PhoneDTO>());
                            cView.PhonesDTO = Mapper.Map<IEnumerable<Phone>, List<PhoneDTO>>(phones);
                        }

                        cargoesView.Add(cView);
                    }
                    return cargoesView;
                }

                
            }
            return null;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
