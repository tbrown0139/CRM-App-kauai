
using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;
using System;

namespace XamarinCRMv2CatalogDataService.DataObjects
{
    public class Product : EntityData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public string CategoryId { get; set; }
        /// <summary>
        /// In many cases, it doesn't make sense to serialize a navigational property.
        /// But in this case, it will be useful to have the category data with the 
        /// product, in order to provide nicely grouped search results.
        /// </summary>
        public virtual Category Category { get; set; }

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