using AppFramework.AppClasses;
using AppFramework.AppClasses.EDTs;
using FirstAppFrameworkApplicationEntities.EDTs;
using FirstAppFrameworkApplicationEntities.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppFrameworkApplicationEntities.EntityClasses
{
    class Deduction : EntityBase
    {
        protected override string Caption
        {
            get { return "Deductions"; }
        }

        protected override Type FormType
        {
            get { return typeof(Deductions); }
        }

        protected override Type ListFormType
        {
            get { return typeof(Deductions); }
        }

        public override string TableName
        {
            get { return "deductions"; }
        }

        protected override string TitleColumn1
        {
            get { return "DeductionID"; }
        }

        protected override string TitleColumn2
        {
            get { return "Description"; }
        }

        protected override void setupEntityInfo()
        {
            FieldInfoList["DeductionID"] = new FieldInfo(false, false, true, new DeductionEDT());
            FieldInfoList["Description"] = new FieldInfo(true, true, true, new ShortDescriptionEDT());

        }
    }
}
