using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS247_WK7_iLAB_HALEY
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationUtilities.DisplayApplicationInformation();

            Racer[] r = new Racer[2];

            r[0] = new HotRod();
            r[1] = new StreetTuner();

            for (int i = 0; i < r.Length; i++)
            {
                ApplicationUtilities.DisplayDivider("Racer Information");
                RacerInfo.CollectRacerInformation(r[i]);
                if (r[i] is HotRod)
                {
                    RacerInfo.CollectHotRodInformation((HotRod)r[i]);
                }
                else if (r[i] is StreetTuner)
                {
                    RacerInfo.CollectStreetTunerInformation((StreetTuner)r[i]);
                }
                RacerInfo.DisplayRacerInformation(r[i]);

                ApplicationUtilities.PauseExecution();
            }
            ApplicationUtilities.TerminateApplication();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS247_WK7_iLAB_HALEY
{
    class Engine
    {
        private const int CYLINDERS = 4;
        private const int HORSEPOWER = 100;

        private int cylinders;
        private int horsepower;

        public Engine()
        {
            cylinders = CYLINDERS;
            horsepower = HORSEPOWER;
        }

        public int Cylinders
        {
            get { return cylinders; }
            set
            {
                if (value < 4)
                    cylinders = 4;
                else if (value > 12)
                    cylinders = 12;
                else cylinders = value;
            }
        }

        public int Horsepower
        {
            get { return horsepower; }
            set
            {
                if (value < 1)
                    horsepower = 1;
                else if (value > 2000)
                    horsepower = 2000;
                else horsepower = value;
            }
        }

        public override string ToString()
        {
            string str;
            str = "Cylinders: " + cylinders + " " + "\n";
            str += "Horsepower: " + horsepower + "\n";


            return str;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS247_WK7_iLAB_HALEY
{
    abstract class Racer
    {
        private string name;
        private int speed;
        private Engine engine;

        public Racer() { }

        public Racer(string name, int speed, Engine engine)
        {
            this.name = name;
            this.speed = speed;
            this.engine = engine;
        }

        public abstract bool IsDead();

        public string Name
        {
            get
            { return name; }
            set
            {

                if (String.IsNullOrEmpty(value))
                {
                    value = "N/A";

                }
                else
                {
                    name = value;
                }

            }
        }

        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 0)
                    speed = 0;
                else if (value > 999)
                    speed = 999;
                else speed = value;
            }

        }

        public Engine Eng
        {
            get { return engine; }
            set
            {
                if (value != null) 
                {
                    engine = value;

                }
                else
                {
                    engine = new Engine();
                }
            }
        }

        public override string ToString()
        {
            string str;
            str = "Name: " + Name + " " + "\n";
            str += "Speed: " + Speed + "\n";
            str += "Engine" + Eng.ToString() + "\n";

            return str;



        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS247_WK7_iLAB_HALEY
{
    class RacerInfo
    {
        public static void CollectRacerInformation(Racer racer)
        {
            racer.Name = InputUtilities.getStringInputValue("Racer's Name");
            racer.Speed = InputUtilities.getIntegerInputValue("Racer's Speed");
            racer.Eng.Cylinders = InputUtilities.getIntegerInputValue("Cylinders");
            racer.Eng.Horsepower = InputUtilities.getIntegerInputValue("Horsepower");
        }

        

        public static void CollectHotRodInformation(HotRod racer)
        {
            bool blow = racer.blower;
            Console.WriteLine("Blower? (0 for yes or 1 for no): " + blow);
        }

        public static void CollectStreetTunerInformation(StreetTuner racer)
        {
            bool nit = racer.nitro; 
            Console.WriteLine("Nitrous? (0 for yes or 1 for no): " + nit);
        }

        public static void DisplayRacerInformation(Racer racer)
        {
            Console.WriteLine(racer.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS247_WK7_iLAB_HALEY
{
    class StreetTuner : Racer
    {
        private const bool NITRO = false;

        public bool nitro;

        public StreetTuner()
        {
            nitro = NITRO;
        }

        public StreetTuner(string name, int speed, Engine engine, bool nitro)
        {
            this.Name = name;
            this.Speed = speed;
            this.Eng = engine;
            this.nitro = nitro;
        }

        public override bool IsDead()
        {
            Random rnd = new Random();
            rnd.NextDouble();
            bool dead = false;


            if (Speed > 50 && rnd.NextDouble() > 0.6)
                if (Eng.Horsepower < 300 && Nitro() == true)
                    dead = false;
                else dead = true;
            else if (Speed > 100 && rnd.NextDouble() > 0.4)
                if (Eng.Horsepower >= 300 && Nitro() == true)
                    dead = true;
                else
                    dead = false;
            return dead;
        }

        public bool Nitro()
        {
            int a = 0;

            if (nitro == true)
            {
                a = 1;
            }
            
            if (a == 1)
            {
                return true;
            }
                else
                {
                    return false;
                }
        }







        public override string ToString()
        {
            string str;


            ApplicationUtilities.DisplayDivider("Racer Information");
            str = "Name: " + Name + " " + "\n";
            str += "Speed: " + Speed + "\n";
            str += "Engine" + Eng.ToString() + "\n";
            str += "Blower?: " + Nitro() + "/n";
            str += "Dead? : " + IsDead() + "/n";



            return str;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS247_WK7_iLAB_HALEY
{
    class HotRod : Racer
    {
        private const bool BLOWER = false;
        
        public bool blower;

        public HotRod()
        {
            blower = BLOWER;
        }

        public HotRod(string name, int speed, Engine engine, bool blower)
        {
            this.Name = name;
            this.Speed = speed;
            this.Eng = engine;
            this.blower = blower;
        }

        public override bool IsDead()
        {
            Random rnd = new Random();
            rnd.NextDouble();
            bool dead = false;



            if (Speed > 50 && rnd.NextDouble() > 0.6)
                if (Eng.Horsepower < 300 && Blower() == true)
                    dead = false;
                else dead = true;
            else if (Speed > 100 && rnd.NextDouble() > 0.4)
                if (Eng.Horsepower >= 300 && Blower() == true)
                    dead = true;
                else
                    dead = false;
            return dead;
        }

        public bool Blower()
        {
            int a = 0;

            if (blower == true)
            {
                a = 1;
            }

            if (a == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string str;

            
            ApplicationUtilities.DisplayDivider("Racer Information");
            str = "Name: " + Name + " " + "\n";
            str += "Speed: " + Speed + "\n";
            str += "Engine" + Eng.ToString() + "\n";
            str += "Blower?: " + Blower() + "/n";
            str += "Dead? : " + IsDead() + "/n";



            return str;
        }


    }
}
