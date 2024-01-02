using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MinimalAPIDemoApp.Entities
{

    [Table("products")]
    public class Product
    {
        public int ProductId{get;set;}  
        public string?  Title{get;set;}
        public string?  Description{get;set;}
        public double Price{get;set;}
    }
}