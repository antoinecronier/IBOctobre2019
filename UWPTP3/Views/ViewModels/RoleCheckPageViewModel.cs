using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTP3.Entities;
using UWPTP3.Services;
using UWPTP3.Views.ViewModels.UcAccessors;
using UWPTP3.Views.ViewModels.UcAccessors.Roles;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace UWPTP3.Views.ViewModels
{
    public class RoleCheckPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;

        public RolePageAccessor Datas { get; set; }

        public RoleCheckPageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
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
            foreach (var item in databaseService.Roles)
            {
                Datas.RoleList.Roles.Add(item);
            }
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

            try
            {
                databaseService.SqliteConnection.Insert(role);
                Datas.RoleList.Roles.Add(role);
            }
            catch (Exception e)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Error";
                contentDialog.Content = e.Message;
                contentDialog.IsSecondaryButtonEnabled = false;
                contentDialog.PrimaryButtonText = "ok";
                contentDialog.ShowAsync();
            }
        }
    }
}
