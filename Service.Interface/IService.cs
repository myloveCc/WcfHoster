using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service.Interface
{
    public interface IService
    {
        /// <summary>
        /// 服务Id
        /// </summary>
        string ServiceId { get; }

        /// <summary>
        /// 服务名称
        /// </summary>
        string ServiceName { get; }

        /// <summary>
        /// 服务状态
        /// </summary>
        bool ServiceStatus { get; }

        /// <summary>
        /// 服务类型
        /// </summary>
        ServiceType Type { get; }

        /// <summary>
        /// 是否立刻执行
        /// </summary>
        bool IsRunNow { get; set; }

        /// <summary>
        /// 显示管理界面
        /// </summary>
        void ShowManagerView();

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <returns></returns>
        Result StartService();

        /// <summary>
        /// 暂停敷衍我
        /// </summary>
        /// <returns></returns>
        Result StopService();
    }
}
