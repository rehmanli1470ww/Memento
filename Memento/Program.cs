using System;

public class Memento
{
    public string State { get; }

    public Memento(string state)
    {
        State = state;
    }
}

public class Originator
{
    private string state;

    public string State
    {
        get { return state; }
        set
        {
            state = value;
            Console.WriteLine("Durum güncellendi: " + state);
        }
    }

    public Memento SaveState()
    {
        return new Memento(state);
    }

    public void RestoreState(Memento memento)
    {
        state = memento.State;
        Console.WriteLine("Durum geri yüklendi: " + state);
    }
}

public class Caretaker
{
    public Memento Memento { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        originator.State = "Başlangıç Durumu";
        caretaker.Memento = originator.SaveState();

        originator.State = "Güncellenmiş Durum";

        originator.RestoreState(caretaker.Memento);
    }
}