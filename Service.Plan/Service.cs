using Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Service.Plan
{
    [Export(typeof(IService))]
    public class Service : IService
    {
        public bool IsRunNow
        {
            get;
            set;
        }

        public string ServiceId
        {
            get
            {
                return "5A9EC8EA-2E07-4517-8F0B-BAE1445F7CE7";
            }
        }

        public string ServiceName
        {
            get
            {
                return "计划服务";
            }
        }

        public bool ServiceStatus
        {
            get;
            private set;
        }

        public ServiceType Type
        {
            get
            {
                return ServiceType.Plan;
            }
        }

        public void ShowManagerView()
        {
            //TODO 显示管理界面
            MessageBox.Show("管理界面");
        }

        public Result StartService()
        {
            if (!this.ServiceStatus)
            {
                //TODO 启动服务逻辑
                this.ServiceStatus = true;

                if (IsRunNow)
                {
                    return new Result()
                    {
                        ServiceId = this.ServiceId,
                        IsSuccess = true,
                        Messages = new List<string>() { ServiceName + "服务启动成功,立即执行" }
                    };
                }
                return new Result()
                {
                    ServiceId = this.ServiceId,
                    IsSuccess = true,
                    Messages = new List<string>() { ServiceName + "服务启动成功" }
                };
            }

            return new Result()
            {
                ServiceId = this.ServiceId,
                IsSuccess = false,
                Messages = new List<string>() { ServiceName + "启动失败，当前服务状态已启动" }
            };
        }

        public Result StopService()
        {
            if (this.ServiceStatus)
            {
                //TODO 启动服务逻辑
                this.ServiceStatus = false;

                if (IsRunNow)
                {
                    return new Result()
                    {
                        ServiceId = this.ServiceId,
                        IsSuccess = true,
                        Messages = new List<string>() { ServiceName + "服务停止成功,立即执行" }
                    };
                }
                return new Result()
                {
                    ServiceId = this.ServiceId,
                    IsSuccess = true,
                    Messages = new List<string>() { ServiceName + "服务停止成功" }
                };
            }

            return new Result()
            {
                ServiceId = this.ServiceId,
                IsSuccess = false,
                Messages = new List<string>() { ServiceName + "停止失败，当前服务状态已停止" }
            };
        }
    }
}
