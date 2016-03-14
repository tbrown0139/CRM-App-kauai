using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;
using System;

namespace XamarinCRMv2CatalogDataService.DataObjects
{
    public class Category : EntityData
    {
        public Category ()
        {
            SubCategories = new List<Category>();
            Products = new List<Product>();
        }

        public virtual string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ParentCategoryId { get; set; }
        public int Sequence { get; set;}
        /// <summary>
        /// A helper property to determine whether or not this is a leaf-level category.
        /// </summary>
        public bool HasSubCategories {
            get { return SubCategories.Any(); }
        }

        // These three navigational properties will not be serialized. In the context 
        // where this class will be consumed by the client, these properties are unnecessary, 
        // and can be queried for in the API if necessary.

        [JsonIgnore]
        public virtual Category ParentCategory { get; set; }

        [JsonIgnore]
        public virtual ICollection<Category> SubCategories { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

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