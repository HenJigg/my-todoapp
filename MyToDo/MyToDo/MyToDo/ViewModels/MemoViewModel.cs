using MyToDo.Common.Models;
using MyToDo.Service;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class MemoViewModel : BindableBase
    {
        public MemoViewModel(IMemoService service)
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            AddCommand = new DelegateCommand(Add);
            this.service = service;
            CreateToDoList();
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

        /// <summary>
        /// 添加备忘录
        /// </summary>
        private void Add()
        {
            IsRightDrawerOpen = true;
        }

        public DelegateCommand AddCommand { get; private set; }

        private ObservableCollection<MemoDto> memoDtos;
        private readonly IMemoService service;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }


        async void CreateToDoList()
        {

            var memoResult = await service.GetAllAsync(new Shared.Parameters.QueryParameter()
            {
                PageIndex = 0,
                PageSize = 100, 
            });

            if (memoResult.Status)
            {
                foreach (var item in memoResult.Result.Items)
                {
                    MemoDtos.Add(item);
                }
            }
        }
    }
}
