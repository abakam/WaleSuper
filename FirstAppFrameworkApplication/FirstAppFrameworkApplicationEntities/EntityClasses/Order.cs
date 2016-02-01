using AppFramework.AppClasses;
using AppFramework.AppClasses.EDTs;
using FirstAppFrameworkApplicationEntities.EDTs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppFrameworkApplicationEntities.EntityClasses
{
    public partial class Order : EntityBase
    {
        const string OrderSEQUENCE = "OrderIDSequence";
        protected override string Caption
        {
            get { return "Orders"; }
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
            get { return "orders"; }
        }

        protected override string TitleColumn1
        {
            get { return "OrderID"; }
        }

        protected override string TitleColumn2
        {
            get { return "CustomerID"; }
        }

        protected override void setupEntityInfo()
        {
            FieldInfoList["OrderID"] = new FieldInfo(false, false, true, new OrderEDT());
            FieldInfoList["CustomerID"] = new FieldInfo(true, false, true, "Customer", new CustomerEDT());

            TableInfo.KeyInfoList["OrderID"] = new KeyInfo(KeyType.PrimaryField, "OrderID");
            TableInfo.KeyInfoList["CustomerID"] = new KeyInfo(KeyType.Key, "CustomerID");

            FieldGroups["grid"] = new String[] { "OrderID", "CustomerID", "CreatedBy", "CreatedDateTime" };
        }
        protected override long insert(bool forceWrite, bool callSaveMethod)
        {
            this.OrderID = AppFramework.AppClasses.AppEntities.NumberSequences.getNumber("OrderIDSequence");
            return base.insert(forceWrite, callSaveMethod);
        }
       
    }
}
