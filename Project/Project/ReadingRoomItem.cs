using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal abstract class ReadingRoomItem
    {
        private string title;
        public string Title
        {
            get { return title; }
        }
        private string publisher;
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        private string identification;
        public abstract string Identification
        {
            get;
        }

        private string categorie = string.Empty;
        public abstract string Categorie
        {
            get;
        }
        public ReadingRoomItem(string title, string publisher)
        {
            this.title = title;
            this.publisher = publisher;
        }
    }
}

