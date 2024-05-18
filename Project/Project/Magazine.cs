using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Magazine : ReadingRoomItem
    {
        private byte month;

        public byte Month
        {
            get { return month; }
            set
            {
                if (value > 12)
                {
                    Console.WriteLine("De maand is maximaal 12.");
                    return;
                }
                month = value;
            }
        }

        private uint year;

        public uint Year
        {
            get { return year; }
            set
            {
                if (value > 2500)
                {
                    Console.WriteLine("Het jaartal is maximaal 2500");
                    return;
                }
                year = value;
            }
        }

        public override string Identification
        {
            get
            {
                string[] words = Title.Split(' ');
                string initials = "";
                foreach (var word in words)
                {
                    initials += word[0];
                }
                string datePart = $"{Month:D2}{Year:D4}";
                return initials.ToUpper() + datePart;
            }
        }

        public override string Categorie
        {
            get { return "Maandblad"; }
        }

        public Magazine(string title, string publisher, byte month, uint year) : base(title, publisher)
        {
            this.month = month;
            this.year = year;
        }
    }
}
