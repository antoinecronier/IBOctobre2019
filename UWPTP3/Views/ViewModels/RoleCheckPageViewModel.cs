using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTP3.Entities;
using UWPTP3.Views.ViewModels.UcAccessors;
using UWPTP3.Views.ViewModels.UcAccessors.Roles;

namespace UWPTP3.Views.ViewModels
{
    public class RoleCheckPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public RolePageAccessor Datas { get; set; }

        public RoleCheckPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            SetupDatas();
        }

        private void SetupDatas()
        {
            Datas = new RolePageAccessor();
            SetupRoleEdit();
            SetupRoleList();
            SetupRoleShow();
        }

        private void SetupRoleShow()
        {
            Datas.RoleShow.Role = new Role();
        }

        private void SetupRoleList()
        {
            Datas.RoleList.Roles = new ObservableCollection<Role>();
            Datas.RoleList.ListView.SelectedItem = new Role();
            Datas.RoleList.ListView.SelectionChanged = new RelayCommand(RoleListSelectionChanged);
        }

        private void RoleListSelectionChanged()
        {
            Role role = Datas.RoleList.ListView.SelectedItem;
            if (role != null)
            {
                Datas.RoleShow.Role.CopyFrom(role);
            }
        }

        private void SetupRoleEdit()
        {
            Datas.RoleEdit.Button.Content = "Valider";
            Datas.RoleEdit.Button.Action = new RelayCommand(RoleEditCommand);
            Datas.RoleEdit.Role = new Role();
        }

        private void RoleEditCommand()
        {
            Role role = new Role();
            role.CopyFrom(Datas.RoleEdit.Role);
            Datas.RoleList.Roles.Add(role);
        }
    }
}
