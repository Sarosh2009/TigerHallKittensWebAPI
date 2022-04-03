using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TigerHallKittensWebAPI.Models;
using TigerHallKittensWebAPI.Models.DTO;

namespace TigerHallKittensWebAPI.Controllers
{
    [RoutePrefix("api/TigerHallKittens")]
    public class TigerController : ApiController
    {
        public ITigerHallKittensContext db = new dbContextTigerhallKittens();

        /// <summary>
        /// Constructor
        /// </summary>
        public TigerController() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public TigerController(ITigerHallKittensContext context)
        {
            db = context;
        }

        /// <summary>
        /// Creates a Tiger.
        /// </summary>
        /// <param name="name">Name of the tiger</param>
        /// <param name="dateOfBirth">Date of birth</param>
        /// <param name="lastSeenTimeStamp">Last seen time</param>
        /// <param name="latitude">Latitide in degrees</param>
        /// <param name="longitude">Longitude in degrees</param>
        /// <returns></returns>
        [Route("CreateTiger/{Name}/{DateOfBirth}/{LastSeenTimeStamp}/{Latitude}/{Longitude}")]
        [HttpPost]
        
        public IHttpActionResult CreateTiger(string name, DateTime dateOfBirth, DateTime lastSeenTimeStamp, double latitude, double longitude)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new dbContextTigerhallKittens())
            {
                ctx.Database.ExecuteSqlCommand("CreateTiger @p0, @p1, @p2, @p3, @p4", name, dateOfBirth, lastSeenTimeStamp, latitude, longitude);
                ctx.SaveChanges();
            }

            return Ok();
        }
        
        [Route("GetAllTigersOrderedByLastSeenTimeStamp")]
        [HttpGet]
        public List<TigerTimeViewDTO> GetAllTigersOrderedByLastSeenTimeStamp()
        {
            using (dbContextTigerhallKittens dbContext = new dbContextTigerhallKittens())
            {
                string query = @"SELECT tigerid as ID, 
	                             (SELECT name FROM Tiger WHERE ID = tigerid) Name,
                                 (SELECT DateOfBirth FROM Tiger WHERE ID = tigerid) DateOfBirth,
                                  MAX(lastseentimestamp) AS LastSeenTimeStamp
                                 FROM TigerSighting  
                                GROUP BY tigerid 
                                ORDER BY Lastseentimestamp DESC";


                var result = dbContext.Database.SqlQuery<TigerTimeViewDTO>(query).ToList<TigerTimeViewDTO>();
                return (List<TigerTimeViewDTO>) result;
            }
        }          
        
        [Route("GetAllSightingsOfATiger/{tigerId}")]
        [HttpGet]
        public List<TigerSightingDTO> GetAllSightingsOfATiger(int tigerId)
        {
            using (dbContextTigerhallKittens dbContext = new dbContextTigerhallKittens())
            {
                List<TigerSighting> tigerSightings = dbContext.TigerSightings.Where(ts => ts.TigerId == tigerId).OrderByDescending(ts => ts.LastSeenTimeStamp).ToList();
                List<TigerSightingDTO> tigerSightingsDto = Mapper.Map<List<TigerSighting>, List<TigerSightingDTO>>(tigerSightings);
                return tigerSightingsDto;
            }
        }

        [Route("CreateTigerSighting/{tigerId}/{lastSeenTimeStamp}/{latitude}/{longitude}")]
        [HttpPost]
        public IHttpActionResult CreateTigerSighting(int tigerId, DateTime lastSeenTimeStamp, double latitude, double longitude)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new dbContextTigerhallKittens())
            {
                ctx.Database.ExecuteSqlCommand("CreateTigerSighting @p0, @p1, @p2, @p3", tigerId, longitude, latitude, lastSeenTimeStamp);
                ctx.SaveChanges();
            }

            return Ok();
        }


        //[HttpPost]
        //[Route("CreateTigerSighting")]
        //public Task CreateTigerSighting(IFormFile fileInput)
        //{
        //    //int tigerId, double longitude, double latitude, DateTime lastSeenTimeStamp,
        //    //if(tiger.ImagePath != null)
        //    //{
        //    //    System.Drawing.Image img;
        //    //    img = System.Drawing.Image.FromFile(tiger.ImagePath);
        //    //    Resize(img, 200, 250, true);
        //    //    UploadFile();
        //    //}

        //    using (var ctx = new TigerhallKittensEntities())
        //    {
        //        //ctx.Database.ExecuteSqlCommand("CreateTiger @p0, @p1, @p2, @p3, @p4", tigerId, longitude, latitude, lastSeenTimeStamp);
        //        //ctx.SaveChanges();
        //    }

        //    return Task.CompletedTask;
        //}

        /// <summary>  
        /// resize an image and maintain aspect ratio  
        /// </summary>  
        /// <param name="image">image to resize</param>  
        /// <param name="newWidth">desired width</param>  
        /// <param name="maxHeight">max height</param>  
        /// <param name="onlyResizeIfWider">if image width is smaller than newWidth use image width</param>  
        /// <returns>resized image</returns>  
        //private Image Resize(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider)
        //{
        //    if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

        //    var newHeight = image.Height * newWidth / image.Width;
        //    if (newHeight > maxHeight)
        //    {
        //        // Resize with height instead  
        //        newWidth = image.Width * maxHeight / image.Height;
        //        newHeight = maxHeight;
        //    }

        //    var res = new Bitmap(newWidth, newHeight);

        //    using (var graphic = Graphics.FromImage(res))
        //    {
        //        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphic.SmoothingMode = SmoothingMode.HighQuality;
        //        graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //        graphic.CompositingQuality = CompositingQuality.HighQuality;
        //        graphic.DrawImage(image, 0, 0, newWidth, newHeight);
        //    }

        //    return res;
        //}

        //public HttpResponseMessage UploadFile()
        //{
        //    HttpResponseMessage result = null;
        //    var httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Files.Count > 0)
        //    {
        //        var docfiles = new List<string>();
        //        foreach (string file in httpRequest.Files)
        //        {
        //            var postedFile = httpRequest.Files[file];
        //            var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
        //            postedFile.SaveAs(filePath);
        //            docfiles.Add(filePath);
        //        }
        //        result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
        //    }
        //    else
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //    return result;
        //}
    }
}