using Domain.Entities;

namespace App.WindowsForms.Repository
{
    public class BillToPayRegistrationRepository
    {
        public Dictionary<int, BillToPayRegistration> _billToPayRegistrations = new();
        public event EventHandler<IList<BillToPayRegistration>>? DataProcessed;

        /// <summary>
        /// Variável Privada da Instância
        /// </summary>
        private static BillToPayRegistrationRepository? _instance = null;
        /// <summary>
        /// Get a instância
        /// </summary>
        public static BillToPayRegistrationRepository Instance
        {
            get { return _instance ??= new BillToPayRegistrationRepository(); }
        }

        public void AddOnMemory(BillToPayRegistration billToPayRegistration)
        {
            if (_billToPayRegistrations.Count == 0)
            {
                _billToPayRegistrations.TryAdd(0, new BillToPayRegistration() { Id = 0, Name = "Nenhum" });
                _billToPayRegistrations.TryAdd(billToPayRegistration.Id, billToPayRegistration);
            }
            else
            {
                _billToPayRegistrations.TryAdd(billToPayRegistration.Id, billToPayRegistration);
            }
        }

        public void AddRangeOnMemory(IList<BillToPayRegistration> billToPayRegistrations)
        {
            foreach (var item in billToPayRegistrations)
            {
                if (_billToPayRegistrations.Count == 0)
                {
                    _billToPayRegistrations.TryAdd(0, new BillToPayRegistration() { Id = 0, Name = "Nenhum" });
                    _billToPayRegistrations.TryAdd(item.Id, item);
                }
                else
                {
                    _billToPayRegistrations.TryAdd(item.Id, item);
                }
            }

            DataProcessed?.Invoke(this, billToPayRegistrations);
        }
    }
}