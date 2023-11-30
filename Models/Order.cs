using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleFirebase.Models
{
    [FirestoreData]
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime date { get; set; }
        [FirestoreProperty]
        [Required]
        public string CustomerName { get; set; }
        [FirestoreProperty]
        public int Freight { get; set; }
        [FirestoreProperty]
        public string ShipCountry { get; set; }
    }
}
