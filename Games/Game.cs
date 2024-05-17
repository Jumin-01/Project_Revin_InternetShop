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
        public  bool Itinstai { get; set; }
        public List<string> GetImages { get { return _images; } }
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
                if (value<=5)
                {
                 _rating = value;
                }else _rating = 5;
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
            throw new NotImplementedException();
        }

        public void RemoveImage(string image)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }


        public void Launch()
        {
            throw new NotImplementedException();
        }
        public void Install()
        {
            throw new NotImplementedException();
        }

        public void Uninstall()
        {
            throw new NotImplementedException();
        }
    }
}
