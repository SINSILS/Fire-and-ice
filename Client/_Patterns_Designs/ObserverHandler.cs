using Client._Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs
{
    public class ObserverHandler
    {
        private readonly List<IObserver<Lever>> _observers;
        public List<Lever> Levers { get; set; }
        public ObserverHandler()
        {
            _observers = new();
            Levers = new();
        }

        public IDisposable Subscribe(IObserver<Lever> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                foreach (var item in Levers)
                    observer.OnNext(item);
            }
            return new Unsubscriber(_observers, observer);
        }
        public void AddApplication(Lever app)
        {
            Levers.Add(app);
            foreach (var observer in _observers)
                observer.OnNext(app);
        }
        public void CloseApplications()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();
            _observers.Clear();
        }
    }

    public class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<Lever>> _observers;
        private readonly IObserver<Lever> _observer;
        public Unsubscriber(List<IObserver<Lever>> observers, IObserver<Lever> observer)
        {
            _observers = observers;
            _observer = observer;
        }
        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
