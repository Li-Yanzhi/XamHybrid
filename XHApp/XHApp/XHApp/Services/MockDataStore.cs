using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XHApp.Models;

namespace XHApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "1 First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2 Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "3 Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "4 Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "5 Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "6 Sixth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 7 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 8 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 9 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 10 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 11 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 12 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 13 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 14 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 15 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 16 个", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "第 17 个", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}