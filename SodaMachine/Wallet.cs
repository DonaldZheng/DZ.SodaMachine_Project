using System.Collections.Generic;

namespace SodaMachineProj
{
    class Wallet
    {
        //Member Variables (Has A)
        public List<Coin> Coins;
        //Constructor (Spawner)
        public Wallet()
        {
            Coins = new List<Coin>();
            FillRegister();
        }
        //Member Methods (Can Do)
        //Fills wallet with starting money
        private void FillRegister()
        {
            for (int i = 0; i <= 10; i++)
            {
                Quarter quarter = new Quarter();
                Coins.Add(quarter);
            }
            for (int i = 0; i <= 10; i++)
            {
                Dime dime = new Dime();
                Coins.Add(dime);
            }
            for (int i = 0; i <= 10; i++)
            {
                Nickel nickel = new Nickel();
                Coins.Add(nickel);
            }
            for (int i = 0; i <= 10; i++)
            {
                Penny penny = new Penny();
                Coins.Add(penny);
            }
        }
    }
}
