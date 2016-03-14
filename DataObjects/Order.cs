using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace XamarinCRMv2CatalogDataService.DataObjects
{
    public class Order : EntityData
    {
        
       
        public bool IsOpen { get; set; }

        
        public string AccountId { get; set; }

       
        public double Price { get; set; }

       
        public string Item { get; set; }

       
        public DateTime OrderDate { get; set; }

        
        public DateTime DueDate { get; set; }

        
        public DateTime? ClosedDate { get; set; }
        public DateTime __createdAtDateTime
        {
            get { return CreatedAt.HasValue ? CreatedAt.Value.DateTime : DateTime.Now; }
            set { CreatedAt = value; }
        }

        public DateTime __updatedAtDateTime
        {
            get { return UpdatedAt.HasValue ? UpdatedAt.Value.DateTime : DateTime.Now; }
            set { UpdatedAt = value; }
        }


    }
}