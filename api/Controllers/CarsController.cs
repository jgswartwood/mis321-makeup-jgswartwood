using System.Diagnostics.CodeAnalysis;
using api.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        // GET: api/<cars>
        [HttpGet]
        public List<Car> Get()
        {
            CarUtility utility = new CarUtility();
            return utility.GetAllCars();  
        }

        // GET api/<cars>/5
        [HttpGet("{id}")]
        public Car Get(int carID)
        {
            CarUtility utility = new CarUtility();
            List<Car> myCars = utility.GetAllCars();
            foreach(Car c in myCars) {
                if(c.CarID == carID) {
                    return c;
                }
            }
            return new Car();
        }

        // POST api/<cars>
        [HttpPost]
        public void Post(Car myCar)
        {
            CarUtility utility = new CarUtility();
            utility.AddCar(myCar);
        }

        // PUT api/<cars>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car myCar)
        {
            CarUtility utility = new CarUtility();
            utility.UpdateCar(myCar);
        }

        // DELETE api/<cars>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CarUtility utility = new CarUtility();
            utility.DeleteCar(id);
        }
    }
}
