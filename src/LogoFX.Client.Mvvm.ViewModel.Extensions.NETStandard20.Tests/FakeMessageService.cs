﻿using System;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModel.Shared;

namespace LogoFX.Client.Mvvm.ViewModel.Extensions.Tests
{
    class FakeMessageService : IMessageService
    {
        public bool WasCalled { get; private set; }
        private MessageResult _messageResult = MessageResult.Yes;

        public MessageResult Show(string message, string caption = "", MessageButton button = MessageButton.OK, MessageImage icon = MessageImage.None)
        {
            WasCalled = true;
            return _messageResult;
        }

        public Task<MessageResult> ShowAsync(string message, string caption = "", MessageButton button = MessageButton.OK, MessageImage icon = MessageImage.None)
        {
            WasCalled = true;
            return Task.FromResult(_messageResult);
        }

        public MessageResult ShowError(Exception error, string caption = "")
        {
            throw new NotImplementedException();
        }

        public Task<MessageResult> ShowErrorAsync(Exception error, string caption = "")
        {
             WasCalled = true;
             return Task.FromResult(_messageResult);
        }

        internal void SetMessageResult(MessageResult messageResult)
        {
            _messageResult = messageResult;
        }
    }

    class FakeWindowManager : WindowManager
    {
        public Window CreateWindow(object rootModel)
        {
            return CreateWindow(rootModel, false, null, null);
        }
    }
}