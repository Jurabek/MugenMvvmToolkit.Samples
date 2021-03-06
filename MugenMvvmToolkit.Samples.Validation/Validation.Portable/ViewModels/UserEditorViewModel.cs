﻿using System.Threading;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models.Messages;
using MugenMvvmToolkit.ViewModels;
using Validation.Portable.Models;

namespace Validation.Portable.ViewModels
{
    public class UserEditorViewModel : EditableViewModel<UserModel>
    {
        #region Fields

        private int _validationLoginCount;

        #endregion

        #region Properties

        public string Name
        {
            get { return Entity.Name; }
            set
            {
                Entity.Name = value;
                //NOTE: you can use local validator to add an error on the fly.
                if (!string.IsNullOrEmpty(value))
                {
                    if (char.IsUpper(value[0]))
                        Validator.ClearErrors("Name");
                    else
                        Validator.SetErrors("Name", "The name must begin with a capital letter.");
                }
                OnPropertyChanged();
            }
        }

        public string Login
        {
            get { return Entity.Login; }
            set
            {
                if (Equals(value, Entity.Login))
                    return;
                Entity.Login = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return Entity.Email; }
            set
            {
                if (Equals(value, Entity.Email))
                    return;
                Entity.Email = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoginValidating
        {
            get { return _validationLoginCount != 0; }
        }

        #endregion

        #region Overrides of ValidatableViewModel

        /// <summary>
        ///     Occurs when processing an asynchronous validation message.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="message">Information about event.</param>
        protected override void OnHandleAsyncValidationMessage(object sender, AsyncValidationMessage message)
        {
            if (ToolkitExtensions.GetMemberName(Entity, model => model.Login) != message.PropertyName)
                return;
            if (message.IsEndOperation)
                Interlocked.Decrement(ref _validationLoginCount);
            else
                Interlocked.Increment(ref _validationLoginCount);
            OnPropertyChanged(() => IsLoginValidating);
        }

        #endregion
    }
}