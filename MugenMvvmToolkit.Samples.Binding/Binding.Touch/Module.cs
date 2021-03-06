﻿using System;
using Binding.Touch.Templates;
using MonoTouch.UIKit;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Binding.Models.EventArg;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;

namespace Binding.Touch
{
    public class Module : ModuleBase
    {
        #region Constructors

        public Module()
            : base(true, LoadMode.All)
        {
        }

        #endregion

        #region Overrides of ModuleBase

        /// <summary>
        ///     Loads the current module.
        /// </summary>
        protected override bool LoadInternal()
        {
            BindingServiceProvider.ResourceResolver.AddObject("buttonTemplate",
                new BindingResourceObject(new ButtonItemTemplate()));

            //Registering attached property
            IBindingMemberProvider memberProvider = BindingServiceProvider.MemberProvider;
            memberProvider.Register(AttachedBindingMember.CreateAutoProperty<UILabel, string>("TextExt",
                TextExtMemberChanged, TextExtMemberAttached, TextExtGetDefaultValue));

            memberProvider.Register(AttachedBindingMember.CreateMember<UILabel, string>("FormattedText",
                GetFormattedTextValue, SetFormattedTextValue, ObserveFormattedTextValue));
            return true;
        }

        /// <summary>
        ///     Unloads the current module.
        /// </summary>
        protected override void UnloadInternal()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Called once for each element in the time of accession to obtain default values.
        /// </summary>
        private static string TextExtGetDefaultValue(UILabel textBlock, IBindingMemberInfo bindingMemberInfo)
        {
            if (!ServiceProvider.DesignTimeManager.IsDesignMode)
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync("Invoking TextExtGetDefaultValue on " + textBlock.AccessibilityLabel, ToastDuration.Short);
            return "Default value";
        }

        /// <summary>
        ///     Called once for each element in the time of accession.
        /// </summary>
        private static void TextExtMemberAttached(UILabel textBlock, MemberAttachedEventArgs args)
        {
            if (!ServiceProvider.DesignTimeManager.IsDesignMode)
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync("Invoking TextExtMemberAttached on " + textBlock.AccessibilityLabel, ToastDuration.Short);
        }

        /// <summary>
        ///     Called every time when value changed.
        /// </summary>
        private static void TextExtMemberChanged(UILabel textBlock, AttachedMemberChangedEventArgs<string> args)
        {
            if (!ServiceProvider.DesignTimeManager.IsDesignMode)
                ServiceProvider
                    .IocContainer
                    .Get<IToastPresenter>()
                    .ShowAsync(string.Format("Invoking TextExtMemberChanged on {2} old value {0} new value {1}", args.OldValue,
                            args.NewValue, textBlock.AccessibilityLabel), ToastDuration.Short);
            textBlock.Text = string.Format("Old value \"{0}\" new value \"{1}\"", args.OldValue, args.NewValue);
        }

        /// <summary>
        ///     Used to observe member.
        /// </summary>
        private static IDisposable ObserveFormattedTextValue(IBindingMemberInfo bindingMemberInfo, UILabel label, IEventListener arg3)
        {
            return null;
            //                        return BindingServiceProvider.WeakEventManager.TrySubscribe(label, "EventName", arg3);            
        }

        /// <summary>
        ///     Called every time when value updated.
        /// </summary>
        private static void SetFormattedTextValue(IBindingMemberInfo bindingMemberInfo, UILabel textBlock, string value)
        {
            textBlock.Text = "Formatted " + value;
        }

        /// <summary>
        ///     Called every time when value changed.
        /// </summary>
        private static string GetFormattedTextValue(IBindingMemberInfo bindingMemberInfo, UILabel textBlock)
        {
            return textBlock.Text;
        }

        #endregion
    }
}