using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccesLayer.Abstract
{
    public interface ICategory : IGenericDal<Category>
    {
        int GetCategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
    }
}
