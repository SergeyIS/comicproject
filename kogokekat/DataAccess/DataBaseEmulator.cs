using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kogokekat.DataAccess
{
    public class DataBaseEmulator
    {
        private static List<Participant> _participants;
        
        public List<Participant> Participants { get { return _participants; } set { _participants = value; } }
        static DataBaseEmulator()
        {
            _participants = new List<Participant>()
            {
                new Participant(0, "Сергей", "Сидоров", "hf34w3tregwdqbso"),
                new Participant(1, "Даниил", "Дранга", "qeudc68trewqudc84"),
                new Participant(2, "Никита", "Шуплецов", "uwh3ry4eyfhefho"),
                new Participant(3, "Максим", "Иванов", "ywqgf8237ydu2323e")
            };
        }
    }
}