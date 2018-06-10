using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ivivu.DAL;
using ivivu.Models;
using Newtonsoft.Json;

namespace ivivu.Controllers
{
    public class DatPhongsController : ApiController
    {
        private IvivuContext db = new IvivuContext();

        // GET: api/DatPhongs
        public string GetDatPhongs()
        {
            List<DatPhong> ls = db.DatPhongs.ToList();
            int count = ls.Count();
            return JsonConvert.SerializeObject(new
            {
                data = ls,
                length = count
            });
        }

        // GET: api/DatPhongs/5
        [ResponseType(typeof(DatPhong))]
        public IHttpActionResult GetDatPhong(string id)
        {
            DatPhong datPhong = db.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return NotFound();
            }

            return Ok(datPhong);
        }
    }
}