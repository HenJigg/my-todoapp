using MyToDo.Common;
using MyToDo.Common.Models;
using MyToDo.Extensions;
using MyToDo.Service;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class MemoViewModel : NavigationViewModel
    {
        private readonly IDialogHostService dialogHost;

        public MemoViewModel(IMemoService service, IContainerProvider provider)
           : base(provider)
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<MemoDto>(Selected);
            DeleteCommand = new DelegateCommand<MemoDto>(Delete);
            dialogHost = provider.Resolve<IDialogHostService>();
            this.service = service;
        }

        private async void Delete(MemoDto obj)
        {
            try
            {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认删除备忘录:{obj.Title} ?");
                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;

                UpdateLoading(true);
                var deleteResult = await service.DeleteAsync(obj.Id);
                if (deleteResult.Status)
                {
                    var model = MemoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (model != null)
                        MemoDtos.Remove(model);
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增": Add(); break;
                case "查询": GetDataAsync(); break;
                case "保存": Save(); break;
            }
        }

        private string search;

        /// <summary>
        /// 搜索条件
        /// </summary>
        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }

        private bool isRightDrawerOpen;

        /// <summary>
        /// 右侧编辑窗口是否展开
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        private MemoDto currentDto;

        /// <summary>
        /// 编辑选中/新增时对象
        /// </summary>
        public MemoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加备忘录
        /// </summary>
        private void Add()
        {
            CurrentDto = new MemoDto();
            IsRightDrawerOpen = true;
        }

        private async void Selected(MemoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var todoResult = await service.GetFirstOfDefaultAsync(obj.Id);
                if (todoResult.Status)
                {
                    CurrentDto = todoResult.Result;
                    IsRightDrawerOpen = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title) ||
                string.IsNullOrWhiteSpace(CurrentDto.Content))
                return;

            UpdateLoading(true);

            try
            {
                if (CurrentDto.Id > 0)
                {
                    var updateResult = await service.UpdateAsync(CurrentDto);
                    if (updateResult.Status)
                    {
                        var todo = MemoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        if (todo != null)
                        {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                        }
                    }
                    IsRightDrawerOpen = false;
                }
                else
                {
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult.Status)
                    {
                        MemoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpdateLoading(false);
            }
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<MemoDto> SelectedCommand { get; private set; }
        public DelegateCommand<MemoDto> DeleteCommand { get; private set; }

        private ObservableCollection<MemoDto> memoDtos;
        private readonly IMemoService service;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        async void GetDataAsync()
        {
            UpdateLoading(true);

            var todoResult = await service.GetAllAsync(new QueryParameter()
            {
                PageIndex = 0,
                PageSize = 100,
                Search = Search,
            });

            if (todoResult.Status)
            {
                MemoDtos.Clear();
                foreach (var item in todoResult.Result.Items)
                {
                    MemoDtos.Add(item);
                }
            }
            UpdateLoading(false);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            GetDataAsync();
        }
    }
}
