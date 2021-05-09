using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web_Service.Models;

namespace Web_Service.Helpers
{
    static public class JWriter<T>
    {
        static public string Write(in T collection, string current_data = null)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            try
            {
                using (Newtonsoft.Json.JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartArray();

                    foreach (var item in (System.Collections.IList)collection)
                    {
                        writer.WriteStartObject();

                        writer.WritePropertyName("ObjectName");
                        writer.WriteValue((item as FootballFieldInfo).ObjectName);

                        writer.WritePropertyName("AdmArea");
                        writer.WriteValue((item as FootballFieldInfo).AdmArea);

                        writer.WritePropertyName("District");
                        writer.WriteValue((item as FootballFieldInfo).District);

                        writer.WritePropertyName("Address");
                        writer.WriteValue((item as FootballFieldInfo).Address);

                        writer.WritePropertyName("Email");
                        writer.WriteValue((item as FootballFieldInfo).Email);

                        writer.WritePropertyName("WebSite");
                        writer.WriteValue((item as FootballFieldInfo).WebSite);

                        writer.WritePropertyName("HelpPhone");
                        writer.WriteValue((item as FootballFieldInfo).HelpPhone);

                        
                        writer.WritePropertyName("WorkingHoursWinter");
                        writer.WriteStartArray();
                        foreach (var element in (item as FootballFieldInfo).WorkingHoursWinter)
                        {
                            writer.WriteStartObject();

                            writer.WritePropertyName("DayOfWeek");
                            writer.WriteValue(element.DayOfWeek);

                            writer.WritePropertyName("Hours");
                            writer.WriteValue(element.Hours);

                            writer.WriteEndObject();
                        }
                        writer.WriteEnd();


                        writer.WritePropertyName("HasEquipmentRental");
                        writer.WriteValue((item as FootballFieldInfo).HasEquipmentRental);

                        writer.WritePropertyName("HasTechService");
                        writer.WriteValue((item as FootballFieldInfo).HasTechService);

                        writer.WritePropertyName("HasDressingRoom");
                        writer.WriteValue((item as FootballFieldInfo).HasDressingRoom);

                        writer.WritePropertyName("HasDressingRoom");
                        writer.WriteValue((item as FootballFieldInfo).HasDressingRoom);

                        writer.WritePropertyName("HasEatery");
                        writer.WriteValue((item as FootballFieldInfo).HasEatery);

                        writer.WritePropertyName("HasToilet");
                        writer.WriteValue((item as FootballFieldInfo).HasToilet);

                        writer.WritePropertyName("HasWifi");
                        writer.WriteValue((item as FootballFieldInfo).HasWifi);

                        writer.WritePropertyName("HasCashMachine");
                        writer.WriteValue((item as FootballFieldInfo).HasCashMachine);

                        writer.WritePropertyName("HasFirstAidPost");
                        writer.WriteValue((item as FootballFieldInfo).HasFirstAidPost);

                        writer.WritePropertyName("HasMusic");
                        writer.WriteValue((item as FootballFieldInfo).HasMusic);

                        writer.WritePropertyName("Lighting");
                        writer.WriteValue((item as FootballFieldInfo).Lighting);

                        writer.WritePropertyName("SurfaceTypeWinter");
                        writer.WriteValue((item as FootballFieldInfo).SurfaceTypeWinter);

                        writer.WritePropertyName("Seats");
                        writer.WriteValue((item as FootballFieldInfo).Seats);

                        writer.WritePropertyName("Paid");
                        writer.WriteValue((item as FootballFieldInfo).Paid);

                        writer.WritePropertyName("DisabilityFriendly");
                        writer.WriteValue((item as FootballFieldInfo).DisabilityFriendly);

                        writer.WriteEndObject();
                    }

                    writer.WriteEnd();

                    if (current_data != "\r\n" && !string.IsNullOrEmpty(current_data))
                    {
                        JArray current_doc = JArray.Parse(current_data);

                        JArray new_data = JArray.Parse(sb.ToString());
                        var child_new_data = new_data.Children();

                        current_doc.Add(child_new_data);

                        return current_doc.ToString();

                    }

                    return sb.ToString();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }
    }
}