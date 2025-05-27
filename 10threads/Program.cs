namespace _10threads
{
    internal class Program
    {
        public static void Main()
        {
            Account AccountHandler = new Account();
            AccountHandler.Deposit(1000);

            Thread ThreadHandlerX = new Thread(() => DoIterations(AccountHandler));
            Thread ThreadHandlerY = new Thread(() => DoIterations(AccountHandler));
            Thread ThreadHandlerZ = new Thread(() => DoIterations(AccountHandler));

            ThreadHandlerX.Start();
            ThreadHandlerY.Start();
            ThreadHandlerZ.Start();

            ThreadHandlerX.Join();
            ThreadHandlerY.Join();
            ThreadHandlerZ.Join();

            Console.WriteLine($"Баланс после итераций: ${AccountHandler.Balance}");
        }

        public static void DoIterations(Account WorkWith)
        {
            for (int Iteration = 0; Iteration < 1000; ++Iteration)
            {
                WorkWith.Deposit(10);
                WorkWith.Withdraw(10);
            }
        }
    }

    internal class Account
    {
        private uint m_Balance;

        public uint Balance
        {
            get
            {
                lock (LockObject)
                { return m_Balance; }
            }
        }

        private readonly object LockObject = new object();

        public void Deposit(uint amountToDeposit)
        {
            lock (LockObject)
            { m_Balance += amountToDeposit; }
        }

        public void Withdraw(uint amountToWithdraw)
        {
            lock (LockObject)
            {
                if (m_Balance >= amountToWithdraw)
                { m_Balance -= amountToWithdraw; }
            }
        }
    }
}
