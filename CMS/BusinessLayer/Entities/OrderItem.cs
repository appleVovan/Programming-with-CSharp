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
        private Guid _orderGuid;


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
        public Guid OrderGuid
        {
            get { return _orderGuid; }
            private set { _orderGuid = value; }
        }


        public OrderItem(Guid orderGuid)
        {
            IsNew = true;
            _guid = Guid.NewGuid();
            _orderGuid = orderGuid;
        }
        public OrderItem(Guid guid, Guid orderGuid, Guid productGuid, double purchasePrice, int quantity)
        {
            _guid = guid;
            _orderGuid = orderGuid;
            _productGuid = productGuid;
            _purchasePrice = purchasePrice;
            _quantity = quantity;
        }


        public override bool Validate()
        {
            var result = true;

            if (Guid == Guid.Empty)
                result = false;
            if (OrderGuid == Guid.Empty)
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
