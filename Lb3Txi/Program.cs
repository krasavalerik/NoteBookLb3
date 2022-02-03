using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3Txi
{
    class Program
    {
        static void Main(string[] args)
        {
            int comand;
            TicketTrain ticket;
            Save s = new Save();
            NoteBook note = new NoteBook();

            note.list.Add(new Ticket { Age =11, Coach = 123, Name = "", Place = 11, Price = 434  });

            s.SaveNote("fgdf.xml", note);


            note.PrintComand();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите команду из списка");
                Console.WriteLine();

                try { comand = Convert.ToInt32(Console.ReadLine()); }

                catch
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз.");
                    continue;
                }

                switch (comand)
                {
                    case 0:
                        return;

                    case 1:
                        note.PrintList();
                        break;

                    case 2:
                        note.AddNote();
                        break;

                    case 3:
                        note.DeleteNote();
                        break;

                    case 4:
                        note.PrintNoteByNum();
                        break;

                    case 5:
                        note.PrintComand();
                        break;

                    case 6:
                        note.DoDiscount();
                        break;

                    case 7:
                        ticket = new TicketTrain();
                        Console.WriteLine("Введите № вагона:");
                        while (true)
                        {
                            try
                            {
                                ticket.Coach = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Введите число!");
                                continue;
                            }
                            if (ticket.Coach > 0 && ticket.Coach < 50)
                                break;
                            else
                                Console.WriteLine("Номер вагона не может быть меньше нуля и больше 50! Попробуйте еще раз.");
                        }
                        Console.WriteLine("Введите номер места:");
                        while (true)
                        {
                            try
                            {
                                ticket.Place = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Введите число!");
                                continue;
                            }
                            if (ticket.Place > 0 && ticket.Place < 100)
                                break;
                            else
                                Console.WriteLine("Номер места не может быть меньше нуля и больше 100! Попробуйте еще раз.");
                        }
                        Console.WriteLine(note.PersonName(ticket));
                        break;

                    case 8:
                        Console.WriteLine("Введите имя файла:");
                        String path = Console.ReadLine();
                        s.SaveNote(path, note);
                        break;

                    case 9:
                        Console.WriteLine("Введите имя файла который загрузить:");
                        String load_path = Console.ReadLine();
                        note = s.LoadNote(load_path);
                        break;

                    default:
                        Console.WriteLine("Не известная команда, повторите выбор.");
                        break;
                }
            }

            /*TicketTrain tt = new TicketTrain();
            tt.Name = "bbb";
            Console.WriteLine(note.PersonName(tt));
            Console.ReadKey();*/
        }
    }
}
