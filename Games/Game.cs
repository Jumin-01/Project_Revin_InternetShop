using Project_Revin_InternetShop.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Revin_InternetShop.Games
{
    public class Game : ICloneable
    {
        public static int Count { get; set; }
        public int id { get; set; }
        private double _version;
        private string _name;
        private string _description;
        private string _publisher;
        private double _rating;
        private int _price;
        private List<string> _images = new List<string>();
        private string _part;
        private Category _category;
        public bool Itinstai { get; set; }

        public Game()
        {
            Count++;
            id = Count + 1;
        }
        public Game(double version, string name, string publisher, double rating, int price, string description, string part, Category category)
        {
            Count++;
            id = Count + 1;
            Version = version;
            Name = name;
            Publisher = publisher;
            Rating = rating;
            Price = price;
            Description = description;
            Part = part;
            Category = category;
        }
        public List<string> GetImages { get { return _images; } }
        public double Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        public string Part
        {
            get { return _part; }
            set { _part = value; }
        }
        public double Rating
        {
            get { return _rating; }
            set
            {
                if (value <= 5)
                {
                    _rating = value;
                }
                else _rating = 5;
            }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }




        public void AddImage(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                throw new ArgumentException("Зображення не може бути пустим або null.");
            }
            if (!_images.Contains(image))
            {
                _images.Add(image);
            }
            else
            {
                throw new ArgumentException("Таке зображення вже додано.");
            }
        }

        public void RemoveImage(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                throw new ArgumentException("Зображення не може бути пустим або null.");
            }
            if (_images.Contains(image))
            {
                _images.Remove(image);
            }
            else
            {
                throw new ArgumentException("Зображення, яке ви хочете видалити, не існує в списку.");
            }
        }

       

        public object Clone()
        {
            Game clonedGame = new Game(Version, Name, Publisher, Rating, Price, Description, Part, Category);
            clonedGame._images = new List<string>(_images); // Глибока копія списку зображень
            return clonedGame;
        }


        public void Launch()
        {
            if (string.IsNullOrEmpty(_part))
            {
                throw new InvalidOperationException("Шлях до виконуваного файлу не встановлено.");
            }

            try
            {
                Process.Start(_part);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Помилка під час запуску програми: {ex.Message}", ex);
            }
        }
        public void Install()
        {
            if (Itinstai)
            {
                throw new InvalidOperationException("Гра вже встановлена.");
            }
            Itinstai = true;
        }

        public void Uninstall()
        {
            if (!Itinstai)
            {
                throw new InvalidOperationException("Гра не була встановлена.");
            }
            Itinstai = false;
        }
    }
}