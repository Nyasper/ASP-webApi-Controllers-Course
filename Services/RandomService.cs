namespace Proyecto_Backend_Csharp.Services
{
    public class RandomService : IRandomService
    {
        private readonly int _Value;

        public int Value
        {
            get { return _Value; }
        }
        public RandomService() 
        { 
            _Value = new Random().Next(1000);
        }
    }
}
