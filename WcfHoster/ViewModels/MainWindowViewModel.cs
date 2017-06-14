using Prism.Mvvm;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Model;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace WcfHoster.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        #region MEF Services
        [ImportMany(typeof(IService))]
        public IEnumerable<IService> ImportedServices { get; set; }
        #endregion

        #region Property

        private string _MessageContent = string.Empty;
        public string MessageContent
        {
            get
            {
                return _MessageContent;
            }
            set
            {
                SetProperty(ref _MessageContent, value);
                RaisePropertyChanged("MessageContent");
            }
        }

        private ObservableCollection<WcfService> _WcfServices;
        public ObservableCollection<WcfService> WcfServices
        {
            get
            {
                return _WcfServices;
            }
            set
            {
                SetProperty(ref _WcfServices, value);
                RaisePropertyChanged("WcfServices");
            }
        }

        private WcfService _WcfServiceSelect;
        public WcfService WcfServiceSelect
        {
            get
            {
                return _WcfServiceSelect;
            }
            set
            {
                SetProperty(ref _WcfServiceSelect, value);
                RaisePropertyChanged("WcfServiceSelect");
            }
        }


        #endregion

        #region Command

        /// <summary>
        /// 启动服务
        /// </summary>
        public ICommand StartServiceCommand { get; private set; }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public ICommand StopServiceCommand { get; private set; }

        /// <summary>
        /// 管理服务
        /// </summary>
        public ICommand ManageServiceCommand { get; private set; }

        #endregion


        public MainWindowViewModel()
        {
            ImportService();

            InitCommand();
        }

        /// <summary>
        /// 初始化服务
        /// </summary>
        private void ImportService()
        {
            var catalog = new DirectoryCatalog(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "services"));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            InitWcfServices();
        }

        /// <summary>
        /// 初始化命令
        /// </summary>
        private void InitCommand()
        {
            StartServiceCommand = new DelegateCommand<object>(StartServcie);
            StopServiceCommand = new DelegateCommand<object>(StopServcie);
            ManageServiceCommand = new DelegateCommand<object>(ManageService);
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="serviceId"></param>
        private void StartServcie(object serviceItem)
        {
            ((ListBoxItem)serviceItem).IsSelected = true;

            var serviceId = WcfServiceSelect.ServiceId;

            var service = ImportedServices.FirstOrDefault(m => m.ServiceId == serviceId);

            if (WcfServiceSelect.Type == ServiceType.Plan)
            {
                service.IsRunNow = WcfServiceSelect.IsRunNow;
            }

            //启动服务
            var result = service.StartService();

            if (result.IsSuccess)
            {
                foreach (var message in result.Messages)
                {
                    MessageContent += message + Environment.NewLine;
                }

                InitWcfServices(serviceId, true);
            }
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="serviceId"></param>
        private void StopServcie(object serviceItem)
        {
            ((ListBoxItem)serviceItem).IsSelected = true;

            var serviceId = WcfServiceSelect.ServiceId;

            var service = ImportedServices.FirstOrDefault(m => m.ServiceId == serviceId);

            if (WcfServiceSelect.Type == ServiceType.Plan)
            {
                service.IsRunNow = WcfServiceSelect.IsRunNow;
            }

            //停止服务
            var result = service.StopService();

            if (result.IsSuccess)
            {
                foreach (var message in result.Messages)
                {
                    MessageContent += message + Environment.NewLine;
                }

                InitWcfServices(serviceId, false);
            }
        }

        /// <summary>
        /// 管理服务
        /// </summary>
        /// <param name="serviceItem"></param>
        private void ManageService(object serviceItem)
        {
            ((ListBoxItem)serviceItem).IsSelected = true;

            var serviceId = WcfServiceSelect.ServiceId;

            var service = ImportedServices.FirstOrDefault(m => m.ServiceId == serviceId);

            //管理服务
            service.ShowManagerView();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitWcfServices(string serviceId = "", bool status = false)
        {
            var wcfServices = new ObservableCollection<WcfService>();
            foreach (var service in ImportedServices)
            {
                var wcfService = new WcfService()
                {
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName,
                    ServiceStatus = service.ServiceStatus,
                    IsRunNow = service.IsRunNow,
                    Type = service.Type
                };

                if (string.Equals(wcfService.ServiceId, serviceId, StringComparison.OrdinalIgnoreCase))
                {
                    wcfService.ServiceStatus = status;
                }

                wcfServices.Add(wcfService);
            }
            WcfServices = wcfServices;
        }
    }
}
