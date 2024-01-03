using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MinimalAPIDemoApp.Entities
{

    [Table("products")]
    public class Product
    {

        [Column("productid")]
        public int ProductId{get;set;}  

        [Column("title")]
        public string?  Title{get;set;}

        [Column("description")]
        public string?  Description{get;set;}

        [Column("price")]
        public double Price{get;set;}
    }
}