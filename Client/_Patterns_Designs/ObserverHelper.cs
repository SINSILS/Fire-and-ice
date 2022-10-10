using Client._Classes;
using Client._Classes.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs
{
    public class ObserverHelper : IObserver<Interactable>
    {
        private IDisposable _cancellation;
        public string Name { get; set; }
        public List<Interactable> Levers { get; set; }
        public ObserverHelper(string name)
        {
            Name = name;
            Levers = new();
        }
        public void List()
        {
            if (Levers.Any())
                foreach (var o in Levers)
                    Console.WriteLine($"Hey, {Name}! {o.isActivated} status has been updated");

        }

        public virtual void Subscribe(ObserverHandler provider)
        {
            _cancellation = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            _cancellation.Dispose();
            Levers.Clear();
        }
        public void OnCompleted()
        {
            Console.WriteLine($"Hey, {Name}! We are not accepting any more applications");
        }
        public void OnError(Exception error)
        {
            // This is called by the provider if any exception is raised, no need to implement it here
        }
        public void OnNext(Interactable value)
        {
            Levers.Add(value);
        }
    }
}
