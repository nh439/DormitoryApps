﻿using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class CurrentCustomerRepository
    {
        private readonly DBConnection _databases;       
        private const string TableName = "CurrentCustomer";

        public CurrentCustomerRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(CurrentCustomer item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<CurrentCustomer>(item);
            return res;
        }
        public async Task<bool> Update(CurrentCustomer item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id", item.Id);
            var res = await _databases.Dorm.UpdateEntityAsync<CurrentCustomer>(item, set);
            return res == 1;
        }
        public async Task<bool> Delete(string Id)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"Id='{Id}'");
            return res == 1;
        }
        public async Task< List<CurrentCustomer>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<CurrentCustomer>();
            return res.ToList();
        }
        public async Task<List<CurrentCustomer>>GetByRoom(int roomId)
        {
            ConditionSet set = new ConditionSet();
            set.Add("RoomId", roomId);
            var currentCustomers = await _databases.Dorm.SelectEntitiesAsync<CurrentCustomer>(TableName, set);
            return currentCustomers.ToList();

        }
        public async Task<CurrentCustomer> GetById(string Id)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id", Id);
            var currentCustomer = await _databases.Dorm.SelectEntitiesAsync<CurrentCustomer>(TableName,set);       
            return currentCustomer.FirstOrDefault();
        }

    }
}
