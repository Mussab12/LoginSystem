namespace LoginSystem.Helpers;
    public static class JSONListHelper
    {
    public static string GetEventListJSONString(List<LoginSystem.Models.Event> events)
   {
       var eventlist=new List<Event>();
        foreach(var model in events)
        {
            var myevents = new Event()
            {
                id = (int)model.ID,
                start = (DateTime)model.StartTime,
                end=(DateTime)model.EndTime,
                description = model.Description,
                title=model.Name


            };
            eventlist.Add(myevents);

        }
        return System.Text.Json.JsonSerializer.Serialize(eventlist);
   }
    }
   public class Event
    {
        public int id { get; set; }
        public DateTime ?start { get; set; }
    public DateTime ?end { get; set; }
        public string ?title { get; set; }
        
    public string ?description { get; set; }
}
//public class Resource
//{
//    public int id { get; set; }
//    public string titel { get; set; }
//}