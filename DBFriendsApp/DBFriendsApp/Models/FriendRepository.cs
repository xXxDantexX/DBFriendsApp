﻿using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using DBFriendsApp.Models;

namespace DBFriendsApp.Models
{
    public class FriendRepository
    {
        SQLiteConnection database;

        public FriendRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Friend>();
        }

        public IEnumerable<Friend> GetItems()
        {
            return database.Table<Friend>().ToList();
        }

        public Friend GetItem(int id)
        {
            return database.Get<Friend>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Friend>(id);
        }

        public int SaveItem(Friend item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}