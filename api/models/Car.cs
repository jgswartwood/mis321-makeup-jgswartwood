using System.Dynamic;

namespace api.models
{
    public class Car
    {
        public int CarID {get; set;}
        public string MakeAndModel {get; set;}
        public int Mileage {get; set;}
        public string CarDate {get; set;}
        public bool Hold {get; set;}
        public bool Deleted {get; set;}
    }
}