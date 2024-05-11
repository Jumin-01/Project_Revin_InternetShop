﻿using Project_Revin_InternetShop.Games;
using Project_Revin_InternetShop.Interface;
using Project_Revin_InternetShop.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Revin_InternetShop.Users
{
    public class User : IPerson
    {
        bool _root;
        private string _username;
        private string _firstname;
        private string _lastname;
        private string _password;
        private int _balance;
        Library library;
        public User()
        {
            library = new Library(this);

        }
        public User(string username, string firstname, string lastname, string password, bool GetRoot)
        {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
            Balance = 0;
            library = new Library(this);
            Root = GetRoot;


        }

        public int Balance
        {
            get { return _balance; }
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
            }
        }
        public Library Library
        {
            get { return library; }
        }
        public bool Root
        {
            get { return _root; }
            set { _root = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public void BuyGame(Game game)
        {
            throw new NotImplementedException();
        }
        public void ReplenishBalance(int amount)
        {
            throw new NotImplementedException();
        }

    }
}
