using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Manu
    {
        public int ManufacturerID { get; set; }
        public string ManuDesc { get; set; }
        public string ManuLoc { get; set; }
        public string contact { get; set; }
        //string desc,string location,string contact
    }
    public class Model
    {
        public int ModelID { get; set; }
        public int ManuID { get; set; }
        public string ModelDesc { get; set; }
    }
    public class Car
    {
        public int ManID { get; set; }
        public int ModelID { get; set; }
        public string CarDesc { get; set; }
        public string CarYear { get; set; }
        public float Price {get;set; }
    }
}
