using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TypingSpeed
{
    public class Record
    {
        public Record()
        {

        }
        public Record( string name, int minute, float second)
        {
            this.Name = name;
            this.SymbolPerMinute = minute;
            this.SymbolPerSecond = second;
        }
        public string Name { get; set; }    
        public int SymbolPerMinute { get; set; }
        public float SymbolPerSecond { get; set; }

       /* public Record(string nameArg, int charsPerMinuteArg)
        {
            Name = nameArg;
            SymbolPerMinute = charsPerMinuteArg;
            SymbolPerSecond = (float)charsPerMinuteArg / 60;
        }

        public static List<Record> Serializing(string name, int index)
        {
            string json = File.ReadAllText("C:\\Users\\tosya\\OneDrive\\Рабочий стол\\не существует\\Record.json");
            List<Record> users = JsonConvert.DeserializeObject<List<Record>>(json);
            Record user = new Record(name, index);
            users.Add(user);

            json = JsonConvert.SerializeObject(users);
            File.WriteAllText("C:\\C#\\ConsoleApp11\\record.json", json);

            return users;
        }*/


    }
}
