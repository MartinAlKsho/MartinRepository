
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
// My Name is Martin
namespace JoePets
{
    class VM : INotifyPropertyChanged
    {
        const decimal CRICKETS = 24.75m;
        const decimal WORMS = 44.99m;
        const decimal MICE = 19.99m;
        const decimal TAX = 0.15m;
        const decimal ADDITIONFEES = 15m;
        const string OUTPUT_FILE = "output.txt";

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void onChange([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private int cricketsAmount;
        public int CricketsAmount { get { return cricketsAmount; } set { cricketsAmount = value; onChange(); } }

        private decimal cricketFees;
        public decimal CricketFees { get { return cricketFees; } set { cricketFees = value; onChange(); } }

        private int wormsAmount;
        public int WormsAmount { get { return wormsAmount; } set { wormsAmount = value; onChange(); } }

        private decimal wormFees;
        public decimal WormsFees { get { return wormFees; } set { wormFees = value; onChange(); } }

        private int miceAmount;
        public int MiceAmount { get { return miceAmount; } set { miceAmount = value; onChange(); } }
        private decimal micFees;
        public decimal MiceFees { get { return micFees; } set { micFees = value; onChange(); } }
        private decimal tax;
        public decimal Tax { get { return tax; } set { tax = value; onChange(); } }

        private bool addition;
        public bool Addition { get { return addition; } set { addition = value; onChange(); } }

        private decimal addfees;
        public decimal AddFees { get { return addfees; } set { addfees = value; onChange(); } }

        private decimal total;
        public decimal Total { get { return total; } set { total = value; onChange(); } }

        public void Calc()
        {

            CricketFees = CricketsAmount * CRICKETS;
            WormsFees = WormsAmount * WORMS;
            MiceFees = MiceAmount * MICE;
            decimal result = CricketFees + WormsFees + MiceFees;
            Tax = result * TAX;
            if (addition == true)
            {
                AddFees = ADDITIONFEES;
                Total = result + Tax + AddFees;
            }

            else
            {
                AddFees = 0;
                Total = result + Tax;
            }
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PetsShop");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string file = System.IO.Path.Combine(path, OUTPUT_FILE);

            File.AppendAllText(file, "Cricket"+"\t" +"\t"+ "CricketsAmount"+ CricketsAmount + "=" + CricketFees + "\r\n" + "Worms" +"\n\t"+ WormsAmount + "=" + WormsFees);



        }

    }
}
