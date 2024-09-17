using SignalR.DataAccesLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.DataAccesLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccesLayer.EntityFramework
{
    public class EfSocialMedia : GenericRepository<SocialMedia>, ISocialMedia
    {
        public EfSocialMedia(SignalRContext context) : base(context)
        {
        }
    }
}
