using System;
using System.Collections.Generic;
using System.Linq;

// Клас для представлення композиції
class Composition
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Artist { get; set; }
    public string Lyrics { get; set; }
    public DateTime CreationDate { get; set; }
    public TimeSpan Duration { get; set; }
    public string Format { get; set; }
    public double Rating { get; set; }

    public Composition(string title, string genre, string artist, string lyrics, DateTime creationDate, TimeSpan duration, string format, double rating)
    {
        Title = title;
        Genre = genre;
        Artist = artist;
        Lyrics = lyrics;
        CreationDate = creationDate;
        Duration = duration;
        Format = format;
        Rating = rating;
    }
}

// Клас-контейнер для композицій
class CompositionCollection<T> : List<T> where T : Composition
{

    public void AddComposition(T composition)
    {
        this.Add(composition);
    }

    public void SortByTitle()
    {
        this.Sort((c1, c2) => string.Compare(((Composition)c1).Title, ((Composition)c2).Title));
    }
    public void SortByArtist()
    {
        this.Sort((c1, c2) => string.Compare(((Composition)c1).Artist, ((Composition)c2).Artist));
    }
    public void SortByAverageRating()
    {
        this.Sort((c1, c2) => ((Composition)c1).Rating.CompareTo(((Composition)c2).Rating));
    }
}

// Клас утиліт для обробки контейнерів об'єктів
class CompositionUtility
{
    public static void ShowCompositions(CompositionCollection<Composition> collection)
    {
        foreach (var composition in collection)
        {
            Console.WriteLine($"Назва: {composition.Title}");
            Console.WriteLine($"Жанр: {composition.Genre}");
            Console.WriteLine($"Виконавець: {composition.Artist}");
            Console.WriteLine($"Дата створення: {composition.CreationDate}");
            Console.WriteLine($"Тривалiсть: {composition.Duration}");
            Console.WriteLine($"Формат: {composition.Format}");
            Console.WriteLine($"Рейтинг: {composition.Rating}");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення колекції композицій
        CompositionCollection<Composition> compositionCollection = new CompositionCollection<Composition>();

        compositionCollection.AddComposition(new Composition("Пiсня 1", "Рок", "Виконавець 3", "Текст пісні 1", DateTime.Now, TimeSpan.FromMinutes(3), "MP3", 4.5));
        compositionCollection.AddComposition(new Composition("Пiсня 3", "Поп", "Виконавець 2", "Текст пісні 3", DateTime.Now, TimeSpan.FromMinutes(4), "WAV", 3.8));
        compositionCollection.AddComposition(new Composition("Пiсня 2", "Реп", "Виконавець 1", "Текст пісні 2", DateTime.Now, TimeSpan.FromMinutes(5), "MP3", 4.2));

        compositionCollection.SortByTitle();
        Console.WriteLine("Сортування за назвою:");
        CompositionUtility.ShowCompositions(compositionCollection);

        compositionCollection.SortByArtist();
        Console.WriteLine("Сортування за виконавцем:");
        CompositionUtility.ShowCompositions(compositionCollection);

        compositionCollection.SortByAverageRating();
        Console.WriteLine("Сортування за середнiм рейтингом:");
        CompositionUtility.ShowCompositions(compositionCollection);
    }
}
