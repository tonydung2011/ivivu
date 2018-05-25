using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Http;
using ivivu.Models;
using ivivu.lib;

namespace ivivu.Controllers
{
    public class HoaDonController : ApiController
    {
		database db = new database();

		public JsonResult getAll()
		{
			IEnumerable<Object> ls = db.layTatCaHoaDon();
			int count = ls.Count();
			JsonResult result = new JsonResult();
			result.Data = new
			{
				data = ls,
				length = count
			};
			return result;
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
