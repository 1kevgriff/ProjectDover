using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDover
{
    public class GameSession
    {
        public RoomManager RoomManager { get; set; }
        public Inventory Inventory{ get; set; }
        public List<string> KeyEvents{ get; set; }
        

        public GameSession(){
            RoomManager = new RoomManager();
            Inventory = new Inventory("Player Inventory");
            KeyEvents = new List<string>();
        }

        public string Summary(){
            StringBuilder summary = new  StringBuilder();

            summary.Append("Here your summary:");
 
            if(KeyEvents.Count > 0){
                summary.AppendFormat(Environment.NewLine);
                foreach(var keyevent in KeyEvents){
                    summary.AppendFormat("{0} ", keyevent);
                }
            }

            summary.AppendFormat("{0}{1}", Environment.NewLine, RoomManager.MapCoverage());

            return summary.ToString();

        }
    }
}