using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class BankAccount
    {
        public const string BankCode = "BNK001";
        public readonly DateTime CreatedDate;
        private int _accountNumber;
        private string _fullName;
        private string _phoneNumber;
        private string _nationalID;
        private string _address;
        private decimal _balance;
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Full name cannot be empty.");
                }
                else
                {
                    _fullName = value;
                }
            }
        }

        public string NationID
        {
            get => _nationalID;
            set
            {
                if (value.Length != 14 || !value.All(char.IsDigit))
                {
                    Console.WriteLine("National ID must be exactly 14 digits.");
                }
                else
                {
                    _nationalID = value;
                }

            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (!value.StartsWith("01") || value.Length != 11 || !value.All(char.IsDigit))
                {
                    Console.WriteLine("Phone number must start with '01' and be 11 digits.");

                }
                else
                {
                    _phoneNumber = value;
                }
            }
        }
        public string Address
        {
            get => _address;
            set => _address = value;
        }
        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Balance cannot be negative.");
                }
                else
                {
                    _balance = value;
                }
            }
        }
        public BankAccount()
        {
            CreatedDate = DateTime.Now;
            _fullName = "unknow";
            _nationalID = "00000000000000";
            _phoneNumber = "01000000000";
            _address = "Not Provided";
            _balance = 0;
        }
        public BankAccount(string fullName, string nationalID, string phoneNumber, string address, decimal balance)
        {
            CreatedDate = DateTime.Now;
            FullName = fullName;
            NationID = nationalID;
            PhoneNumber = phoneNumber;
            Address = address;
            Balance = balance;
        }
        public BankAccount(string fullName, string nationalID, string phoneNumber, string address)
        {
            CreatedDate = DateTime.Now;
            FullName = fullName;
            NationID = nationalID;
            PhoneNumber = phoneNumber;
            Address = address;
            Balance = 0;
        }

        public void ShowAccountDetails()
        {
            Console.WriteLine($"Bank Code: {BankCode}");
            Console.WriteLine($"Created Date: {CreatedDate}");
            Console.WriteLine($"Full Name: {FullName}");
            Console.WriteLine($"National ID: {NationID}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Balance: {Balance}");
        }
        public bool IsValidNationalID()
        {
            return NationID.Length == 14 && NationID.All(char.IsDigit);
        }
        public bool IsValidPhoneNumber()
        {
            return PhoneNumber.StartsWith("01") && PhoneNumber.Length == 11 && PhoneNumber.All(char.IsDigit);
        }

        class SavingAccount : BankAccount
        {
            public decimal InterestRate
            {
                get;
                set;
            }
            public SavingAccount(string fullName, string nationalID, string phoneNumber, string address, decimal balance, decimal interestRate) : base(fullName, nationalID, phoneNumber, address, balance)
            {
                InterestRate = interestRate;
            }
            public override decimal CalculateInterest()
            {
                return Balance * InterestRate / 100;
            }
            public override void ShowAccountDetails()
            {
                base.ShowAccountDetails();
                Console.WriteLine($"interest rate: {InterestRate}%");
            }
        }
        class CurrentAccount : BankAccount
        {
            public decimal OverdraftLimit
            {
                get;
                set;
            }
            public CurrentAccount(string fullName, string nationalID, string phoneNumber, string address, decimal balance, decimal overdraftLimit) : base(fullName, nationalID, phoneNumber, address, balance)
            {
                OverdraftLimit = overdraftLimit;
            }
            public override decimal CalculateInterest()
            {
                return 0;
            }
            public override void ShoeAccountDeatails()
            {
                base.ShoeAccountDeatails();
                Console.WriteLine($"Overdraft limit: {OverdraftLimit}");
            }
        }
        class program
        {
            static void main(string[] args)
            {
                SavingAccount s = new SavingAccount("Asma Rizk", "12345678901234", "010987654321", "Cairo", 1000, 5);
                CurrentAccount c = new CurrentAccount("Nesma Rizk", " 12345678901234", "01012345678", "Giza", 4000, 20);
                List<BankAccount> accounts = new List<BankAccount> { s, c };
                foreach (var account in accounts)
                {
                    account.ShowAccountDetails();
                    Console.WriteLine($"interest: {account.CalculateInterest()}");
                    Console.WriteLine(new string('_', 30));
                }
                Console.ReadLine();
            }
        }
    }
}