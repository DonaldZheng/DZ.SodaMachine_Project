using System.Collections.Generic;

namespace SodaMachineProj
{
    class SodaMachine
    {
        //Member Variables (Has A)
        private List<Coin> _register;
        private List<Can> _inventory;

        //Constructor (Spawner)
        public SodaMachine()
        {
            _register = new List<Coin>();
            _inventory = new List<Can>();
            FillInventory();
            FillRegister();
        }

        //Member Methods (Can Do)

        //A method to fill the sodamachines register with coin objects.
        public void FillRegister()
        {
            for (int i = 0; i <= 20; i++)
            {
                Quarter quarter = new Quarter();
                _register.Add(quarter);
            }
            for (int i = 0; i < 10; i++)
            {
                Dime dime = new Dime();
                _register.Add(dime);
            }
            for (int i = 0; i < 20; i++)
            {
                Nickel nickel = new Nickel();
                _register.Add(nickel);
            }
            for (int i = 0; i < 50; i++)
            {
                Penny penny = new Penny();
                _register.Add(penny);
            }

        }
        //A method to fill the sodamachines inventory with soda can objects.
        public void FillInventory()
        {
            for (int i = 0; i < 25; i++)
            {
                OrangeSoda orangeSoda = new OrangeSoda();
                _inventory.Add(orangeSoda);
            }
            for (int i = 0; i < 25; i++)
            {
                Cola cola = new Cola();
                _inventory.Add(cola);
            }
            for (int i = 0; i < 25; i++)
            {
                RootBeer rootBeer = new RootBeer();
                _inventory.Add(rootBeer);
            }

        }
        //Method to be called to start a transaction.
        //Takes in a customer which can be passed freely to which ever method needs it.
        public void BeginTransaction(Customer customer)
        {
            bool willProceed = UserInterface.DisplayWelcomeInstructions(_inventory);
            if (willProceed)
            {
                Transaction(customer);
            }
        }

        //This is the main transaction logic think of it like "runGame".  This is where the user will be prompted for the desired soda.
        //grab the desired soda from the inventory.
        //get payment from the user.
        //pass payment to the calculate transaction method to finish up the transaction based on the results.
        private void Transaction(Customer customer)
        {
            // need to get a soda from inentory, that method needs a string it will return a call
            string customerCanSelection = "";
            Can canChoice = GetSodaFromInventory(customerCanSelection);
            customer.GatherCoinsFromWallet(canChoice);
        }
        //Gets a soda from the inventory based on the name of the soda.
        private Can GetSodaFromInventory(string nameOfSoda)
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                Can can = _inventory[i];
                if (can.Name.Equals(nameOfSoda))
                {
                    return can;
                }
            }
            return null;

        }

        //This is the main method for calculating the result of the transaction.
        //It takes in the payment from the customer, the soda object they selected, and the customer who is purchasing the soda.
        //This is the method that will determine the following:
        //If the payment is greater than the price of the soda, and if the sodamachine has enough change to return: Despense soda, and change to the customer.
        //If the payment is greater than the cost of the soda, but the machine does not have ample change: Despense payment back to the customer.
        //If the payment is exact to the cost of the soda:  Despense soda.
        //If the payment does not meet the cost of the soda: despense payment back to the customer.
        private void CalculateTransaction(List<Coin> payment, Can chosenSoda, Customer customer)
        {

        }
        //Takes in the value of the amount of change needed.
        //Attempts to gather all the required coins from the sodamachine's register to make change.
        //Returns the list of coins as change to despense.
        //If the change cannot be made, return null.
        private List<Coin> GatherChange(double changeValue)
        {
            //while 
            // if change value > .25
            // remove quarter from the register
            // add it to temp list 
            // minus changeValue - .25

            // do you have --> register has coin ("quarter") REGISTERHASCOIN
            // register // GetCoinFromRegister
            // input = input - 0.25

            List<Coin> change = new List<Coin>();
            Coin vendingChange = new Coin();

            // *****ask about this tommorrow******

            while (changeValue > 0)
            {
                if (changeValue > .25)
                {
                    // if register has coin quarter then we go into if statement

                    if (RegisterHasCoin("Quarter"))
                    {
                        Coin coin = GetCoinFromRegister("Quarter");
                        change.Add(coin);
                        changeValue = changeValue - .25;
                    }
                }
            }

            while (changeValue > 0)
            {
                if (changeValue > .10)
                {
                    if (RegisterHasCoin("Dime"))
                    {
                        Coin coin = GetCoinFromRegister("Dime");
                        change.Add(coin);
                        changeValue = changeValue - .10;
                    }
                }
            }
            while (changeValue > 0)
            {
                if (changeValue > .05)
                {
                    if (RegisterHasCoin("Nickel"))
                    {
                        Coin coin = GetCoinFromRegister("Nickel");
                        change.Add(coin);
                        changeValue = changeValue - .05;
                    }
                }
                while (changeValue > 0)
                {
                    if (changeValue > .01)
                    {
                        if (RegisterHasCoin("Penny"))
                        {
                            Coin coin = GetCoinFromRegister("Penny");
                            change.Add(coin);
                            changeValue = changeValue - .01;
                        }
                    }
                }

            }
        }
        //Reusable method to check if the register has a coin of that name.
        //If it does have one, return true.  Else, false.
        private bool RegisterHasCoin(string name)
        {
            foreach (Coin coin in _register)
            {
                if (name == coin.Name)
                {
                    return true;
                }
            }
            return false;
        }
        //Reusable method to return a coin from the register.
        //Returns null if no coin can be found of that name.
        private Coin GetCoinFromRegister(string name)
        {
            foreach (Coin coinName in _register)
            {
                if (name == coinName.Name)
                {
                    _register.Remove(coinName);
                    return coinName;
                }
            }
            return null;
        }

        //Takes in the total payment amount and the price of can to return the change amount.
        private double DetermineChange(double totalPayment, double canPrice)
        {
            double totalChange = totalPayment - canPrice;
            return totalChange;


            //method might return 0/negative value come back when we call it 

        }
        //Takes in a list of coins to return the total value of the coins as a double.
        private double TotalCoinValue(List<Coin> payment)
        {
            double paymentAdded = 0;
            foreach (Coin coin in payment)
            {
                paymentAdded += coin.Value;
            }
            return paymentAdded;


            //payment is a list of coins
            //we want to look at all the coins in that list and add their values together into a new variable
            //then return that variable

        }
        //Puts a list of coins into the soda machines register.
        // add coins to register 
        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
            foreach (Coin coin in coins)
            {
                _register.Add(coin);
            }
        }
    }
}

