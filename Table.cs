using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TypingSpeed
{
    public class Table
    {
        static List<Record> records = new List<Record>();

        public bool AddItem( string name, int minute, float second)
        {
            if (!records.Any(item => item.Name == name))
            {
                records.Add(new Record( name, minute, second));
                return true;
            }
            return false;
        }
        static void AddRecords(Record record)
        {
            records.Add(record);
        }

        public static void Serialize()
        {
            string json = JsonConvert.SerializeObject(records);
            
            File.WriteAllText("C:\\Users\\tosya\\OneDrive\\Рабочий стол\\не существует\\Record.json", json);

        }
        

        public  void WriteReccord()
        {
            foreach (Record record in records)
            {
                Console.WriteLine("имя: "+record.Name,"скорость в минутах: " + record.SymbolPerMinute, "скорость в секундах" + record.SymbolPerSecond);
            }
        }
    }
}
