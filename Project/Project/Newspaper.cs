using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Newspaper : ReadingRoomItem
    {
		private  DateTime date;

		public DateTime Date
        {
			get { return  date; }
			set {  date = value; }
		}

        public override string Identification
        {
            get
            {
                string[] words = Title.Split(' ');
                string identification = "";
                foreach (string word in words)
                {
                    identification += word[0];
                }
                string datePart = Date.ToString("ddMMyyyy");
                return $"{identification.ToUpper()}-{date}";
            }
        }
        public override string Categorie
        {
            get { return "Krant"; }
        }
        public Newspaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            this.date = date;
        }
    }
}
