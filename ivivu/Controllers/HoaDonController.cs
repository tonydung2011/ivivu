using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Http;
using ivivu.Models;
using ivivu.lib;
using Newtonsoft.Json;

namespace ivivu.Controllers
{
    public class HoaDonController : ApiController
    {
		database db = new database();

        public string getAll()
        {
            List<HoaDon> ls = db.layTatCaHoaDon();
            int count = ls.Count();
            return JsonConvert.SerializeObject(new {
                data = ls,
                length = count
            });
		}

		public JsonResult getHoaDon(string id)
		{
			HoaDon hoaDon = db.timHoaDon(id);
			JsonResult result = new JsonResult();
			result.Data = hoaDon;
			return result;
		}
    }
}
