using ParkWebApp.Models;
using ParkWebApp.Repository.irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkWebApp.Repository
{
    public class TrailRepository:Repository<Trail>,ITrailReposiory
    {
        public TrailRepository(IHttpClientFactory httpclientfactorry):base(httpclientfactorry)
        {

        }
    }
}
