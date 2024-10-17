using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;


namespace ServiceLayer.Abstract
{
    public interface IDataService
    {
        // modelimdeki nesneleri liste olarak alıcam List<>
        Task<List<MyDataModel>> GetFilteredDataAsync(DateTime startDate, DateTime endDate, FilterTypeEnum type);
    }
}
