using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer
{
    public class OrderItem
    {
        public static int InstanceCount { get; set; }
        
        private int _id;
        private int _productId;
        private double? _purchasePrice;
        private int _quantity;
        private int _orderId;


        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public double? PurchasePrice
        {
            get { return _purchasePrice; }
            set { _purchasePrice = value; }
        }     
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public int OrderId
        {
            get { return _orderId; }
            private set { _orderId = value; }
        }
        

        public OrderItem(int orderId)
        {
            _orderId = orderId;
        }
        public OrderItem(int id, int orderId) : this(orderId)
        {
            _id = id;
        }

        
        public bool Validate()
        {
            var result = true;

            if (ProductId <= 0)
                result = false;
            if (Quantity <= 0)
                result = false;
            if (PurchasePrice == null)
                result = false;

            return result;
        }
    }
}
