using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public class OrderItem : EntityBase
    {
        private static int InstanceCount;

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
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
                HasChanges = true;
            }
        }
        public double? PurchasePrice
        {
            get
            {
                return _purchasePrice;
            }
            set
            {
                _purchasePrice = value;
                HasChanges = true;
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                HasChanges = true;
            }
        }
        public int OrderId
        {
            get { return _orderId; }
            private set { _orderId = value; }
        }


        public OrderItem(int orderId)
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
            _orderId = orderId;
        }
        public OrderItem(int id, int orderId, int productId, double purchasePrice, int quantity)
        {
            _id = id;
            _orderId = orderId;
            _productId = productId;
            _purchasePrice = purchasePrice;
            _quantity = quantity;
        }


        public override bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (OrderId <= 0)
                result = false;
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
