using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharptoScratch
{
    internal class ListDict
    {
        Dictionary<string, Image> imageData = new Dictionary<string, Image>();
        Dictionary<int, string> numberString = new Dictionary<int, string>();
        int items = 0;
        public Image GetItem(string key)
        {
            return imageData[key];
        }
        public Image GetItem(int key)
        {
            return imageData[GetKey(key)];
        }
        public string GetKey(int key)
        {
            return numberString[key];
        }
        public void AddItem(string key, Image value)
        {
            items++;
            imageData.Add(key, value);
            numberString.Add(imageData.Count, key);
        }
        public void RemoveItem(string key)
        {
            items--;
            numberString.Remove(numberString.FirstOrDefault(x => x.Value == key).Key);
            imageData.Remove(key);
        }
        public Image this[string indexer]
        {
            get
            {
                return GetItem(indexer);
            }
            set
            {
                throw new Exception("Cannot set item in ListDict.");
            }
        }
        public Image this[int indexer]
        {
            get
            {
                return GetItem(indexer);
            }
            set
            {
                throw new Exception("Cannot set item in ListDict.");
            }
        }
        public int Count()
        {
            return items;
        }
        public bool ContainsKey(string key)
        {
            return imageData.ContainsKey(key);
        }
        public bool ContainsKey(int key)
        {
            return imageData.ContainsKey(GetKey(key));
        }
        public int GetIndex(string key)
        {
            return numberString.FirstOrDefault(x => x.Value == key).Key;
        }
    }
}
