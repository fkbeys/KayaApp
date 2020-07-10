using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KayaApp.Helpers
{
    public class EntryCompletedBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject = bindable;

            bindable.BindingContextChanged += Bindable_BindingContextChanged;
            bindable.Completed += Bindable_Completed;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
            bindable.Completed -= Bindable_Completed;

            AssociatedObject = null;
        }

        private void Bindable_BindingContextChanged(object sender, System.EventArgs e)
        {
            OnBindingContextChanged();
        }
        private void Bindable_Completed(object sender, System.EventArgs e)
        {
            if (Command == null) return;

            //object parameter = Converter.Convert(e, typeof(object), null, null);
            if (Command.CanExecute(e))
            {
                Command.Execute(e);
            }

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

        public Entry AssociatedObject { get; private set; }



        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(EntryCompletedBehavior), null);


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}
