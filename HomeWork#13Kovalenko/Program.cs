using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HomeWork_13Kovalenko
{
    class Program
    {
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);

            Menu menu;
            List<ListReferences> listReferences = [];


            while (true)
            {
                WriteMenu();
                Console.Write("\nЩо хочете зробити? Введіть номер дії - ");
                bool outBlendAction = int.TryParse(Console.ReadLine(), out int action);
                if (outBlendAction && action <= 4)
                {
                    menu = (Menu)action;

                    switch (menu)
                    {

                        case Menu.addNewRef:
                            { listReferences = AddReferences(listReferences); }
                            break;

                        case Menu.removeRef:
                            { listReferences = RemoveReferences(listReferences); }
                            break;

                        case Menu.readRef:
                            { ReadReferences(listReferences);Console.ReadKey(); }
                            break;
                        case Menu.changeStatus:
                            { listReferences = ChangeStatus(listReferences); }
                            break;

                    }
                }
                else { WriteBlend(); }

                WriteMenu();
                // Контрольований вихід з програми
                Console.Write("\nВийти зпрограми: 1 - Так / 2 - Ні ");

                bool blendMenuOut = int.TryParse(Console.ReadLine(), out int exit);

                if (blendMenuOut && exit == 1)

                { break; }

                else if (blendMenuOut && exit == 2)

                { continue; }

                else { WriteBlend(); continue; }

            }

        }
        enum Menu
        {
            addNewRef = 1,
            removeRef,
            readRef,
            changeStatus,
        }
        static void WriteMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Додати запис.");
            Console.WriteLine("2 - Видалити запис.");
            Console.WriteLine("3 - Переглянути ваші справи.");
            Console.WriteLine("4 - Змінити статус справи.");
        }
        static void WriteBlend()
        {
            Console.WriteLine("Некоректне введення!");
            Console.ReadKey();
        }
        static void ReadReferences(List<ListReferences> listCases)
        {
            Console.Clear();
            if (listCases.Count != 0)
            {
                Console.WriteLine($"кількість  записів - {listCases.Count}");

                foreach (var item in listCases)
                {

                    Console.WriteLine();
                    Console.Write($" Справа №{listCases.IndexOf(item)} | {item.NameReference} {item.Reference} ");
                 
                    
                    if (item.StatusReference)
                    {
                        Console.Write("Справа відкрита");
                    }
                    else
                    {
                        Console.Write("Справа закрита");
                    }
                    Console.WriteLine("\n-----------------------");
                }
                
            }
            else { Console.WriteLine("Список справ пустий спочатку додайте справу"); Console.ReadKey(); }

        }
        static List<ListReferences> AddReferences(List<ListReferences> listCases)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nВведіть назву справи - ");
                string nameRef = /*$"справа №"*/ Console.ReadLine();

                Console.WriteLine("\nВведіть опис справи - ");
                string valueRef = /*$"Тестове виведення опису справи для програми. №"*/Console.ReadLine();
                bool statusRef = true;

                listCases.Add(new ListReferences() { NameReference = nameRef, Reference = valueRef, StatusReference = statusRef });
                Console.WriteLine($"\nСправу {nameRef} додано");


                Console.Write("Продовжити додавати справи: 1 - Так / 2 - Ні ");

                bool blendMenuout = int.TryParse(Console.ReadLine(), out int exit);

                if (blendMenuout && exit == 2)

                { return listCases; }

                else if (blendMenuout && exit == 1)

                { continue; }

                else { WriteBlend(); continue; }


            }


        }
        static List<ListReferences> RemoveReferences(List<ListReferences> listCases)
        {
            while (true)
            {
                ReadReferences(listCases);
                if (listCases.Count != 0)
                {
                    //Console.Clear();
                    Console.WriteLine();
                    Console.Write($"Введіть номер справи для видалення - ");
                    bool outBlebd = int.TryParse(Console.ReadLine(), out int indexRemove);
                    if (outBlebd && listCases.Count >= indexRemove)
                    {

                        Console.WriteLine($"Справу {listCases[indexRemove]}  {listCases[indexRemove].NameReference} - Видалено");
                        listCases.Remove(listCases[indexRemove]);
                        
                    }

                    else
                    {
                        WriteBlend();
                    }
                }
                else { return listCases;}

                Console.WriteLine("Продовжити видалення справ: 1 - Так / 2 - Ні");

                bool blendMenuout = int.TryParse(Console.ReadLine(), out int exit);

                if (blendMenuout && exit == 2)

                { return listCases;}

                else if (blendMenuout && exit == 1)

                { continue; }

                else { WriteBlend(); continue; }
            }
        }
        static List<ListReferences> ChangeStatus(List<ListReferences> listCases)
        {
            ReadReferences(listCases);
            while (true)

            {
                if (listCases.Count != 0)
                { 
                    Console.Write("Введіть номер справи щоб змінити статус ");
                bool outBlendInput = int.TryParse(Console.ReadLine(), out int index);

                    if (outBlendInput)
                    {
                        Console.Clear();
                        Console.WriteLine($"{listCases[index].NameReference} {listCases[index].Reference} {listCases[index].StatusReference}");
                        Console.WriteLine("Позначити справу як виконану? ");
                        Console.Write("1 - Так / 2 - Ні ");
                        bool outBlendStatus = int.TryParse(Console.ReadLine(), out int status);
                        if (outBlendStatus && status == 1)
                        {
                            listCases[index].StatusReference = false;
                            Console.WriteLine("Статус справи закритий");
                        }
                        else if (outBlendStatus && status == 2)
                        {
                            listCases[index].StatusReference = true;
                            Console.WriteLine("Статус справи відкритий");
                        }
                        else { WriteBlend(); }

                    }

                }
                else { return listCases; }
                Console.Write("\nПродовжити працю зі справами: 1 - Так / 2 - Ні ");

                bool blendMenuout = int.TryParse(Console.ReadLine(), out int exit);

                if (blendMenuout && exit == 2)

                { return listCases; }

                else if (blendMenuout && exit == 1)

                { continue; }

                else { WriteBlend(); continue; }
            }
        }
    }
}