using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Service.Models;
using Web_Service.Helpers;

namespace Web_Service.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly FootballFieldsdbMainContext db;
        private string datanumber = "886",
                       api_key = "1ae133421fb89a94b0195077f4c17818";

        public DataController(FootballFieldsdbMainContext context)
        {
            db = context;
        }

        [HttpGet("api/[controller]/Show")]
        public async Task<IActionResult> Show()
        {
            return Ok(JWriter<List<FootballFieldInfo>>.Write(await db.FootballFields.Include(s => s.WorkingHoursWinter).ToListAsync()));
        }

        [HttpGet("api/[controller]/Create")]
        public async Task<IActionResult> Create() 
        {
            try
            {
                string data = Req_h.Resp($"https://apidata.mos.ru/v1/datasets/{datanumber}/rows/?api_key={api_key}");
                
                var Deser_Obj = JDeserializer<List<FootballField>>.Deser(data);

                db.FootballFields.RemoveRange(db.FootballFields);

                foreach (var item in Deser_Obj)
                {
                    await db.AddAsync(item.Cells);
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return Ok("Данные записаны");
        }

        [HttpGet("api/[controller]/Update")]
        public async Task<IActionResult> Update()
        {
            int current_count = await db.FootballFields.CountAsync(), count = 0;

            try
            {
                count = int.Parse(Req_h.Resp($"https://apidata.mos.ru/v1/datasets/{datanumber}/count/?api_key={api_key}"));

                if (current_count < count)
                {
                    string data = Req_h.Resp($"https://apidata.mos.ru/v1/datasets/{datanumber}/rows/?api_key={api_key}&$orderby=global_id%20desc&$top=" + (count - current_count));

                    var Deser_Obj = JDeserializer<List<FootballField>>.Deser(data);

                    foreach (var item in Deser_Obj)
                    {
                        await db.AddAsync(item.Cells);
                    }

                    await db.SaveChangesAsync();

                    return Ok("Данные обновлены");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            return Ok("Данные не требуют обновления");
        }

        [HttpGet("api/[controller]/Export")]
        public async Task<IActionResult> Export()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("DataFile.json", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(JWriter<List<FootballFieldInfo>>.Write(await db.FootballFields.Include(s => s.WorkingHoursWinter).ToListAsync()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok("Данные экспортированны в формат .json");
        }

    }
}