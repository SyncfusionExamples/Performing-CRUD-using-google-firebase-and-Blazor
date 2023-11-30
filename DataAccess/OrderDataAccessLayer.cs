using GoogleFirebase.Interface;
using GoogleFirebase.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleFirebase.DataAccess
{
    public class OrderDataAccessLayer : IOrder
    {
        string projectId;
        FirestoreDb firestoreDb;
        public OrderDataAccessLayer()
        {
            //Get the key json file from firestore database and change the dbFilePath to that location.
            string dbFilePath = "D:\\Work\\webinar-blazor-fireapp-firebase-adminsdk-xs9of-bc0b94a7e1.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", dbFilePath);
            //Get the project id of firestore database and paste that here.
            projectId = "webinar-blazor-fireapp";
            firestoreDb = FirestoreDb.Create(projectId);
        }
        public async void AddOrder(Order order)
        {
            try
            {
                //orders is the collection name used in the firestore database
                CollectionReference collectionReference = firestoreDb.Collection("orders");
                await collectionReference.AddAsync(order);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void DeleteOrder(string orderId)
        {
            try
            {
                DocumentReference documentReference = firestoreDb.Collection("orders").Document(orderId);
                await documentReference.DeleteAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                Query orderQuery = firestoreDb.Collection("orders");
                QuerySnapshot orderQuerySnapshot = await orderQuery.GetSnapshotAsync();
                List<Order> lstOrder = new List<Order>();

                foreach (DocumentSnapshot documentSnapshot in orderQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> dictionary = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(dictionary);
                        Order neworder = JsonConvert.DeserializeObject<Order>(json);
                        neworder.OrderId = documentSnapshot.Id;
                        neworder.date = documentSnapshot.CreateTime.Value.ToDateTime();
                        lstOrder.Add(neworder);
                    }
                }

                List<Order> sortedOrders = lstOrder.OrderBy(x => x.date).ToList();
                return sortedOrders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdateOrder(Order order)
        {
            try
            {
                DocumentReference documentReference = firestoreDb.Collection("orders").Document(order.OrderId);
                await documentReference.SetAsync(order, SetOptions.Overwrite);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
