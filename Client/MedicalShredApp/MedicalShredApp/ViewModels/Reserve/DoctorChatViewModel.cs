/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：DoctorChatViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/4/27 20:34:42
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MedicalShredApp.Action.Api;
using MedicalShredApp.Models.Chat;
using MedicalShredApp.Models.Common;
using MedicalShredApp.Models.Reserve;
using MedicalShredApp.Views.Reserve;
using Prism.Commands;
using Prism.Navigation;
using ViewModels.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace MedicalShredApp.ViewModels.Reserve
{
    public class DoctorChatViewModel : BaseViewModel
    {


        #region Field

        private string _doctorName;
        private Guid _doctorId;
        private ObservableCollection<ChatContentViewModel> _chatContent;
        private ChatMainModel _chatMain;
        private ICommand _sendMessageCommand;
        private string _messageInput;
        private ChatContentViewModel _selectedItem;

        #endregion

        #region Prop
        public string MessageInput
        {
            get => _messageInput;
            set => SetProperty(ref _messageInput, value, "MessageInput");
        }
        public string DoctorName
        {
            get => _doctorName;
            set => SetProperty(ref _doctorName, value, "DoctorName");
        }
        public ObservableCollection<ChatContentViewModel> ChatContent
        {
            get => _chatContent;
            set => SetProperty(ref _chatContent, value, "ChatContent");
        }

        public ChatContentViewModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value, "SelectedItem");
        }

        public ICommand SendMessageCommand => _sendMessageCommand ?? (_sendMessageCommand = new DelegateCommand(SendMessage));

        #endregion

        #region Method
        public DoctorChatViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddSignalREvent();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters[nameof(DoctorChatPage)] != null)
            {
                ChatToDoctorViewModel doctor = (ChatToDoctorViewModel)parameters[nameof(DoctorChatPage)];
                DoctorName = doctor.DoctorName;
                _doctorId = doctor.DoctorId;
                GetChatRecord();
            }
        }

        private async void GetChatRecord()
        {
            ChatMainModel chatMain = await Api.GetChatInfo(GlobalData.UserInfo.Uid, _doctorId);
            _chatMain = chatMain;
            ChatContent = await Api.GetChatContent(chatMain.Id);
            
        }
        private void SendMessage()
        {
            if (string.IsNullOrEmpty(MessageInput))return;
            bool r = Api.SendChatContent(new ChatContentModel
            {
                ChatId = _chatMain.Id,
                Content = MessageInput,
                UserId = GlobalData.UserInfo.Uid
            });
            if (r)
            {
                MessageInput = null;
            }
        }

        private void AddSignalREvent()
        {
            GlobalData.HubConnection.On<MessageData>(GlobalData.SEND_MESSAGE, async (obj) =>
            {
                //!CommonData.DoctorInfoViewModel.Id.Equals(obj.Id) &&
                if (_chatMain?.Id != obj.ChatId) return;
                ChatContent = await Api.GetChatContent(_chatMain.Id);
                SelectedItem = ChatContent.LastOrDefault();
            });
        }
        #endregion
    }
}
