using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_1
{
    class Program
    {

        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Song[] songs = null;
            int added_song_count = 0;
            Console.WriteLine("Введіть максимальну кількість пісень: ");
            int N = int.Parse(Console.ReadLine());
            songs = new Song[N];
            while (true)
            {
                try
                {

                    int choice = Menu();

                    switch (choice)
                    {
                        case 1:
                            if (added_song_count + 1 > N)
                            {
                                Console.WriteLine("Помилка: додана максимальна кількість пісень");
                            }
                            else
                            {
                                add_song(songs, added_song_count);
                                added_song_count++;
                            }
                            break;

                        case 2:
                            if (added_song_count == 0)
                            {
                                Console.WriteLine("Помилка: список порожній. Спочатку додайте пісні (пункт 1).\n");
                                break;
                            }

                            Console.WriteLine("Список пісень:");
                            for (int i = 0; i < added_song_count; i++)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"---  Пісня #{i + 1}  ---");
                                Console.WriteLine($"Назва: {songs[i].Title}");
                                Console.WriteLine($"Виконавець: {songs[i].Artist}");
                                Console.WriteLine($"Жанр: {songs[i].Genre}");
                                Console.WriteLine($"Довжина: {songs[i].Duration}");
                                if (songs[i].PlayCount != 0)
                                {
                                    Console.WriteLine($"Кількість відтворень: {songs[i].PlayCount}");
                                    Console.WriteLine($"Останнє відтворення: {songs[i].LastPlayed}");
                                }
                                if (songs[i]._isFavorite == true)
                                {
                                    Console.WriteLine(songs[i].AddFavorite());
                                }
                                Console.WriteLine();

                            }
                            Console.WriteLine();
                            break;

                        case 3:
                            if (added_song_count == 0)
                            {
                                Console.WriteLine("Помилка: список порожній. Спочатку додайте пісні (пункт 1).\n");
                                break;
                            }
                            Console.WriteLine("[1] - Пошук за назвою\n[2] - Пошук за жанром");
                            int search_choice;
                            do
                            {
                                search_choice = int.Parse(Console.ReadLine());
                                if (search_choice < 1 || search_choice > 2) Console.WriteLine("Помилка: доступні варіанти 1-2");
                            } while (search_choice < 1 || search_choice > 2);

                            if (search_choice == 1)
                            {
                                Console.WriteLine("Введіть назву пісні: ");
                                string search_title = Console.ReadLine();
                                bool found = false;
                                for (int i = 0; i < added_song_count; i++)
                                {
                                    if (search_title == songs[i].Title)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("---  Знайдено пісню  --- ");
                                        Console.WriteLine($"Назва: {songs[i].Title}");
                                        Console.WriteLine($"Виконавець: {songs[i].Artist}");
                                        Console.WriteLine($"Жанр: {songs[i].Genre}");
                                        Console.WriteLine($"Довжина: {songs[i].Duration}");
                                        Console.WriteLine();
                                        found = true;
                                    }
                                }
                                if (!found)
                                {
                                    Console.WriteLine("Пісень з такою назвою не знайдено!");
                                }

                            }
                            if (search_choice == 2)
                            {
                                Genre parsedGenre;
                                string search_genre;
                                while (true)
                                {
                                    Console.Write("Введіть жанр для пошуку (Pop, Rock, Jazz, HipHop, Classical, Electronic, Folk): ");

                                    search_genre = Console.ReadLine();

                                    if (Enum.TryParse(search_genre, true, out parsedGenre) && Enum.IsDefined(typeof(Genre), parsedGenre))
                                    {
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Невідомий жанр. Спробуйте ще раз.");
                                }
                                bool found = false;
                                for (int i = 0; i < added_song_count; i++)
                                {
                                    if (parsedGenre == songs[i].Genre)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("---  Знайдено пісню  --- ");
                                        Console.WriteLine($"Назва: {songs[i].Title}");
                                        Console.WriteLine($"Виконавець: {songs[i].Artist}");
                                        Console.WriteLine($"Жанр: {songs[i].Genre}");
                                        Console.WriteLine($"Довжина: {songs[i].Duration}");
                                        
                                        found = true;
                                    }
                                }
                                if (!found)
                                {
                                    Console.WriteLine("Пісень в такому жанрі не знайдено!");
                                }
                            }
                            break;

                        case 4:
                            if (added_song_count == 0)
                            {
                                Console.WriteLine("Помилка: список порожній. Спочатку додайте пісні (пункт 1).\n");
                                break;
                            }
                            string choice_4;
                            while (true)
                            {
                                Console.WriteLine("[1] - Відтврення пісні\n[2] - Додати до обраного\n[3] - Видалити з обраного");
                                choice_4 = Console.ReadLine();
                                if (int.Parse(choice_4) > 0 && int.Parse(choice_4) < 4) break;
                                else Console.WriteLine("Помилка: доступні варінти 1-3.");
                            }
                            if (int.Parse(choice_4) == 1)
                            {
                                Console.Write("Введіть назву пісні для відтворення: ");
                                string search_title1 = Console.ReadLine();
                                bool found1 = false;
                                for (int i = 0; i < added_song_count; i++)
                                {
                                    if (search_title1 == songs[i].Title)
                                    {
                                        songs[i].Play();
                                        found1 = true;
                                    }
                                }
                                if (!found1)
                                {
                                    Console.WriteLine("Пісень з такою назвою не знайдено!");
                                }
                            }
                            if(int.Parse(choice_4) == 2)
                            {
                                Console.WriteLine("Введіть назву пісні: ");
                                string search_title1 = Console.ReadLine();
                                bool found1 = false;
                                for (int i = 0; i < added_song_count; i++)
                                {
                                    if (search_title1 == songs[i].Title)
                                    {
                                        Console.WriteLine(songs[i].AddFavorite());
                                        found1 = true;
                                    }
                                }
                                if (!found1)
                                {
                                    Console.WriteLine("Пісень з такою назвою не знайдено!");
                                }
                            }
                            if (int.Parse(choice_4) == 3)
                            {
                                Console.WriteLine("Введіть назву пісні: ");
                                string search_title1 = Console.ReadLine();
                                bool found1 = false;
                                for (int i = 0; i < added_song_count; i++)
                                {
                                    if (search_title1 == songs[i].Title)
                                    {
                                        found1 = true;
                                        if (songs[i]._isFavorite == true)
                                            Console.WriteLine(songs[i].DeleteFavorite());
                                        else Console.WriteLine("Помилка: ця пісня не була додана до обраного.");
                                    }
                                }
                                if (!found1)
                                {
                                    Console.WriteLine("Пісень з такою назвою не знайдено!");
                                }
                            }

                            break;

                        case 5:
                            if (added_song_count == 0)
                            {
                                Console.WriteLine("Помилка: список порожній. Спочатку додайте пісні (пункт 1).\n");
                                break;
                            }

                            Console.WriteLine("[1] - Видалення за номером\n[2] – Видалення за жанром");
                            int delete_choice;
                            do
                            {
                                delete_choice = int.Parse(Console.ReadLine());
                                if (delete_choice < 1 || delete_choice > 2)
                                    Console.WriteLine("Помилка: доступні варіанти 1-2.");
                            } while (delete_choice < 1 || delete_choice > 2);

                            if (delete_choice == 1)
                            {
                                while (true)
                                {
                                    Console.Write("Введіть порядковий номер пісні для видалення: ");
                                    int delete_index = int.Parse(Console.ReadLine()) - 1;

                                    if (delete_index < 0 || delete_index >= added_song_count)
                                    {
                                        Console.WriteLine("Такої пісні не знайдено.\n");
                                    }
                                    else
                                    {
                                        added_song_count--;
                                        for (int i = delete_index; i < added_song_count; i++)
                                            songs[i] = songs[i + 1];
                                        songs[added_song_count] = null;
                                        Console.WriteLine($"Пісню #{delete_index + 1} видалено.\n");
                                        break;
                                    }


                                }
                            }
                            else
                            {
                                Genre parsedGenre;
                                string delete_genre;
                                while (true)
                                {
                                    Console.Write("Введіть жанр для видалення (Pop, Rock, Jazz, HipHop, Classical, Electronic, Folk): ");

                                    delete_genre = Console.ReadLine();

                                    if (Enum.TryParse(delete_genre, true, out parsedGenre) && Enum.IsDefined(typeof(Genre), parsedGenre))
                                    {
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Невідомий жанр. Спробуйте ще раз.");
                                }

                                bool deleted = false;
                                int delete_count = 0;
                                for (int i = 0; i < added_song_count;)
                                {
                                    if (songs[i].Genre == parsedGenre)
                                    {
                                        added_song_count--;
                                        for (int j = i; j < added_song_count; j++)
                                            songs[j] = songs[j + 1];
                                        songs[added_song_count] = null;
                                        deleted = true;
                                        delete_count++;
                                    }
                                    else i++;
                                }

                                if (deleted)
                                    Console.WriteLine($"Видалено {delete_count} пісень жанру «{delete_genre}».\n");
                                else
                                    Console.WriteLine($"Пісень жанру «{delete_genre}» не знайдено.\n");
                            }
                            break;

                        case 0:
                            Console.WriteLine("Роботу програми завершено.");
                            return;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: неверній формат!");
                }
            }















            static int Menu()
            {
                Console.WriteLine("[1] - Додати об'єкт\n[2] - Переглянути всі об'єкти\n[3] - Знайти об'єкт\n[4] - Продемонструвати поведінку\n[5] - Видалити об'єкт\n[0] - Вийти з програми");
                int var;
                do
                {
                    var = int.Parse(Console.ReadLine());
                    if (var < 0 || var > 5) Console.WriteLine("Помилка (існують лише варіанти 0 - 5)");
                } while (var < 0 || var > 5);
                return var;
            }





            static void add_song(Song[] mas, int count)
            {
                Console.WriteLine($"--- Заповнення пісні #{count + 1} ---");
                mas[count] = new Song();

                while (true)
                {
                    Console.Write("Введіть назву пісні: ");
                    try
                    {
                        mas[count].Title = Console.ReadLine();
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (true)
                {
                    Console.Write("Введіть виконавця: ");
                    try
                    {
                        mas[count].Artist = Console.ReadLine();
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (true)
                {
                    Genre parsedGenre;
                    Console.Write("Введіть жанр (Pop, Rock, Jazz, HipHop, Classical, Electronic, Folk): ");
                    string input = Console.ReadLine();
                    if (Enum.TryParse(input, true, out parsedGenre)
                    && Enum.IsDefined(typeof(Genre), parsedGenre))
                    {
                        mas[count].Genre = parsedGenre;
                        break;
                    }
                    else
                        Console.WriteLine("Невідомий жанр. Спробуйте ще раз.");
                }
                while (true)
                {
                    Console.Write("Введіть тривалість (mm:ss): ");
                    string input = Console.ReadLine();
                    try
                    {
                        mas[count].Duration = input;
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                }
                Console.WriteLine($"Пісня #{count + 1} додана.\n"); 
            }
        }
    }
}
