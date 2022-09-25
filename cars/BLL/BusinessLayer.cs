using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class BusinessLayer
    {
        DataAccessLayer dal = new DataAccessLayer();
 
        public int AddManufacturer(Manu man)
        {
            return dal.AddManufacturer(man);
        }
        public DataTable ListManufacturer(Manu man)
        {
            return dal.ListManufacturer(man);
        }
        public DataTable UpdateManufacturer(Manu man)
        {
            return dal.UpdateManufacturer(man);
        }
        public int AddModel(Model mod)
        {
            return dal.AddModel(mod);
        }
        public DataTable ListModel(Model mod)
        {
            return dal.ListModel(mod);
        }
        public DataTable UpdateModel(Model mod)
        {
            return dal.UpdateModel(mod);
        }
        public int AddCars(Car car)
        {
            return dal.AddCars(car);
        }
        public DataTable ListCars(Car car)
        {
            return dal.ListCars(car);
        }
        public DataTable UpdateCars(Car car)
        {
            return dal.UpdateCars(car);
        }
    }
}
