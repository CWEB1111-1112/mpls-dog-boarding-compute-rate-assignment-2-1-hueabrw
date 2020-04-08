using System;

namespace mpls_dog_boarding_compute_rate_assignment_2_1_hueabrw
{
    class Program
    {
        public const float FLAT_RATE = 75.00f;
        public const float A_RATE = 169.00f;
        public const float C_RATE = 112.00f;
        static void Main(string[] args)
        {
            Welcome();
            int days = PromptDays();
            
            float rate = PromptAddOn();

            Invoice invoice = new Invoice(days, rate);
            EndProgram(invoice);
        }

        public static float computeRate(){
            return FLAT_RATE;
        }

        public static float computeRate(char addOn){
            if(addOn == 'A'){
                return A_RATE;
            }else if(addOn == 'C'){
                return C_RATE;
            }else{
                Console.WriteLine("Invalid option, please select select either the A add-on service or the C add-on service");
                return computeRate(Console.ReadKey().KeyChar);
            }
        }

        public static void Welcome(){
            Console.WriteLine("Welcome to  MPLS Dogboarding academy!");
            Console.WriteLine("\n\npress any key to begin the program...");
            Console.ReadKey();
        }
        public static int PromptDays(){
            Console.WriteLine("\n\nHow many days is your dog staying?");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static float PromptAddOn(){
            Console.WriteLine("Would you like any add-on services?(y/n)");

            char addOn = char.ToUpper(Console.ReadKey().KeyChar);
            if(addOn == 'Y'){
                Console.WriteLine("\n\nOur add-on services include:\n\nBathing and grooming included (press A)\nBathing included (press C)");
                return computeRate(char.ToUpper(Console.ReadKey().KeyChar));
            }else if(addOn == 'N'){
                return computeRate();
            }else{
                Console.WriteLine("\nInvalid option, please press either y or n");
                return PromptAddOn();
            }
        }
        public static void EndProgram(Invoice invoice){
            Console.WriteLine("\n" + invoice.ToString());
            Console.WriteLine("\n\npress any key to end program...");
            Console.ReadKey();
        }
    }

    class Invoice{

        public int days;
        public float rate;
        public Invoice(int _days, float _rate){
            this.days = _days;
            this.rate = _rate;
        }

        public override string ToString(){
            Console.Clear();
            return $"Thank you for your interest in our services. \nYour dog will stay with us for {this.days} days, \nand your total cost will be {this.rate.ToString("c")}";
        }
    }
}
