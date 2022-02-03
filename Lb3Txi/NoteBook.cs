using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Lb3Txi
{
    [Serializable]
    public class NoteBook : INoteBook
    {
        private int pl, co, number;
        private String name;
        public List<Ticket> list;
        private TicketTrain tt;

        public NoteBook()
        {
            list = new List<Ticket>();
        }

        public void PrintComand()
        {
            Console.WriteLine("Доступные команды:\n0- Выйти из программы.\n1- Показать все записи.\n2- Добавить запись.\n3- Удалить запись по номеру.\n4- Показать запись по номеру.\n5- Список команд. \n6- Скидка на билет.\n7- Проверить место.");
        }

        public void AddNote()
        {
            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();

            Console.WriteLine("Введите № вагона:");
            while (true)
            {
                try
                {
                    co = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }
                if (co > 0 && co < 50)
                    break;
                else
                    Console.WriteLine("Номер вагона не может быть меньше нуля и больше 50! Попробуйте еще раз.");
            }
            Console.WriteLine("Введите номер места:");
            while (true)
            {
                try
                {
                    pl = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }
                if (pl > 0 && pl < 100)
                    break;
                else
                    Console.WriteLine("Номер места не может быть меньше нуля и больше 100! Попробуйте еще раз.");
            }
            tt = new TicketTrain();
            tt.Coach = co;
            tt.Place = pl;
            tt.Name = name;
            tt.Price = 100;
            list.Add(tt);
        }

        public void DeleteNote()
        {
             if (list.Count == 0){
                Console.WriteLine("Список пуст!");
                return;
            }
            Console.WriteLine("Введите номер записи которую удалить:");
            while (true)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }

                if (number > 0 && number <= list.Count){
                    list.RemoveAt(number - 1);
                    break;
                }
                else
                    Console.WriteLine("Не существует такой записи в списке! Попробуйте еще раз.");
            }
        }

        public void PrintNoteByNum()
        {
            if (list.Count == 0){
                Console.WriteLine("Список пуст!");
                return;
            }
            Console.WriteLine("Введите номер записи которую показать:");
            while (true)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }
                
                if (number > 0 && number <= list.Count)
                {
                    tt = (TicketTrain)list[number - 1];
                    Console.WriteLine(number + ")" + " №вагона: {0} " + "№места: {1} " + "имя пасажира: {2} " + "время регистрации: {3} " + "цена билета: {4}", tt.Coach, tt.Place, tt.Name, tt.Date, tt.Price);
                    break;
                }
                else
                    Console.WriteLine("Не существует такой записи в списке! Попробуйте еще раз.");
            }
        }

        public void PrintList()
        {
            int count = 0;
            if (list.Count == 0)
                Console.WriteLine("Список пуст.");

            else
            {
                Console.WriteLine("Это все записи:");
                foreach (TicketTrain t in list)
                {
                    count++;
                    Console.WriteLine(count + ")" + " №вагона: {0} " + "№места: {1} " + "имя пасажира: {2} " + "время регистрации: {3}", t.Coach, t.Place, t.Name, t.Date);
                }
            }
        }

        public void DoDiscount()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст!");
                return;
            }
            Console.WriteLine("Введите номер билета для скидки:");
            while (true)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }

                if (number > 0 && number <= list.Count)
                {
                    tt = (TicketTrain)list[number - 1];
                    tt.Discount_ticket = true;
                    tt.Discount();
                    Console.WriteLine("Цена со скидкой: " + tt.Price);
                    break;
                }
                else
                    Console.WriteLine("Не существует такой записи в списке! Попробуйте еще раз.");
            }
        }

        public String PersonName(Ticket t)
        {
            String s;
            foreach (Ticket tic in list)
            {
                if (tic.Coach == t.Coach && tic.Place == t.Place)
                {
                    s = tic.Name.Substring(0, 1).ToUpper();
                    return name = "это место занято пасажиром: " + tic.Name.Remove(0, 1).Insert(0, s);
                }
            }
            return "Место свободно";
        }

    }
}
