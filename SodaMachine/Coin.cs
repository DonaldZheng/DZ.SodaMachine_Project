namespace SodaMachineProj
{
    class Coin
    {
        //Member Variables (Has A)
        protected double value;
        public string Name;
        //public List<string> coinValue;

        public double Value
        {
            get
            {
                return value;
            }


        }
        //Constructor (Spawner)
        public Coin()
        {
            //added new, if not right delete:
            //coinValue = new List<string>();
            //coinValue.Add("Quarter");
            //coinValue.Add("Dime");
            //coinValue.Add("Nickel");
            //coinValue.Add("Penny");

        }

        //Member Methods (Can Do)
    }
}
