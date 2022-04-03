using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using TigerHallKittensWebAPI.Controllers;
using TigerHallKittensWebAPI.Models;
using TigerHallKittensWebAPI.Models.DTO;

namespace TigerHallKittensWebAPI.Tests
{
    [TestClass]
    public class TigerTests
    {
        //[TestMethod]
        //public void CreateTiger_ShouldReturnSameTiger()
        //{
        //    var controller = new TigerController(new TestdbContextTigerhallKittens());

        //    var item = GetDemoTigerSighting();

        //    var result =
        //        controller.GetAllSightingsOfATiger(item) as CreatedAtRouteNegotiatedContentResult<TigerSightingDTO>;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(result.RouteName, "DefaultApi");
        //    Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
        //    Assert.AreEqual(result.Content.Name, item.Name);
        //}

        [TestMethod]
        public void GetAllTigersOrderedByLastSeenTimeStamp_ShouldReturnAllProducts()
        {
            var context = new TestdbContextTigerhallKittens();
            context.Tigers.Add(new Tiger { ID = 1, Name = "Demo1", DateOfBirth = DateTime.Now });
            context.Tigers.Add(new Tiger { ID = 2, Name = "Demo2", DateOfBirth = DateTime.Now });
            context.Tigers.Add(new Tiger { ID = 3, Name = "Demo3", DateOfBirth = DateTime.Now });
            context.Tigers.Add(new Tiger { ID = 4, Name = "Demo4", DateOfBirth = DateTime.Now });
            context.Tigers.Add(new Tiger { ID = 5, Name = "Demo5", DateOfBirth = DateTime.Now });

            var controller = new TigerController(context);
            var result = controller.GetAllTigersOrderedByLastSeenTimeStamp() as List<TigerTimeViewDTO>;

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
        }

        TigerSightingDTO GetDemoTigerSighting()
        {
            return new TigerSightingDTO()
            { TigerId = 12, Longitude = 1.2, Latitude = 100 };
        }

    }
}
