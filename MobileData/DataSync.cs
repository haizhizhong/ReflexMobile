using System;
using System.Diagnostics;

namespace MobileData
{
    public static class DataSync
    {

        public static async System.Threading.Tasks.Task RunSyncAsync()
        {
            DateTime startTime = DateTime.Now;

            //var task = LemLogHeader.Sync(DateTime.MinValue);
            //await task;

            var taskLoginUser = LoginUser.Sync();
            var taskCompany = Company.Sync();

            var taskEmployee = Employee.Sync();
            var taskEquipment = Equipment.Sync();
            var taskEquipmentClass = EquipmentClass.Sync();
            var taskProject = Project.Sync();
            var taskProjectWorkClass = ProjectWorkClass.Sync();
            var taskProjectEquipmentClass = ProjectEquipmentClass.Sync();
            var taskProjectOvertimeLimit = ProjectOvertimeLimit.Sync();
            var taskLabourTemplate = LabourTemplate.Sync();
            var taskEquipmentTemplate = EquipmentTemplate.Sync();

            await taskLoginUser;
            await taskCompany;

            await taskEmployee;
            await taskEquipment;
            await taskEquipmentClass;
            await taskProject;
            await taskProjectWorkClass;
            await taskProjectEquipmentClass;
            await taskProjectOvertimeLimit;
            await taskLabourTemplate;
            await taskEquipmentTemplate;

            Trace.WriteLine($"############# Seconds = {(DateTime.Now - startTime).Seconds}");
        }
    }
}
