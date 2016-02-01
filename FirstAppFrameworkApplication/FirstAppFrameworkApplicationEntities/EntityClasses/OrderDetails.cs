﻿using AppFramework.AppClasses;
using AppFramework.AppClasses.EDTs;
using AppFramework.Linq;
using FirstAppFrameworkApplicationEntities.EDTs;
using FirstAppFrameworkApplicationEntities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppFrameworkApplicationEntities.EntityClasses
{
    partial class OrderDetails : EntityBase
    {
        protected override string Caption
        {
            get { return "Order Details"; }
        }

        protected override Type FormType
        {
            get { return typeof(Forms.Orders); }
        }

        protected override Type ListFormType
        {
            get { return typeof(Forms.Orders); }
        }

        public override string TableName
        {
            get { return "Orderdetails"; }
        }

        protected override string TitleColumn1
        {
            get { return "OrderID"; }
        }

        protected override string TitleColumn2
        {
            get { return "ItemID"; }
        }

        protected override void setupEntityInfo()
        {
            FieldInfoList["OrderID"] = new FieldInfo(false, false, true, new OrderEDT());
            FieldInfoList["ItemCategoryID"] = new FieldInfo(true, true, true, new ItemCategoryEDT());
            FieldInfoList["ItemID"] = new FieldInfo(true, true, true, new ItemEDT());
            FieldInfoList["Quantity"] = new FieldInfo(true, false, true, "Quantity", new IntEDT());
            FieldInfoList["Amount"] = new FieldInfo(false, false, true, "Amount", new AmountEDT());

            TableInfo.KeyInfoList["OrderID"] = new KeyInfo(KeyType.Key, "OrderID");
            TableInfo.KeyInfoList["ItemCategoryID"] = new KeyInfo(KeyType.Key, "ItemCategoryID");
            TableInfo.KeyInfoList["ItemID"] = new KeyInfo(KeyType.Key, "ItemID");
            TableInfo.KeyInfoList["CompositeKey"] = new KeyInfo(KeyType.Unique, "OrderID", "ItemCategoryID", "ItemID"); 
        }

        protected override long insert(bool forceWrite, bool callSaveMethod)
        {
            var unitPrice = (from item in new QueryableEntity<Items>()
                             where item.ItemID == this.ItemID
                             select item.Price).ToList();
            
            this.Amount = unitPrice[0] * this.Quantity;
            return base.insert(forceWrite, callSaveMethod);
        }
    }
}
