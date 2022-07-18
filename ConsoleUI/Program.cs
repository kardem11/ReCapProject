using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach ( var car in result.Data)
                {
                    Console.WriteLine(car.Id + "/" + car.Description + "/" + car.ModelYear);
                }
            }
            
            
        }
    }
}