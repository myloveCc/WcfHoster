﻿using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Model;

namespace Service.Manager
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
                return "531AFA17-F29F-48B2-AA29-E39137B24089";
            }
        }

        public string ServiceName
        {
            get
            {
                return "管理服务";
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
                return ServiceType.Normal;
            }
        }

        public void ShowManagerView()
        {
          
        }


        public Result StartService()
        {
            if (!this.ServiceStatus)
            {
                //TODO 启动服务逻辑
                this.ServiceStatus = true;
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
                //TODO 停止服务逻辑
                this.ServiceStatus = false;

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
