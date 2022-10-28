using System;
using System.Collections.Generic;

namespace SE1634_Group5_A3.Models
{
    public partial class Album
    {
        public Album()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumUrl { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
