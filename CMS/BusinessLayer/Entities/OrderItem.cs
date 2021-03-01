using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public class OrderItem : EntityBase
    {
        private Guid _guid;
        private Guid _productGuid;
        private double? _purchasePrice;
        private int _quantity;
        private int _orderId;


        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public Guid ProductGuid
        {
            get
            {
                return _productGuid;
            }
            set
            {
                _productGuid = value;
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
            _guid = Guid.NewGuid();
            _orderId = orderId;
        }
        public OrderItem(Guid guid, int orderId, Guid productGuid, double purchasePrice, int quantity)
        {
            _guid = guid;
            _orderId = orderId;
            _productGuid = productGuid;
            _purchasePrice = purchasePrice;
            _quantity = quantity;
        }


        public override bool Validate()
        {
            var result = true;

            if (Guid == Guid.Empty)
                result = false;
            if (OrderId <= 0)
                result = false;
            if (ProductGuid == Guid.Empty)
                result = false;
            if (Quantity <= 0)
                result = false;
            if (PurchasePrice == null)
                result = false;

            return result;
        }
    }
}
