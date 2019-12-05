using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace prob5.Core
{
    [Serializable]
    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {
        private DateTime date;

        public BusinessDate(DateTime dt)
        {
            this.date = dt;
        }

        public DateTime Date
        {
            get { return this.date; }
        }

        public int Day
        {
            get { return this.date.Day; }
        }

        public int Month
        {
            get { return this.date.Month; }
        }
        
        public int Year
        {
            get { return this.date.Year; }
        }
        /*
        public string Timestamp
        {
            get { return this.date.TimeOfDay; }
        }
        */
        public int CompareTo([AllowNull] BusinessDate other)
        {
            if (this.Date == other.Date)
            {
                return 0;
            }

            return this.Date > other.Date ? 1 : -1;
        }

        public bool Equals([AllowNull] BusinessDate other)
        {
            return this.Date == other.Date;
        }

        public override string ToString()
        {
            return this.ToString("d", CultureInfo.CurrentCulture);
        }

        // IFormattable
        public string ToString(string format) 
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "d";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            string[] formats = {"d", "D", "f", "F", "g", "G", "m", "o", "r", "s", "t", "T", "u", "U", "Y"};

            if ( ! formats.Contains(format))
            {
                throw new FormatException($"The {format} format is not supported.");
            }

            return this.Date.ToString(format, provider);
        }

        // IXmlSerializable
        public XmlSchema GetSchema()
        {
            return (null);
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == GetType().ToString())
            {
                int day  = Int32.Parse(reader.GetAttribute("Day"));
                int month = Int32.Parse(reader.GetAttribute("Month"));
                int year  = Int32.Parse(reader.GetAttribute("Year"));
                int hour  = Int32.Parse(reader.GetAttribute("Hour"));
                int minute  = Int32.Parse(reader.GetAttribute("Minute"));
                int second  = Int32.Parse(reader.GetAttribute("Second"));

                this.date = new DateTime(year, month, day, hour, minute, second);
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Day", this.Day.ToString());
            writer.WriteAttributeString("Month", this.Month.ToString());
            writer.WriteAttributeString("Year", this.Year.ToString());
            writer.WriteAttributeString("Hour", this.Date.Hour.ToString());
            writer.WriteAttributeString("Minute", this.Date.Minute.ToString());
            writer.WriteAttributeString("Second", this.Date.Second.ToString());

            writer.WriteStartElement("Formatted");
            writer.WriteAttributeString("Culture", CultureInfo.CurrentCulture.ToString());
            writer.WriteEndElement();
        }
    }
}
